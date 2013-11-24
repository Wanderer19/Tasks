package input;  

sub ReadLabyrinth{
	shift;
	my $Input = shift;
	open (my $L, "$Input") or die "Mistake at opening the document $Input";
	my $Rows = <$L>+0;
	my $Columns = <$L>+0;
	my $Enter1 = <$L>+0;
	my $Enter2 = <$L>+0;
	my $Exit1 = <$L>+0;
	my $Exit2 = <$L>+0;
	my $Bombs = <$L>+0;
	my @Labyrinth;
	
	for (my $i = 0; $i < $Rows; ++$i){
		my $LineMaze = <$L>;
		$LineMaze =~s/[\s]//g;
		my @LineMaze = split (//, $LineMaze);
		push @Labyrinth,\@LineMaze;
	}
	
	return undef if ($Labyrinth[$Enter1][$Enter2] == 1 || $Labyrinth[$Exit1][$Exit2] == 1);
	return undef unless (CheckTheCorrectness (\@Labyrinth));
	return new labyrinth (\@Labyrinth, $Enter1,  $Enter2, $Exit1, $Exit2, $Bombs);
}

sub CheckTheCorrectness{
	my $Labyrinth = shift;
	my @Labyrinth = @$Labyrinth;
	my $Rows = @Labyrinth;
	my $Columns = scalar (@{$Labyrinth[0]});
	
	for (my $i = 1; $i < $Rows; ++$i){
		return 0 if (scalar (@{$Labyrinth[$i]}) != $Columns);
	}
	
	for (my $i = 0; $i < $Rows; ++$i){
		for (my $j = 0; $j < $Columns; ++$j){
			return 0 unless ($Labyrinth[$i][$j] == 0 || $Labyrinth[$i][$j] == 1);
		}
	}
	return 1;
}
1;
			
	