package Palindrom;
use locale;

sub is_it_palindrome {
	my $text = shift;
	$text =~ s/ //g;
	return 1 if ($text eq reverse($text));
	return 0;
}

sub new_palindrome{
	my $text = shift;
	$text = lc($text);
	my (@sentences,@words,%palindroms);
	@sentences = split /[\.\;\:\?\!]+/,$text;
    my @words_from_all_text;
	for (my $i=0 ;$i<=$#sentences; $i++){
		@words = split/[^\w]+/,$sentences[$i];
		@words = grep{$_}@words;
		push @words_from_all_text,@words;
	}
	create_a_palindrome(\@words_from_all_text,\%palindroms);
	my @keys = keys(%palindroms);
	return \@keys;
}

sub create_a_palindrome{
	my ($words_from_text,$pal) = @_;
	my @words_from_text = @$words_from_text;

	for (my $i=0;$i<=$#words_from_text;$i++){

		my $palindrom = $words_from_text[$i];

		for(my $j=$i+1;$j<=$#words_from_text+1;$j++){
			if(is_it_palindrome($palindrom)){
				$pal->{$palindrom}=1;
			}
			$palindrom = $palindrom." ".$words_from_text[$j];
		}
	}
}
1;