class Output:
	def visualize_path (self):
		rows = len (self.maze);
		columns = len (self.maze[0]);
		
		if self.path != []:
			for coordinates in self.path:
				print (coordinates[0], " - ", coordinates[1]);
			
			path = [ (i[0], i[1]) for i in self.path];
			maze = self.maze[0:];
			
			for i in range(rows):
				for j in range(columns):
					if (i,j) in path :
						if not maze[i][j]: 
							maze[i][j] = "#";
						else: 
							maze[i][j] = "*";
					else:
						maze[i][j] = str (maze[i][j]);
			for i in maze:
				print (('{:5}'*columns).format(*i))
		
		else: 
			print ("You shall not pass!");
		
	

	