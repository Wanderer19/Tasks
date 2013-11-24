use locale;
use Input;
use Palindrom;
use Getopt::Long 2.24 qw( :config no_auto_abbrev no_ignore_case );

($output,$help,$input,$dictionary,$alphabet)=('-');
my $options_okay = GetOptions(
    'help|h' => \$help, 
    'in=s' => \$input,
    'out:s' => \$output,    
);

unless ($options_okay){
	print "Put the correct parameters, please!\n";
	exit;
}

if ($help) {
	print <DATA>;
	exit;
}
unless ($input){
	print "Put the correct parameters, please!\n";
	exit;
}
my $Text = Input::read_text($input); 
my $Palindroms = Palindrom::new_palindrome($Text);
open (my $Out,">$output") or die;
if (defined($$Palindroms[0])){
	print $Out "$_\n" for (@$Palindroms);
}
else{
	print"No palindroms =(";
}

__DATA__

[-h | --help] [--in , --out ] 

Parameters:

-h | -help - Help Program
-in - file with the input data
-out - file in which the result is written