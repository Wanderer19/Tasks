use Out1;
use Table;
use Pod::Usage;
use Getopt::Long 2.24 qw( :config no_auto_abbrev no_ignore_case );

my ($output,$n1,$n2,$step,$help,$man,)=('-',10,100,10);
my $options_okay = GetOptions(
    'help|h' => \$help, 
	'man' => \$man,
    'n1:i' => \$n1,
    'n2:i' => \$n2,
	'step:i' => \$step,
    'out:s' => \$output,
    
);	

pod2usage( -exitval => 2, -verbose => 0 ) unless $options_okay;
pod2usage( 1 ) if $help;
pod2usage( -exitval => 0, -verbose => 2 ) if $man;

my @sorts=('select_sort','bubble_sort','insert_sort','pyramid_sort','quick_sort','shell_sort','merge_sort','function_sort');
my ($table,$n)=table(\@sorts,$n1,$n2,$step);
outp($n,$output,$table,\@sorts);

__END__
 
=head1 NAME

sorting.pl

=head1 SYNOPSIS

sorting.pl [--h | --help] [--n1 , --n2 , --step, --out) ] 

Parameters:
  
-h | --help - Help Program
--out -file with the resulting table 
--n1  -minimum number of items in a random array
--n2  -maximum number of elements in a random array
--step -with which step will be to increase the number of items in a random array


	  
=head1 DESCRIPTION

Implemented several algorithms for sorting arrays (quadratic, Shell,
Hoare, pyramidal, mergers) and compared (the number of comparisons and the permutation
stability, time) between themselves and with the built-in sort.

=cut

	 