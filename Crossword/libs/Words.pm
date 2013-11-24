
package Words;
	use Tk;
	use utf8;
	use locale;
	no warnings 'layer';
	use Encode qw(encode decode);
	use Class::Struct;
	use libs::Errors;
	use resources::Settings;
	
	struct Words =>{
		words => '@',
		main_window => '$',
		text => '$',
		titles => '%',
		parent_window => '$'
	};
	
	sub run{
		my $self = shift;
		
		my $main_window = MainWindow->new(
											-title => $self->titles->{'BUTTON_SET_WORDS'},
											-background => Settings::BACKGROUND
										);
		
		$main_window->protocol('WM_DELETE_WINDOW', sub{
														$self->save_words(); 
														$main_window->destroy()
													}
							);
		
		$main_window->bind('<Destroy>' => sub{ $self->activation_parent_window });
		$self->main_window($main_window);
		
		$main_window->Button(
								-text => $self->titles->{'BUTTON_LOAD_FILE'} ,
								-command => sub {$self->load_file},
								-background => Settings::BUTTON_BACKGROUND,
								-activebackground => Settings::BUTTON_ACTIVEBACKGROUND,
								-cursor => Settings::CURSOR,
								-relief => Settings::RELIEF_BUTTON,
								-borderwidth => Settings::BUTTON_BORDERWIDTH
							)->pack();
		
		my $text = $self->main_window->Scrolled(
													"Text", 
													-scrollbars => Settings::ANCHOR_SCROLLBARS,
													-width => Settings::WIDTH_ENTRY_TEXT_FIELD, 
													-height => Settings::HEIGHT_ENTRY_TEXT_FIELD
												)->pack();
		$self->text($text);
		$self->get_words();
	}
	
	sub get_words{
		my $self = shift;
		
		for my $word (@{$self->words}){
			$self->text->insert("end", "$word\n"); 
		}
	}
	
	sub activation_parent_window{
		my $self = shift;
		
		$self->parent_window->state('normal');
	}
	
	sub load_file{
		my $self = shift;
		
		my $filename = $self->main_window->getOpenFile();
		chomp $filename;
		$filename =~ s/\\/\//g;
		
		open (my $stream_words, "$filename") or Errors::->show_error($self->main_window, $self->titles->{'ERROR'}, "$!");
	
		for my $string (<$stream_words>){
			$string = decode('utf8', $string);
			$self->text->insert("end", $string); 
		}
	
		close ($stream_words);
	}
	
	sub save_words{
		my $self = shift;
		@{$self->words} = ();
		
		my $string = $self->text->get("1.0", "end");
		chomp ($string);
		lc ($string);
	
		@{$self->words} = split (/[\s]+/, $string);
	}
	
	sub is_words_list_empty{
		my $self = shift;

		return 1 unless (defined $self->words->[0]);
		return 0;
	}
1;