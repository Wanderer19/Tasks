use Palindrom;
use Test::Simple tests=>10;
use locale;

ok(@{Palindrom::new_palindrome("Able was I ere I saw Elba")} == 5);
ok(@{Palindrom::new_palindrome("Dammit, I'm mad!")} == 3);
ok(@{Palindrom::new_palindrome("1111111111111")} == 1);
ok(@{Palindrom::new_palindrome("А баба на волі - цілована баба.")} == 3);
ok(@{Palindrom::new_palindrome("1G1G1")} == 1);
ok(@{Palindrom::new_palindrome("Кит романтик на море")} == 0);
ok(@{Palindrom::new_palindrome("")} == 0);
ok(@{Palindrom::new_palindrome("!!!//$#@6@")} == 0);
ok(@{Palindrom::new_palindrome("Phow!")} == 0);
ok(just_once(Palindrom::new_palindrome("a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a")));


sub just_once{
	my $palindroms = shift;
	my @palindroms = @$palindroms;
	my $res=0;
	for my $i(0..$#palindroms){
		$res++ unless($palindroms[$i] eq $palindroms[$i]);
	}
	if ($res>1){
		return 0;
	}
    else {
		return 1;
	}
}
