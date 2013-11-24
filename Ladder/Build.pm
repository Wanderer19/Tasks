package Build;
require Exporter;              

@ISA = qw(Exporter);           
@EXPORT = qw(form);   
          
sub form{
	my ($dictionary,$Initial,$Target,$alph) = @_;
	my @chain;

	my $tree = forming($Target,$alph,$dictionary);
	my $x = $tree->{$Initial};
	 
	unless ( defined($x) ){
	    my @chain = ();
	    return \@chain;
	}
	 
	push @chain,$Initial,$x;
	 
	while ( $x ne $Target ){
	    push @chain,$tree->{$x};
	    $x = $tree->{$x};
	}
	 
	return \@chain;
}	 
	 
sub forming{
	my ($Target,$alph,$dictionary) = @_;
	my (%tree,@a);
		  
    push @a,$Target;
	     
    foreach  my $f ( @a ){
		my $temporary=$f;
		     
        for ( my $j=0 ;$j<length $f; $j++ ){
		    foreach my $i ( @$alph ){ 
	            substr($temporary,$j,1)=$i;
		             
			    if ( exists($dictionary->{$temporary}) && ($temporary ne $f) && (!defined($tree{$temporary})) ){
		            $tree{$temporary} = $f;
					push @a,$temporary;
			    }
		  
		        $temporary=$f;
	        }
        }
    }
	     
    return \%tree;
}
1;
