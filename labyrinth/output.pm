package output;
use Tk;

sub PrintPathVisual{
	my ($Labyrinth, $Path) = @_;
	my $Labyrinth = $Labyrinth->{labyrinth};
	my $MainWindow = MainWindow->new();
	
	if (defined ($$Path[0])){
		my @Path;
		push @Path,"$$_[0] - $$_[1]" foreach ( @$Path );
		my @Maze = @$Labyrinth;
		my $Rows = scalar( @Maze );
		my $Columns = scalar( @{$Maze[0]} );
		my @VisualizedMaze;
		my $Img1 = $MainWindow->Photo(-file => "path.gif");
		my $Img2 = $MainWindow->Photo(-file => "bomb.gif");
		my $Img3 = $MainWindow->Photo(-file => "pass.gif");
		my $Img4 = $MainWindow->Photo(-file => "wall.gif");
		
		
		for (my $i = 0; $i<$Rows; ++$i){
			for (my $j = 0; $j<$Columns; ++$j){
				if ("$i - $j" ~~ @Path){
					if ($Maze[$i][$j] == 0){
						$VisualizedMaze[$i][$j] = $MainWindow->Label(-image => $Img1)->grid(-row => $i, -column => $j);
					}
					else{
						$VisualizedMaze[$i][$j] = $MainWindow->Label(-image => $Img2)->grid(-row => $i, -column => $j);
					}
				}
				else{
					if ($Maze[$i][$j] == 0){
						$VisualizedMaze[$i][$j] = $MainWindow->Label(-image => $Img3)->grid(-row => $i, -column => $j);
					}
					else{
						$VisualizedMaze[$i][$j] = $MainWindow->Label(-image => $Img4)->grid(-row => $i, -column => $j);
					}
				}
			}
		}
		MainLoop;
	}
	else{
		my $img = $MainWindow->Photo(-file => "Gandalf.gif");
		$MainWindow->Label(-image => $img)->pack;
		MainLoop();
	}
}

sub  PrintPathUnvisual{
	my ($Labyrinth, $Path, $Output) = @_;
	my $Labyrinth = $Labyrinth->{labyrinth};
	my @Path;
	my @Maze = @$Labyrinth;
	my $Rows = scalar (@Maze);
	my $Columns = scalar (@{$Maze[0]});
	
	open (my $Out, ">$Output") or die "Mistake at opening the document $Output";
	
	if (defined ($$Path[0])){
		print $Out "$$_[0] - $$_[1]\n" foreach (@$Path);
		push @Path,"$$_[0] - $$_[1]" foreach ( @$Path );
		
		for (my $i = 0; $i<$Rows; ++$i){
			for (my $j = 0; $j<$Columns; ++$j){
				if ("$i - $j" ~~ @Path){
					if ($Maze[$i][$j] == 0) {
						print $Out "#"," ";
					}
					else{
						print $Out "*"," ";
					}
				}
				else{
					print $Out $Maze[$i][$j]," ";
				}
			}
			print $Out "\n";
		}
	}
	else{
		print "You shall not pass!\n";
	}
}
1;