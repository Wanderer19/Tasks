use Tk;
use Term::ReadKey;
use Pod::Usage;
use Getopt::Long 2.24 qw(:config no_auto_abbrev no_ignore_case);
use input;
use labyrinth;
use output;

my ($Output, $Input) = ('-');
my $OptionsOkay = GetOptions(
    'help|h' => \$Help,
    'man' => \$Man,
    'in=s' => \$Input,
    'out:s' => \$Output,
    'visual|vis' => \$Visual,
);

pod2usage(-exitval => 2, -verbose => 0) unless $OptionsOkay;
pod2usage(1) if $Help;
pod2usage(-exitval => 0, -verbose => 2) if $Man;
pod2usage(
    -exitval => 2,
    -message => 'You have set incorrect parameters!',
    -verbose => 0,
) unless ($Input);

my $Labyrinth = ReadLabyrinth labyrinth ($Input);
pod2usage(
    -exitval => 2,
    -verbose => 99,
    -message => "You entered invalid data!\n",
    -sections => "INCORRECT",
) unless (defined ($Labyrinth));

my $Path =  $Labyrinth->GetThePath();
if ($Visual){
	$Labyrinth->PrintPathVisual($Path);
}
else{
	$Labyrinth->PrintPathUnvisual($Path, $Output);
}

__END__
     
=head1 NAME
     
labyrinth.pl
     
=head1 SYNOPSIS
     
labyrinth.pl [--help|-h] [--man] [--in (file)] [--out (file)] [--visual|--vis]
     
=head1 OPTIONS

=over 8
     
=item B<--help|-h>
	
Print a brief help message and exit.
     
=item B<--man>

Prints the manual page and exit.

=item B<--in (file)>

The input file, which should be:
    1 - 2 lines contain the coordinates of the entrance to the labyrinth,
    3-4 lines contain the coordinates of the exit out of the labyrinth,
    5 string contains a number of bombs,
    in the following lines contain the labyrinth itself.

=item B<--out (file)>
	
File, which is written in the output of the program (the path from input to output in the maze, if such a path exists). If you do not specify a file, the result will indicate to the console.

=item B<--visual|--vis>
Option, which visualizes result of the program.     

=back
     
=head1 DESCRIPTION
     
Input: a file with the description of a labyrinth, an initial position, a position of an output from
Labyrinth and number of bombs.
Output: the shortest way from an input up to an output.
The note: the bomb is capable to destroy one wall (i.e. to make
The adjacent two next cells divided by a wall).

     
    
=head1 INCORRECT

A sample input file:

5 (Height labyrinth)

6 (Width of the labyrinth)

1 (the first coordinate of the entrance to the labyrinth)

5 (the second coordinate of the entrance to the labyrinth)

0 (the first coordinate of the exit of the labyrinth)

0 (the second coordinate of the exit of the labyrinth)

2 (number of bombs)

011110     

011010     

010010     

000010     

000000

(1 is a wall, 0 is the free cell.Remember! In the labyrinth must not be empty spaces (without the 0 and 1), and input and output in the labyrinth must be set to 0.)

=head1 AUTHOR

Maria Telyatnikova <mashatelatnikova@gmail.com>
=cut
	