package Application;
	use utf8;
	use locale;
	no warnings 'layer';
	use Encode qw(encode decode);
	use MLDBM "DB_File";
	use Class::Struct;
	use libs::GeometryCrossword;
	use libs::HistoryWithGeometry;
	use libs::Menu;
	use libs::Errors;
	use resources::Settings;
	use libs::VisualizationCrossword;
	use libs::Words;
	
	struct Application =>{
	    main_window => '$',
		frame => '$',
		geometry_crossword => '$',
		titles => '%',
		words => '$',
		saved_crosswords => '$'
	};
	
	my @all_languages = ("Russian", "English");
	
	sub run{
		my $self = shift;
		my $language = shift;
		
		$self->words($self->words || Words->new);
		$self->geometry_crossword($self->geometry_crossword || GeometryCrossword->new);
		$self->geometry_crossword->history_with_geometry($self->geometry_crossword->history_with_geometry);
		$self->load_titles($language);
		
		my $main_window = Tk::ApplicationNest->new(
													-title => $self->titles->{'MAIN_WINDOW_TITLE'},
													-background => Settings::BACKGROUND,
													-set_icon => Settings::ICON
												);
		$main_window->geometry(Settings::SIZE_MAIN_WINDOW);	
		my $frame = $main_window->Frame(-background => Settings::BACKGROUND)->pack;
		
		$self->main_window ($main_window);
		$self->frame ($frame);
        
		$self->create_menu();
		$self->add_image();
		$self->create_buttons();
	}
	
	sub set_words{
		my $self = shift;
		
		$self->main_window->state('withdrawn');
		$self->words->titles($self->titles);
		$self->words->parent_window($self->main_window);
		$self->words->run(); 
	}
	
	sub load_titles{
		my $self = shift;
		my $language = shift;
		
		tie my %titles, MLDBM, Settings::LOCALIZATION_DB_FILENAME or die "$!";
		
		$self->titles($titles{$language});
		
		untie %titles;
	}
	
	sub create_menu{
		my $self = shift;
		
		my $main_menu = $self->main_window->Menu(-background => Settings::BACKGROUND);
		$self->main_window->configure(-menu => $main_menu);
		
		my $file_menu = Menu::->cascade($self->main_window, $main_menu, $self->titles->{'FILE_MENU'}, sub{ exit }, $self->titles->{'EXIT'}, "<Control-w>", sub {$self->save_crossword}, $self->titles->{'SAVE_CROSSWORD'}, "<Control-s>");
		my $help_menu = Menu::->cascade($self->main_window, $main_menu, $self->titles->{'HELP'} , sub{ $self->show_about }, $self->titles->{'ABOUT_PROGRAM'}, "<F1>",
																								sub{ $self->show_pod }, $self->titles->{'POD'}, "<F2>"); 

		$self->add_saved_crosswords_to_menu($file_menu);
		$self->add_languages_to_menu($file_menu);
	}
	
	sub add_saved_crosswords_to_menu{
		my $self = shift;
		my $menu = shift;

		my $saved_crosswords = $menu->cascade(-label => $self->titles->{'SAVED_CROSSWORDS'});
		$self->saved_crosswords($saved_crosswords);
		
		foreach my $cross ($self->get_all_crosswords()){
			Menu::->add_radiobutton($self->saved_crosswords, $cross, sub {$self->change_geometry($cross)});
		}

		untie %all_crosswords;
	}
	
	sub get_all_crosswords{
		my $self = shift;
		
		tie my %all_crosswords, MLDBM, Settings::FILE_WITH_CROSSWORDS or die "$!";
		
		my @keys = keys %all_crosswords;
		
		untie %all_crosswords;
		
		return @keys;
	}
		
	sub add_languages_to_menu{
		my $self = shift;
		my $menu = shift;

		my $language_menu = $menu->cascade(-label => $self->titles->{'LANGUAGE'});		
		
		for my $language (@all_languages){
			Menu::->add_radiobutton($language_menu, $language, sub {$self->change_language($language)});
		}
	}

	sub add_image{
		my $self = shift;

		my $image = $self->main_window->Photo(-file => Settings::MAIN_IMAGE);
		$self->frame->Label(-image => $image)->pack(-fill => Settings::FILL_IMAGE);
	}

	sub create_buttons{
		my $self = shift;

		$self->main_window->Button(
									-text => $self->titles->{'BUTTON_SET_WORDS'},
									-command => sub{ $self->set_words },
									-background => Settings::BUTTON_BACKGROUND,
									-activebackground => Settings::BUTTON_ACTIVEBACKGROUND,,
									-cursor => Settings::CURSOR,
									-relief => Settings::RELIEF_BUTTON,
									-borderwidth => Settings::BUTTON_BORDERWIDTH
								)->pack;
		
		$self->main_window->Button(
									-text => $self->titles->{'BUTTON_SET_GEOMETRY'},
									-command => sub{ $self->form_geometry_crossword },
									-background => Settings::BUTTON_BACKGROUND,
									-activebackground => Settings::BUTTON_ACTIVEBACKGROUND,
									-cursor => Settings::CURSOR,
									-relief => Settings::RELIEF_BUTTON,
									-borderwidth => Settings::BUTTON_BORDERWIDTH
								)->pack;
		
		$self->main_window->Button(
									-text => $self->titles->{'BUTTON_FILL'},
									-command => sub{ $self->fill_crossword },
									-background => Settings::BUTTON_BACKGROUND,
									-activebackground => Settings::BUTTON_ACTIVEBACKGROUND,
									-cursor => Settings::CURSOR,
									-relief => Settings::RELIEF_BUTTON,
									-borderwidth => Settings::BUTTON_BORDERWIDTH										
								)->pack;
	}

	sub change_language{
		my $self = shift;
		my $language = shift;
		
		$self->main_window->destroy();
		$self->run($language);
	}
	
	sub show_about{
		my $self = shift;
		
		my $help_window = $self->main_window->Toplevel;
		$help_window->title($self->titles->{'ABOUT_PROGRAM'});
		$help_window->Label(-text => $self->titles->{'MESSAGE_ABOUT_PROGRAM'})->pack;
	}
	
	sub show_pod{
		my $self = shift;
		
		my $pod = $self->main_window->Pod(-file => Settings::LOCALIZATION_POD_FILENAME_APPLICATION);
	}
		
	sub form_geometry_crossword{
		my $self = shift;

		$self->geometry_crossword->titles($self->titles);
		$self->main_window->state('withdrawn');
		$self->geometry_crossword->parent_window($self->main_window);
		$self->geometry_crossword->run();
		
	}
	
	sub fill_crossword{
		my $self = shift;
		
		if ($self->words->is_words_list_empty){
			Errors::->show_error($self->main_window, $self->titles->{'ERROR'}, $self->titles->{'EMPTY_WORDS_LIST_ERROR'});
		}
		elsif ($self->is_geometry_undefined()){
			Errors::->show_error($self->main_window, $self->titles->{'ERROR'}, $self->titles->{'UNDEFINED_GEOMETRY_ERROR'});
		}
		else{
			my $crossword = new Crossword($self->geometry_crossword->history_with_geometry->geometry, $self->words->words);
			my $geometry = $crossword->complete();	
			VisualizationCrossword::->visualize($self->geometry_crossword->rows, $self->geometry_crossword->columns, $geometry, $self->titles->{'FAILURE_MESSAGE'});
		}
	}
	
	sub change_geometry{
		my $self = shift;
		my $name = shift;
		
		$self->deserialize_crossword($name);
	}
	
	sub get_name_crossword{
		my $self = shift;
		
		my $name;		
		my $dialog_box = $self->main_window->DialogBox(
														-title => $self->titles->{'NAME'},
														-background => Settings::BACKGROUND,
														-buttons => [Settings::BUTTON_OKAY],
														-default_button => Settings::BUTTON_OKAY
													);
		my $lab_entry = $dialog_box->add(
											'LabEntry', 
											-textvariable => \$name, 
											-width => Settings::WIDTH_LAB_ENTRY, 
											-label => $self->titles->{'NAME'}, 
											-labelPack => [-side => Settings::SIDE_LAB_ENTRY],
											-background => Settings::BACKGROUND
									)->pack;
		
		$lab_entry->configure(
								-background => Settings::BACKGROUND,
								-foreground => Settings::FOREGROUND
							);
		
		return $name if ($dialog_box->Show eq Settings::BUTTON_OKAY);
	}
	
	sub save_crossword{
		my $self = shift;
		my $name = '';
	
		while ($name eq '' || !$self->save_crossword_to_db($name)){
			Errors::->show_error($self->main_window, $self->titles->{'ERROR'}, $self->titles->{'EXISTING_NAME'}) if ($name);
			$name = $self->get_name_crossword();
		}
	}

	sub save_crossword_to_db{
		my $self = shift;
		my $name = shift;
		
		tie my %all_crosswords, MLDBM, Settings::FILE_WITH_CROSSWORDS or die "$!";
		
		if (exists $all_crosswords{$name}){
			untie %all_crosswords;
			return 0;
		}
		else{
			$all_crosswords{$name} = $self->serialize_crossword();
		
			Menu::->add_radiobutton($self->saved_crosswords, $name, sub {$self->change_geometry($name)});
		
			untie %all_crosswords;
		}
		return 1;
	}
		
	sub serialize_crossword{
		my $self = shift;
		
		my %hash;
		$hash{'rows'} = $self->geometry_crossword->rows;
		$hash{'columns'} = $self->geometry_crossword->columns;
		
		my @coordinates;
		for (@{$self->geometry_crossword->history_with_geometry->geometry->templates_words}){
			push @coordinates, [$_->{x1}, $_->{y1}, $_->{x2}, $_->{y2}];
		}
		
		$hash{'coordinates'} = \@coordinates;
		$hash{'events'} = $self->geometry_crossword->history_with_geometry->events;
		return \%hash;
	}
	
	sub deserialize_crossword{
		my $self = shift;
		my $name = shift;
		
		
		tie my %all_crosswords, MLDBM, Settings::FILE_WITH_CROSSWORDS or die "$!";
		
		$self->geometry_crossword->rows($all_crosswords{$name}->{'rows'});
		$self->geometry_crossword->columns($all_crosswords{$name}->{'columns'});
		
		my @templates_words;
		for (@{$all_crosswords{$name}->{'coordinates'}}){
			$new_template = new Template(@$_);
			push @templates_words, $new_template;
		}
	
		my $geometry = Geometry->new(templates_words => \@templates_words, rows => $all_crosswords{$name}->{'rows'}, columns => $all_crosswords{$name}->{'columns'});
		$self->geometry_crossword->titles($self->titles);
		$self->geometry_crossword->history_with_geometry(HistoryWithGeometry->new(geometry => $geometry, events => $all_crosswords{$name}->{'events'}));
		untie %all_crosswords;
	}
	
	sub is_geometry_undefined{
		my $self = shift;
		
		return 1 unless (defined $self->geometry_crossword->history_with_geometry);
		return $self->geometry_crossword->history_with_geometry->is_geometry_undefined();
	}
1;