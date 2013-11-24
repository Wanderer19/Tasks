package input; 
require Exporter;             
use locale;

@ISA = qw(Exporter);           
@EXPORT = qw(read_initial_target read_dictionary red_alphabet);   

sub read_initial_target{
    my $input=shift;
	 
	open (my $WORD,"$input") or die "Mistake at opening the document $input";
	 
	my $Initial = <$WORD>;
	chomp($Initial);
	$Initial = lc($Initial);
	my $Target = <$WORD>;
	chomp($Target);
	$Target = lc($Target);
	 
	close ($WORD) or die "Mistake at closing the document $input";
	 
	return ($Initial, $Target);
}

sub read_dictionary{
	my ($dictionary,$leng) = @_;
	
	open ( my $WD,"$dictionary" ) or die "Mistake at opening the document $dictionary";
     
    while ( defined($word = <$WD>) ){
        chomp($word);
	 
	    if(length $word ==$leng){
            $dictionary{$word}=1;
	    }
    }
	 
	close ( $WD ) or die "Mistake at closing the document $dictionary";
	 
	return (\%dictionary);
}

sub red_alphabet{
	$alphabet=shift;
	
	open ( my $W,"$alphabet" ) or die "Mistake at opening the document $alphabet";
	my @alph = split(//,<$W>);
	close ($W) or die "Mistake at closing the document $alphabet";
	 
	return (\@alph);
}	 
1;