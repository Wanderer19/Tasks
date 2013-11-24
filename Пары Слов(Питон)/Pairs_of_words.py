import sys
import optparse
from input import *
from pairs import *

parser=optparse.OptionParser()
parser.add_option('-t', '--text', help='text in Russian, in which you find the most common pair of words', type='string')
parser.add_option('-o', '--out', help='file in which the result is written', type='string')
parser.add_option('-n', '--nw', help='list is not words	', type='string')
parser.add_option('-c', '--count', help='quantity of pairs on an output of the program', type='int',default = 5)
options, args=parser.parse_args()

if not options.text:
    parser.error('Input file is not given')
if not options.nw:
    parser.error('Not Words is not given')

Text = red_text (options.text);
List = read_not_words (options.nw);

if options.out:
	sys.stdout = open (options.out,"w");
	
PairsList = pairs_of_words(Text, List); 
print ("\n".join(PairsList[:options.count]));

