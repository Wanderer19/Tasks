class Input:
	def read_initial_target (self, input_file) :
		words = open (input_file);
		(self.initial, self.target) = (words.read()).split();
	
	def red_alphabet (self, alph):
		alphabet = open (alph);
		self.alphabet = (alphabet.read()).split();
		
	def read_dictionary (self, dict, length) :
		dictionary = open (dict);
		dict = (dictionary.read()).split();
	
		for word in dict :
			if len(word) == length :
				self.dictionary[word] = 1;
	 
