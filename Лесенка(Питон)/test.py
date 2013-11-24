from ladder import *
import unittest
from unittest import TestCase, main

def check (ladder):
	if (ladder.chain[0] != ladder.initial or ladder.chain[-1] != ladder.target):
		return 0;

	for word in ladder.chain:
		if not word in ladder.dictionary: return 0;
	
	for i in range(len(ladder.chain)-1):
		if letter(ladder.chain[i], ladder.chain[i+1]) == 0: return 0;
	
	return 1;

def letter (word_1, word_2):
	res = 0;
	for i in range(len(word_1)):
		if word_1[i] != word_2[i]: res+=1;
		if (res > 1): return 0;
		
	return 1;

class LadderTestCase(TestCase):
	def test_1(self):
		ladder = Ladder("", "", {"aaa","aab","aac","aad","abc","bbb","ccc","abb","ddd","aa","ab","ac","ba","ad","bc","a","b","c","d"}, ["a","b","c","d"], []);
		ladder.build_chain();
		self.assertEquals(ladder.chain,[])
	def test_2(self):
		ladder = Ladder("aaa", "bbb", {"aaa","aab","aac","aad","abc","bbb","ccc","abb","ddd","aa","ab","ac","ba","ad","bc","a","b","c","d"}, ["a","b","c","d"], []);
		ladder.build_chain();
		self.assertNotEqual(ladder.chain, [])
	def test_3(self):
		ladder = Ladder("e", "k", {"aaa","aab","aac","aad","abc","bbb","ccc","abb","ddd","aa","ab","ac","ba","ad","bc","a","b","c","d"}, ["a","b","c","d"], []);
		ladder.build_chain();
		self.assertEquals(ladder.chain, [])
	def test_4(self):
		ladder = Ladder("aaa", "b", {"aaa","aab","aac","aad","abc","bbb","ccc","abb","ddd","aa","ab","ac","ba","ad","bc","a","b","c","d"}, ["a","b","c","d"], []);
		ladder.build_chain();
		self.assertEquals(ladder.chain, [])
	def test_5(self):
		ladder = Ladder("aaa", "bbb", {"aaa","aab","aac","aad","abc","bbb","ccc","abb","ddd","aa","ab","ac","ba","ad","bc","a","b","c","d"}, ["a","b","c","d"], []);
		ladder.build_chain();
		self.assertEquals(check(ladder), 1)
	def test_6(self):
		ladder = Ladder("a", "d", {"aaa","aab","aac","aad","abc","bbb","ccc","abb","ddd","aa","ab","ac","ba","ad","bc","a","b","c","d"}, ["a","b","c","d"], []);
		ladder.build_chain();
		self.assertEquals(check(ladder), 1)
	def test_7(self):
		ladder = Ladder("aaa", "aaa", {"aaa","aab","aac","aad","abc","bbb","ccc","abb","ddd","aa","ab","ac","ba","ad","bc","a","b","c","d"}, ["a","b","c","d"], []);
		ladder.build_chain();
		self.assertEquals(check(ladder), 1)
	def test_8(self):
		ladder = Ladder("aa", "bc", {"aaa","aab","aac","aad","abc","bbb","ccc","abb","ddd","aa","ab","ac","ba","ad","bc","a","b","c","d"}, ["a","b","c","d"], []);
		ladder.build_chain();
		self.assertEquals(check(ladder), 1)
    
if __name__ == '__main__':
    main()
