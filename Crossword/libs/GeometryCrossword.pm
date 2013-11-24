package GeometryCrossword;
	use Class::Struct;
	use libs::Template;
	use libs::Menu;
	use libs::Geometry;
	use libs::Errors;
	use resources::Settings;
	use libs::HistoryWithGeometry;
	
	struct GeometryCrossword =>{
		rows => '$',
		columns => '$',
		titles => '%',
		main_window => '$',
		table => '$',
		templates_words => '@',
		all_lengths => '%',
		parent_window => '$',
		history_with_geometry => '$'
	};
	
	my $count_coordinates = 0;
	my @current_coordinates;
	my $deletion_word_flag = 0;

	sub run{
		my $self = shift;
		
		$self->rows($self->rows || Settings::DEFAULT_ROWS);
		$self->columns($self->columns || Settings::DEFAULT_COLUMNS);
		$self->history_with_geometry($self->history_with_geometry || HistoryWithGeometry->new(geometry => Geometry->new(rows => $self->rows, columns => $self->columns))); 
		
		my $main_window = MainWindow->new(
											-title => $self->titles->{'CROSSWORD_GEOMETRY'},
											-background => Settings::BACKGROUND
										);
		
		$main_window->bind('<Destroy>' => sub{ $self->activation_parent_window });
		$self->main_window($main_window);

		$self->main_window->Button(
									-text => $self->titles->{'BUTTON_CHANGE_SIZE'},
									-command => sub{ $self->change_size },
									-background => Settings::BUTTON_BACKGROUND,
									-activebackground => Settings::BUTTON_ACTIVEBACKGROUND,
									-foreground => Settings::FOREGROUND,
									-cursor => Settings::CURSOR,
									-relief => Settings::RELIEF_BUTTON,
									-borderwidth => Settings::BUTTON_BORDERWIDTH,
								)->pack;
		
		$self->create_menu();
		$self->create_working_field();								
		$self->update_field();
	}
	
	sub change_size{
		my $self = shift;
		my ($rows, $columns);
		
		my $dialog_box = $self->main_window->DialogBox(
														-title => $self->titles->{'BUTTON_CHANGE_SIZE'},
														-background => Settings::BACKGROUND, 
														-buttons => [Settings::BUTTON_OKAY, $self->titles->{'BUTTON_CANCEL'}], 
														-default_button => Settings::BUTTON_OKAY
													);
		my $lab_entry_rows = $dialog_box->add(
											   	'LabEntry', 
											   	-textvariable => \$rows, 
											   	-width => Settings::WIDTH_LAB_ENTRY, 
											   	-label => $self->titles->{'ROWS'}, 
											   	-labelPack => [-side => Settings::SIDE_LAB_ENTRY],
											   	-background => Settings::BACKGROUND
											)->pack;
		
		$lab_entry_rows->configure(
									-foreground => Settings::FOREGROUND,
									-background => Settings::BACKGROUND
								);
		
		my $lab_entry_columns = $dialog_box->add(
												  	'LabEntry', 
													-textvariable => \$columns, 
												  	-width => Settings::WIDTH_LAB_ENTRY, 
												  	-label => $self->titles->{'COLUMNS'},
												  	-background => Settings::BACKGROUND,
												  	-labelPack => [-side => Settings::SIDE_LAB_ENTRY]
												)->pack;
		
		$lab_entry_columns->configure(
										-background => Settings::BACKGROUND,
										-foreground => Settings::FOREGROUND
									);
		
		if ($dialog_box->Show eq Settings::BUTTON_OKAY){
			$self->set_size($rows, $columns);
				
			$self->table->destroy();
			$self->parent_window->state('withdrawn');
			$self->create_working_field();
		}
	}

	sub set_size{
		my $self = shift;
		my ($rows, $columns) = @_;

		@{$self->history_with_geometry->geometry->templates_words} = ();
		$self->history_with_geometry->geometry->rows($rows);
		$self->history_with_geometry->geometry->columns($columns);
		$self->rows($rows);
		$self->columns($columns);
	}

	sub activation_parent_window{
		my $self = shift;
		
		$self->parent_window->state('normal');
	}
	
	sub create_menu{
		my $self = shift;
		
		my $main_menu = $self->main_window->Menu(-background => Settings::BACKGROUND);
		$self->main_window->configure(-menu => $main_menu);
		
		my $crossword_menu = Menu::->cascade(	$self->main_window, $main_menu, $self->titles->{'MAIN_WINDOW_TITLE'},
												sub{ $self->cancel }, $self->titles->{'BUTTON_CANCEL'}, "<Control-z>", 
												sub{ $self->clear_field }, $self->titles->{'BUTTON_CLEAR'}, "<F4>", 
												sub{ $deletion_word_flag++;}, $self->titles->{'REMOVE_TEMPLATE'}, "<F5>",
												sub{ exit }, $self->titles->{'EXIT'}, "<Control-w>"
											);
		my $help_menu = Menu::->cascade(	$self->main_window, $main_menu, $self->titles->{'HELP'}, 
											sub { $self->show_pod }, $self->titles->{'POD'}, "<F1>"
										); 
	}
	
	sub show_pod{
		my $self = shift;
		my $pod = $self->main_window->Pod(-file => Settings::LOCALIZATION_POD_FILENAME_GEOMETRY_CROSSWORD);
	}
	
	sub create_working_field{
		my $self = shift;

		my $table = $self->main_window->Table(
												-columns => $self->columns,
												-rows => $self->rows ,
												-fixedrows => Settings::FIXED_ROWS_TABLE,
												-scrollbars => Settings::ANCHOR_SCROLLBARS
											);
								
		foreach my $row (1 .. $self->rows){
			foreach my $column (1 .. $self->columns){
				my $data = ($row - 1) . " : " . ($column - 1);
				my $cell = $table->Label(
										  	-text => $data,
                                          	-background => Settings::BACKGROUND_FIELD,
											-foreground => Settings::BACKGROUND_FIELD,
                                          	-relief => Settings::RELIEF_CELLS_TABLE,
											-padx => Settings::PADX_CELLS_TABLE
										);
				$cell->bind( '<Button>', [ sub { $self->handle_pressed_cell($cell, $table) }, $table ]);
				$table->put($row, $column, $cell);
			}
		}
		
		$table->pack();
		$self->table($table);
		$self->update_field();
	}
	
	sub cancel{
		my $self = shift;
		
		$self->history_with_geometry->undo_fast_event();
		$self->update_field();
	}
	
	sub update_field{
		my $self = shift;
		my @matrix_geometry = $self->history_with_geometry->get_matrix_geometry();
		
		for my $i (1 .. $self->rows){
			for my $j (1 .. $self->columns){
				my $cell = $self->table->get($i, $j);
				
				my $background = $matrix_geometry[$i-1][$j-1] ? Settings::BACKGROUND_WORD : Settings::BACKGROUND_FIELD;
					$cell->configure(
										-background => $background,
										-foreground => $background
								);
				}
		}
	}
			
	sub clear_field{
		my $self = shift;
		
		$self->history_with_geometry->clear();
		$self->update_field();
	}
	
	sub handle_pressed_cell{
		my $self = shift;
		my ($cell, $table) = @_;

		my ($rows, $columns) = $table->Posn($cell);
		push @current_coordinates, [$rows, $columns];
		$count_coordinates++;

		my $background = $deletion_word_flag ? Settings::BACKGROUND_REMOTE_WORD : Settings::BACKGROUND_WORD;
		$cell->configure(-background => $background, -foreground => $background);
		
		if ($count_coordinates == 2){
			my ($x1, $y1) = @{shift @current_coordinates};
			my ($x2, $y2) = @{shift @current_coordinates};
			
			if ($x1 == $x2 && $y1 == $y2){
				push @current_coordinates, [$x1, $y1];
				$count_coordinates = 1;
			}
			else{
				if ($x2 < $x1 || $y2 < $y1){
					($x1, $y1, $x2, $y2) = ($x2, $y2, $x1, $y1);
				}
				$deletion_word_flag ? $self->delete_word($x1 - 1, $y1 - 1, $x2 - 1, $y2 - 1) : $self->save_template_word($x1 - 1, $y1 - 1, $x2 - 1, $y2 - 1);				
				$count_coordinates = 0;
				$self->update_field();
			}				
		}
	}

	sub save_template_word{
		my $self = shift;

		unless ($self->history_with_geometry->save_template_word(@_)){
			Errors::->show_error($self->main_window, $self->titles->{'ERROR'}, $self->titles->{'ERROR_ENTERING_COORDINATES'});
		}
	}
			
	sub delete_word{
		my $self = shift;
	
		unless ($self->history_with_geometry->delete_word(@_)){
			Errors::->show_error($self->main_window, $self->titles->{'ERROR'}, $self->titles->{'ERROR_EXISTENCE_WORD'});
		}
				
		$deletion_word_flag = 0;
	}
1;