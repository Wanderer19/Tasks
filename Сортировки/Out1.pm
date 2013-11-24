package Out1; 
require Exporter;             
use locale;

@ISA = qw(Exporter);           
@EXPORT = qw(outp);   

sub outp{
	my ($n,$output,$global,$sorts)=@_;
	 
	open ( my $OUT,">$output" ) or die "Mistake at opening the document $output";
			 
	foreach my $s ( @$n ){
		print $OUT "$s\n";
		
		foreach my $r ( @$sorts ){
		    print $OUT "$r:\t\n";
		 
		    while ( my($key,$val) = each($global->{$s}{$r}) ){
		        print $OUT "$key  $val\n";
		    }
		 
		    print $OUT "\n";
		}
		 
		print $OUT "\n";
	}
		  
	print $OUT "STABILITY:\n";
		 
	foreach my $e ( @$sorts ){
		print  $OUT "$e","\t",$global->{"$e"}{stability},"\n";
	}
	
	close ($OUT) or die "Mistake at closing the document $output";
}			
1;			