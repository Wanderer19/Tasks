from labyrinth import *

def input (input_file):
	descriptor_maze = open (input_file);
	bombs = int (descriptor_maze.readline());
	start_point = tuple (map (int, (descriptor_maze.readline()).split()));
	finish_point = tuple (map (int, (descriptor_maze.readline()).split()));
	maze = [];
	
	for line in descriptor_maze:
		maze.append ([int(i) for i in list(line.rstrip())]);
	
	return (bombs, start_point, finish_point, maze);
	