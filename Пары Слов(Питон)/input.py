def red_text (Text):
	TEXT = open (Text);
	Text = TEXT.read();
	return Text;

def read_not_words (NotWords):
	NW = open (NotWords);
	NotWords = (NW.read()).split();
	List = {};
	
	for i in NotWords:
		List[i.lower()] = 1;
	
	return List;
