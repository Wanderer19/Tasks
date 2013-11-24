package VisualizationCrossword;
	
	use Encode qw(encode decode);
    use utf8;
	use Tk;
	use Tk::Table;
	use resources::Settings;
	
	sub visualize{
		my $self = shift;
		my ($rows, $columns, $geometry, $failure_message) = @_;
		
		
		my $main_window = MainWindow->new(-background => Settings::BACKGROUND_WORD);
		
		$main_window->bind('<Configure>' => sub {
													$xe = $main_window->XEvent;
													$main_window->maxsize($xe->w, $xe->h);
													$main_window->minsize($xe->w, $xe->h);
											}
							);
				
		if ($geometry){
			for my $i (0 .. $rows - 1){
				for my $j (0 .. $columns - 1){
					my $cell_crossword = $$geometry[$i][$j];
					my $letter = $cell_crossword->{"letter"};
					my $background = Settings::BACKGROUND_FIELD;
					my $borderwidth = Settings::LABEL_BORDERWIDTH;
					unless ($letter){
						$borderwidth--;
						$background = Settings::BACKGROUND_WORD;
						$letter = " * ";
					}
					
					$main_window->Label(
												-borderwidth => $borderwidth,
												-text => " $letter ",
												-background => $background,
												-relief => 'sunken',
										)->grid(-row => $i, -column => $j);
           
				}
			}
		}
		else{
				my $target_image = $main_window->Photo(-file => Settings::TARGET_IMAGE);
				$main_window->Label(-text => $failure_message)->pack();
				$main_window->Label(-image => $target_image)->pack(-fill => Settings::FILL_IMAGE);
		}
		
		MainLoop;
	}
1;