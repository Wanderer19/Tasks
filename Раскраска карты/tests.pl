use Test::Simple tests => 1;

Test_1();
Test_2();
Test_3();
Test_4();
Test_5();

sub Test_1{

}

sub Test_2{

}

sub Test_3{

}

sub Test_4{


}

sub Test_5{

}

sub Check{
	my ($expectedCount, $matrix, $coloring) = @_;
	
	my @matrix = @$matrix;
	my %hash;
	@hash{values %$coloring} = ();
	my $actualCount = scalar keys %hash;
	
	return 0 unless ($expectedCount == $actualCount);
	
	for my $i (0 .. $#matrix){
		for my $j (0 .. $#matrix){
			if ($matrix[$i][$j] == 1){
				return 0 if ($coloring->{$i} == $coloring->{$j});
			}
		}
	}
	
	return 1;
}