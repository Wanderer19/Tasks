from input import *
import sys

class Ladder (Input) :
	def __init__ (self, initial, target, dictionary, alphabet, chain) :
		self.initial = initial;
		self.target = target;
		self.dictionary = dictionary;
		self.alphabet = alphabet;
		self.chain = chain;
	
	def input (self, inp, alph, dict) :
		self.read_initial_target (inp);
		self.red_alphabet (alph);
		self.read_dictionary (dict, len(self.initial));
		
	def build_chain (self) :
		graph = self.get_graph();
	
		if not self.initial in graph :
			return;
	 
		curr_node = graph[self.initial]; 
		self.chain.append (self.initial);
		self.chain.append (curr_node);
	 
		while curr_node != self.target :
			self.chain.append (graph[curr_node]);
			curr_node = graph[curr_node];

	def get_graph (self) :
		tmp = [];
		graph = {};
	
		tmp.append(self.target);
		for curr_node in tmp:     
			for i in range (len(curr_node)) :
				for letter in self.alphabet : 
					node = curr_node[:i] + letter + curr_node[i + 1:];
	            
					if node in self.dictionary and not node in graph :
						graph[node] = curr_node;
						tmp.append (node);
		
		return graph;
	
	def visualize (self, output_file) :
		if output_file :
			sys.stdout = open (output_file, "w");
		print ("\n".join(self.chain));
	