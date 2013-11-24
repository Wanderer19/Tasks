import sys
import optparse
from labyrinth import *
from input import *
from output import *;

parser=optparse.OptionParser()
parser.add_option('-i', '--inp', help='file with the input data', type='string')
parser.add_option('-o', '--out', help='file in which the result is written', type='string')
parser.add_option('-v', '--vis', help='visualize', action="store_true", default=False)
options, args=parser.parse_args()

if not options.inp:
    parser.error('Input file is not given');

if options.out:
	sys.stdout = open (options.out,"w");
	

(bombs, start_point, finish_point, maze) = input (options.inp);

labyrinth = Labyrinth(bombs, start_point, finish_point, maze, []);
labyrinth.get_path();
labyrinth.visualize_path();
