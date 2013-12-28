package Application;
	use Tk;
	use Country;
	use Settings;
	
	sub New{
		my $class = shift;
		my $self = {};
		
		$self->{countries} = [];
		
		return bless $self, $class;
	}
	
	sub Run{
		my $self = shift;
		
		$self->{mainWindow} = MainWindow->new(-background => Settings::Bacground);
		$self->ToFixSizeMainWindow();
		
		$self->{canvas} = $self->{mainWindow}->Canvas(
														-height => Settings::CanvasHeight,
														-width => Settings::CanvasWidth, 
														-background => Settings::CanvasBackground
													)->pack(-side => Settings::SideOfCanvas);
		

	
		$self->CreateButtons();						
		
		$self->{canvas}->CanvasBind("<Button-1>", [\&ShowXY, Ev('x'), Ev('y'), $self]);
		
		$self->CreateTextField();
	}
	
	sub ToFixSizeMainWindow{
		my $self = shift;
		
		$self->{mainWindow}->bind('<Configure>' => sub {
															$xe = $self->{mainWindow}->XEvent;
															$self->{mainWindow}->maxsize($xe->w, $xe->h);
															$self->{mainWindow}->minsize($xe->w, $xe->h);
														}
										);	
	}
	
	sub CreateButtons{
		my $self = shift;
		
		$self->{mainWindow}->Button(
										-text => Settings::TextButtonSaveCountry,
										-command => sub{ $self->SaveCountry()},
										-background => Settings::BackgroundButton,
										-activebackground => Settings::ActiveBackgroundButton,
										-foreground => Settings::ForegroundButton,
										-cursor => Settings::CursorButton,
										-relief => Settings::ReliefButton,
										-borderwidth => Settings::BorderwidthButton
									)->pack;
									
		$self->{mainWindow}->Button(
										-text => Settings::TextButtonColorize ,
										-command => sub{ $self->Colorize()},
										-background => Settings::BackgroundButton,
										-activebackground => Settings::ActiveBackgroundButton,
										-foreground => Settings::ForegroundButton,
										-cursor => Settings::CursorButton,
										-relief => Settings::ReliefButton,
										-borderwidth => Settings::BorderwidthButton
									)->pack;
	}
	
	sub CreateTextField{
		my $self = shift;
		
		$self->{textField} = $self->{mainWindow}->Scrolled(
																"Text", 
																-scrollbars => Settings::ScrollbarText,
																-width => Settings::WidthTextField, 
																-height => Settings::HeightTextField
															)->pack();
		$self->{text} = $self->{mainWindow}->Scrolled(
																"Text", 
																-scrollbars => Settings::ScrollbarText,
																-width => Settings::WidthText, 
																-height => Settings::HeightText
															)->pack();
		
				
		
	}
	
	sub Colorize{
		my $self = shift;
		my $colors = Settings::Colors;
		my $coloring = Coloring->New(Country->GetMatrix(@{$self->{countries}}));
		$coloring->Colorize();
		#$self->{canvas}->delete(1);

		while (my ($index, $color) = each %{$coloring->{coloring}}){
			$self->DrawCountry($index, $$colors[$color]);
		}
	}
	
	sub SaveCountry{
		my $self = shift;
		
		my $string = $self->{textField}->get("1.0", "end");
		chomp ($string);
		
		$self->{textField}->delete("1.0", "end");
		my @coordinates;
		for (split (/[\s]+/, $string)){
			push @coordinates, [split (",", $_)] if ($_);
		}
		
		my $newCountry = Country->New(@coordinates);
		$newCountry->GetIntersections(@{$self->{countries}});
		push @{$self->{countries}}, $newCountry;
		
		for (@{$self->{countries}}){
			$_->Print();
		}
		
		$self->{text}->insert("end", $string. "------------\n"); 
		$self->DrawCountry(-1, Settings::ColorEmptyCountry);
	}
	
	sub DrawCountry{
		my $self = shift;
		my ($index, $color) = @_;
		print $self->{canvas}->createPolygon(
												$self->{countries}->[$index]->GetCoordinates(),
												-fill => $color, 
												-outline => Settings::OutlineCountry, 
												-width => Settings::WidthCountry
											);
	}
	
	sub ShowXY{
		shift;
		my ($x, $y, $self) = @_;
		
		my ($i, $j) = ($self->{canvas}->canvasx($x), $self->{canvas}->canvasy($y));
		$self->{textField}->insert("end", "$i,$j\n"); 
	}
1;