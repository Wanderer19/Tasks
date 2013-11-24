use Build;
use locale;
use input;
use Tk;
use Pod::Usage;
use Getopt::Long 2.24 qw( :config no_auto_abbrev no_ignore_case );

my ($output,$help,$man,$input,$dictionary,$alphabet)=('-');
my $options_okay = GetOptions(
    'help|h' => \$help, 
	'man' => \$man,
    'in=s' => \$input,
    'dict=s' => \$dictionary,
	'alph=s' => \$alphabet,
    'out:s' => \$output,
    
);	

pod2usage( -exitval => 2, -verbose => 0 ) unless $options_okay;
pod2usage( 1 ) if $help;
pod2usage( -exitval => 0, -verbose => 2 ) if $man;
pod2usage(
    -exitval => 2,
    -message => 'You have set incorrect parameters!',
    -verbose => 0,
) unless ($input && $dictionary && $alphabet);	

		    
my ($Initial, $Target) = read_initial_target($input);
my ($vocabulary) = read_dictionary($dictionary,length $Initial);
my ($alph) = red_alphabet($alphabet);
my $chain = form($vocabulary,$Initial,$Target,$alph);
my $mw = MainWindow->new();
	 
unless ( @$chain ){

    
	my $img=$mw->Photo(-file => "1055.gif");
    $mw->Label(-image => $img)->pack;
	
	MainLoop();    
	
	exit;
}
			
open (my $COUT,">$output") or die "\nMistake at opening the document $output\n";
print $COUT "$_\n"  foreach ( @$chain );
close ($COUT) or die "\nMistake at closing the document $output\n"; 

my $img=$mw->Photo(-file => "5.gif");
$mw->Label(-image => $img)->pack;
MainLoop();   
     
__END__
 
=head1 NAME

lecenka.pl

=head1 SYNOPSIS

lecenka.pl [-h | --help] [--in , --dict , --out, --alph) ] 

Parameters:
  
-h | --help - Help Program
--in - file with the input data
-out - file in which the result is written
-dictt - dictionary
-alph- file in which the alphabet on which the dictionary is made is written down

	  
=head1 DESCRIPTION

Input: the original word , the target word  and a dictionary.
Output: chain-letter changes, allowing us to obtain from the
the original target words, each intermediate step is also
be a word (i.e., present in the dictionary).

=cut
	