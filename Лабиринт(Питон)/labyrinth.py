from output import *;

class Labyrinth (Output):
	def __init__ (self, bombs, start_point, finish_point, maze, path):
		self.bombs = bombs;
		self.start_point = start_point;
		self.finish_point = finish_point;
		self.maze = maze;
		self.path = path;
	
	def get_path (self):
		graph = self.find_path();
		key_start_point = '%s - %s' % self.start_point;
		
		for  node in graph:
			if node.find (key_start_point) == 0:
				key_start_point = node;
				break;
		
			else : return;
			
		curr_node = tuple(graph[key_start_point]);
		self.path.append ([self.start_point[0], self.start_point[1]]);
		self.path.append (curr_node);
			
		while curr_node[:2] != self.finish_point:
			self.path.append (graph['%s - %s : %s' % curr_node]);
			curr_node = tuple(graph['%s - %s : %s' % curr_node]);
		
	
	def find_path (self):
		rows = len (self.maze);
		columns = len (self.maze[0]);
		dx = [1, -1, 0, 0];
		dy = [0, 0, -1, 1];
		result = [];
		graph = {};
		
		result.append ([self.finish_point[0], self.finish_point[1], self.bombs]);
		
		for curr_node in result:
			if curr_node == self.start_point : break;
			bombs = curr_node[2];
			
			for i in range(4):
				x = curr_node[0] + dx[i];
				y = curr_node[1] + dy[i];
			
				if 0 <= x < rows and 0 <= y < columns :
					if (x, y) != self.finish_point:
						if self.maze[x][y] == 0 or self.maze[x][y] == 1 and bombs > 0:
							if self.maze[x][y] == 1: bombs -= 1 ;
							
							node = '%s - %s : %s' % (x, y, bombs);
							if not node in graph:
								graph[node] = curr_node;
								result.append([x, y, bombs]);
							
		return graph;

		
		