import re;

def pairs_of_words (Text, List):
	AllSentences = re.split('[\.!\?]+', Text);
	PairsList = {};
	
	for i in AllSentences:
		new_pair(GetWords(i, List), PairsList);
	
	return [i +" : " +str(PairsList[i]) for i in max(PairsList)];


def GetWords (Sentence, List):
	AllWords = re.split('[^\w]+',Sentence);
	return [i.lower() for i in AllWords if   i != ""  and not i.lower() in List];
	
	
def max (PairsList):
	Keys = list(PairsList.keys());
	return sorted(Keys, key = PairsList.__getitem__, reverse = True);

	
def new_pair (Words, PairsList):
	Frequency = {};
	Word = [];
	Amount = 0;
	
	for i in  Words:
		Frequency[i] = Frequency.get(i,0) + 1;
	
	Word = list(Frequency.keys());
	Word.sort();
	
	for i in range(len(Word)):
		Amount = (Frequency[Word[i]])*(Frequency[Word[i]]-1)//2;
		if (Amount):
			PairsList[Word[i] + " - " + Word[i]] = PairsList.get(Word[i] + " - " + Word[i], 0) + Amount;
		
		for j in range(i+1,len(Word)):
			PairsList[Word[i] + " - " + Word[j]] = PairsList.get(Word[i] + " - " + Word[j], 0) + Frequency[Word[i]]*Frequency[Word[j]];
		
		
	return PairsList;


   
	