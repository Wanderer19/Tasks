package pairs;           
use locale;
require Exporter;             
use Text::ParseWords;
@ISA = qw (Exporter); 
@EXPORT = qw (pairs_of_words);

sub pairs_of_words{
    my ($text,$list) = @_;
	my (%pairs_list,@all_sentences,@all_words);
	@all_sentences = quotewords('[\.!\?]+', 0, lc($text));
    
	for $i (@all_sentences){
		@all_words = quotewords('[^\w]+', 0, $i);
		@all_words = grep{!exists($list->{$_}) && $_}@all_words;
		new_pair(\@all_words,\%pairs_list);
	}
	
	return  max(\%pairs_list);	
}

sub max{
    my $pairs_list = shift;
    my @res;
	my @keys = keys (%$pairs_list) ;
	
	foreach my $key ( sort {$pairs_list->{$b} <=> $pairs_list->{$a}} @keys ){
        push @res, [$key,$pairs_list->{$key}];
	}
	
	return \@res;
}

sub new_pair{
	my ($words,$pairs_list) = @_;
	my (%frequency,@word,$amount);
	
	$frequency{$_}++ foreach (@$words);
	@word = sort keys(%frequency);
	
	for ( my $i=0 ;$i<scalar(@word); ++$i ){
		$amount = ($frequency{$word[$i]})*($frequency{$word[$i]}-1)/2;
		$pairs_list->{"$word[$i] - $word[$i]"} += $amount if ( $amount );
		
		for ( my $j=$i+1 ;$j<scalar(@word); ++$j ){
			$pairs_list->{"$word[$i] - $word[$j]"} += $frequency{$word[$i]}*$frequency{$word[$j]};
		}
	}
}
1;