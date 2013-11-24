use Test::Simple tests => 17; 
use pairs;

ok(check(['eye - see : 2','feel - heart : 1','feel - ones : 1','feel - sink : 1','get - hand : 1','get - of : 1','get - out : 1','hand - of : 1','hand - out : 1','heart - ones : 1','heart - sink : 1','of - out : 1','eye - eye : 1','ones - sink : 1'],pairs_of_words("To see eye to eye.To get out of hand!To feel ones heart sink.",makeHash(['easy','to']))));
ok(check([],pairs_of_words("Easy come.Easy go",makeHash(["easy","to"]))));
ok(check([],pairs_of_words("",makeHash(["easy','to"]))));
ok(check([],pairs_of_words("To see eye to eye.Easy come,easy go!",makeHash(['to','see','eye','easy','come','go']))));
ok(check([],pairs_of_words("a b a a c.A b a",makeHash(['a','b','c']))));
ok(check(['does - it : 2'],pairs_of_words("It does not make sense.You does not must doing it!",makeHash(["not","make","sense","you","must","doing"]))));
ok(check(['aa - bb : 2','aa - cd : 1'],pairs_of_words("aa bb k .Aa b CD!AA jjd  bB?",makeHash(["b","k","jjd"]))));
ok(check(['a - b : 1','a - c : 1','b - c : 1'],pairs_of_words("a b c",{})));
ok(check(['a - b : 1','a - c : 1','b - c : 1'],pairs_of_words("a c b",{})));
ok(check(['a - a : 6'],pairs_of_words("a a a a",{})));
ok(check(['aa - aa : 3'],pairs_of_words("AA aa Aa",{})));
ok(check(['a - b : 5','a - a : 4','a - c : 3','b - c : 1'],pairs_of_words("a b a a c.A b a",{})));
ok(check(['ab - c : 1','d - e : 1'],pairs_of_words("ab c.\n\ne d?",{})));
ok(check(['a - a : 70'],pairs_of_words("a a a a a a         a A a A A .\n\n\na a a a A    A?b a!",makeHash(['b']))));
ok(!check(['A - a : 70'],pairs_of_words("a a a a a a         a A a A A .\n\n\na a a a A    A?b a!",makeHash(['b']))));
ok(!check(['a - c : 1', 'a - b : 2', 'a - c : 1'],pairs_of_words("a b. a b. a c", makeHash([]))));
ok(check(['a - b : 2','a - c : 1'],pairs_of_words("a b. a b. a c", makeHash([]))));

sub makeHash{
	my $array = shift;
	my %new_hash;
	@new_hash{@$array} = ();
	
	return \%new_hash;
}

sub check{
	my ( $expected , $actual ) = @_;
	my @quantities_from_actual = map{ $$_[1]}@$actual;
	my @actual = map{ "$$_[0] : $$_[1]"}@$actual;
	
	return 0 unless(descending(\@quantities_from_actual));
	return 0 unless(equal(\@actual,$expected));
	return 1;
}

sub descending{
    my $array = @_;
	    
	for ( my $i=0; $i<scalar(@$array)-1; ++$i ){
	    return 0 if ( $$array[$i] < $$array[$i+1] );
	}
	
	return 1;
}

sub equal{
	my ( $actual , $expected ) = @_;
	
	my @sorted_actual = sort(@$actual);
	my @sorted_expected = sort(@$expected);
	
	return 0 unless(@sorted_actual ~~ @sorted_expected);
	return 1;
}
