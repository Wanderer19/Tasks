use input;
use pairs;
use Pod::Usage;
use Getopt::Long 2.24 qw( :config no_auto_abbrev no_ignore_case );

my ($count,$output,$help,$man,$text,$not_words)=(5,'-');
my $options_okay = GetOptions(
    'help|h' => \$help, 
	'man' => \$man,
    'text=s' => \$text,
    'nw=s' => \$not_words,
    'out:s' => \$output,
    'count:i' => \$count
);

pod2usage( -exitval => 2, -verbose => 0 ) unless $options_okay;
pod2usage( 1 ) if $help;
pod2usage( -exitval => 0, -verbose => 2 ) if $man;
pod2usage(
    -exitval => 2,
    -message => 'You have set incorrect parameters!',
    -verbose => 0,
) unless ($text && $not_words);
	
my $sentence = read_text($text);
my $list = read_not_words($not_words);
my $pairs_list = pairs_of_words($sentence,$list);   

open ( my $OUTP,">$output" ) or die "\nMistake at opening the document $output\n";
print $OUTP "$$pairs_list[$_][0] - $$pairs_list[$_][1]\n" for(0..$count-1);


__END__
 
=head1 NAME

Pairs_words.pl

=head1 SYNOPSIS

Pairs_words.pl [-h | --help] [--text , --nw , --out, --count) ] 

Parameters:
  
-h | --help - Help Program
	  
--text - text in Russian, in which you find the most common pair of words
	  
--nw - list is not words	
	  
--out - file where the output of the program is written
	  
--count - quantity of pairs on an output of the program

	  
=head1 DESCRIPTION

Input: Text in Russian, and a file containing a list of "no words."
The program builds a list of the most frequent word pairs,
used in the same sentence (sentence), and the words can be
in any order in the sentence. Consideration of the words
excludes all the words in the list of "no words."

=cut


