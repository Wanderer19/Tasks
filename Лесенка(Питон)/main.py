import sys
import optparse
from input import *
from ladder import *

parser=optparse.OptionParser()
parser.add_option('-i', '--inp', help='file with the input data', type='string')
parser.add_option('-o', '--out', help='file in which the result is written', type='string')
parser.add_option('-d', '--dict', help='dictionary', type='string')
parser.add_option('-a', '--alph', help='dfile in which the alphabet on which the dictionary is made is written down', type='string')
options, args=parser.parse_args()

if not options.inp :
    parser.error ('Input file is not given')
if not options.dict :
    parser.error ('Dictionary is not given')
if not options.alph :
    parser.error ('Alphabet is not given')

ladder = Ladder("", "", {}, [], []);
ladder.input(options.inp, options.alph, options.dict);
ladder.build_chain();
ladder.visualize(options.out);
