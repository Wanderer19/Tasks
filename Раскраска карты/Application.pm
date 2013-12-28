package Application;
	use Tk;
	use Country;
	use Settings;
	use Map;
	use Menu;
	
	sub New{
		my $class = shift;
		my $self = {};
		
		$self->{countries} = [];
		$self->{id} = [];
		return bless $self, $class;
	}
	
	sub Run{
		my $self = shift;
		
		$self->{map} = Map->New();
		$self->{mainWindow} = MainWindow->new(-background => Settings::Bacground);
		$self->ToFixSizeMainWindow();
		
		$self->{canvas} = $self->{mainWindow}->Canvas(
														-height => Settings::CanvasHeight,
														-width => Settings::CanvasWidth, 
														-background => Settings::CanvasBackground
													)->pack(-side => Settings::SideOfCanvas);
		

		$self->CreateMenu();
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
	
	sub DeleteCountry{
		my $self = shift;
		
		unless ($self->{isColoring}){
			$self->{canvas}->delete($self->{map}->DeleteCountry());
		}
	}
	
	sub CreateMenu{
		my $self = shift;
		
		my $mainMenu = $self->{mainWindow}->Menu(-background => Settings::Bacground);
		$self->{mainWindow}->configure(-menu => $mainMenu);
		
		my $fileMenu = Menu::->cascade($self->{mainWindow}, $mainMenu, "Map", sub{ exit }, "Exit", "<Control-w>", sub {$self->SaveCountry()}, "Save Country", "<Control-s>", sub {$self->DeleteCountry();}, "Cancel", "<Control-z>", sub {$self->Clear();}, "Clear", "<Control-x>");
		
	}
	
	sub Clear{
		my $self = shift;
		
		for (@{$self->{id}}){
			$self->{canvas}->delete($_);
		}
		
		$self->{map}->Clear();
		$self->{text}->delete("1.0", "end");
		$self->{isColoring} = 0;
	}
	
	sub CreateButtons{
		my $self = shift;
									
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
		$self->{isColoring} = 1;
		my $colors = Settings::Colors;
		my $coloring = Coloring->New($self->{map}->GetMatrixMap());
		$coloring->Colorize();
		#$self->{canvas}->delete(1);

		while (my ($index, $color) = each %{$coloring->{coloring}}){
			$self->DrawCountry($index, $$colors[$color]);
		}
	}
	
	sub SaveCountry{
		my $self = shift;
		
		unless ($self->{isColoring}){
			my $string = $self->{textField}->get("1.0", "end");
			chomp ($string);
		
			$self->{textField}->delete("1.0", "end");
			my @coordinates;
			for (split (/[\s]+/, $string)){
				if ($_){
					my ($x, $y) = split (Settings::Separator, $_);
					push @coordinates, [$x + 0, $y + 0];
				}
			}
		
			$self->{map}->SaveCountry(@coordinates);
		
			$self->{text}->insert("end", $string.Settings::Line."\n"); 
			$self->DrawCountry(-1, Settings::ColorEmptyCountry);
		}
	}
	
	sub DrawCountry{
		my $self = shift;
		my ($index, $color) = @_;
		push @{$self->{id}}, $self->{canvas}->createPolygon(
																$self->{map}->GetCoordinates($index),
																-fill => $color, 
																-outline => Settings::OutlineCountry, 
																-width => Settings::WidthCountry
															);
	}
	
	sub ShowXY{
		shift;
		my ($x, $y, $self) = @_;
		
		unless ($self->{isColoring}){
			my ($i, $j) = ($self->{canvas}->canvasx($x), $self->{canvas}->canvasy($y));
			$self->{textField}->insert("end", "$i". Settings::Separator."$j\n"); 
		}
	}
1;