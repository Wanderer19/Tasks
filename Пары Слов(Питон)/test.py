from pairs import *
import unittest
from unittest import TestCase, main

def check (expected, actual) :
	print (actual);
	quantities_from_actual = [];
	for i in actual :
		a = i.split(" : ");
		quantities_from_actual.append(a[1]);
	
	if (descending(quantities_from_actual) == 0) :
		return 0;
	
	if (equal(actual,expected) == 0) :
		return 0;
	return 1;

def descending (array) :
	for i in range(len(array)-1) :
		if int(array[i]) < int(array[i+1]) : return 0;
	    
	return 1;

def equal (actual, expected):
	actual.sort();
	expected.sort();
	
	if actual != expected : return 0;
	return 1;

class PairsWordsTestCase(TestCase):
	def test_1(self):
		self.assertEquals(check(['eye - see : 2','feel - heart : 1','feel - ones : 1','feel - sink : 1','get - hand : 1','get - of : 1','get - out : 1','hand - of : 1','hand - out : 1','heart - ones : 1','heart - sink : 1','of - out : 1','eye - eye : 1','ones - sink : 1'],pairs_of_words("To see eye to eye.To get out of hand!To feel ones heart sink.",{'easy','to'})),1)
	def test_2(self):
		self.assertEquals(pairs_of_words("Easy come.Easy go",{"easy","to"}),[])
	def test_3(self):
		self.assertEquals(pairs_of_words("",{"easy","to"}),[])
	def test_4(self):
		self.assertEquals(pairs_of_words("To see eye to eye.Easy come,easy go!",{'to','see','eye','easy','come','go'}),[])
	def test_5(self):
		self.assertEquals(pairs_of_words("a b a a c.A b a",{'a','b','c'}),[])
	def test_6(self):
		self.assertEquals(check(['does - it : 2'],pairs_of_words("It does not make sense.You does not must doing it!",{"not","make","sense","you","must","doing"})),1)
	def test_7(self):
		self.assertEquals(check(['aa - bb : 2','aa - cd : 1'],pairs_of_words("aa bb k .Aa b CD!AA jjd  bB?",{"b","k","jjd"})),1)
	def test_8(self):
		self.assertEquals(check(['a - b : 1','a - c : 1','b - c : 1'],pairs_of_words("a b c",{})),1)
	def test_9(self):
		self.assertEquals(check(['a - b : 1','a - c : 1','b - c : 1'],pairs_of_words("a c b",{})),1)
	def test_10(self):
		self.assertEquals(check(['a - a : 6'],pairs_of_words("a a a a",{})),1)
	def test_11(self):
		self.assertEquals(check(['aa - aa : 3'],pairs_of_words("AA aa Aa",{})),1)
	def test_12(self):
		self.assertEquals(check(['a - b : 5','a - a : 4','a - c : 3','b - c : 1'],pairs_of_words("a b a a c.A b a",{})),1)
	def test_13(self):
		self.assertEquals(check(['ab - c : 1','d - e : 1'],pairs_of_words("ab c.\n\ne d?",{})),1)
	def test_14(self):
		self.assertEquals(check(['a - a : 70'],pairs_of_words("a a a a a a         a A a A A .\n\n\na a a a A    A?b a!",{'b'})),1)
	def test_15(self):
		self.assertEquals(check(['A - a : 70'],pairs_of_words("a a a a a a         a A a A A .\n\n\na a a a A    A?b a!",{'b'})),0)
	def test_16(self):
		self.assertEquals(check(['a - c : 1', 'a - b : 2', 'a - c : 1'],pairs_of_words("a b. a b. a c", {})),0)
	def test_17(self):
		self.assertEquals(check(['a - b : 2','a - c : 1'],pairs_of_words("a b. a b. a c", {})),1)

if __name__ == '__main__':
    main()