package input;            
use locale;
require Exporter;             

@ISA = qw (Exporter); 
@EXPORT = qw (read_text read_not_words);

sub read_text{
    my $text=shift;
	local $/;

	open ( my $TEXT,"$text" ) or die "Mistake at opening the document $text";
    my $a = <$TEXT>;
	close ($TEXT);
	
	return $a;
}

sub read_not_words{
    my $not_words = shift;
	my %list; 
    
	open ( my $NOT_W,"$not_words" ) or die "Mistake at opening the document $not_words";

	while ( defined($not_word = <$NOT_W>) ){
        chomp($not_word);
	    $not_word = lc($not_word);
	    $list{$not_word} = 1;
    }
	
	close ($NOT_W);
	
	return \%list;
}
1;
