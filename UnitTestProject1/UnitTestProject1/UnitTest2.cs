using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApplication1;

namespace UnitTestProject1
{
   
    [TestClass]
    public class ParserTest
    {
        [TestMethod]
        public void SplitToWordTest()
        {
            string str = "qwerty 123 asdf";
            var parser = new TextParser();
            var words=parser.SplitToWords(str);
            var expected = new string[] {"qwerty", "123", "asdf"};
            Assert.IsTrue(ArrayEquals(expected, words));
            
           
        }

        [TestMethod]
        public void SplitToWord_1word_Test()
        {
            string str = "qwerty";
            var parser = new TextParser();
            var words = parser.SplitToWords(str);
            var expected = new string[] { "qwerty" };
            Assert.IsTrue(ArrayEquals(expected, words));


        }

        [TestMethod]
        public void SplitToWord_0word_Test()
        {
            string str = "";
            var parser = new TextParser();
            var words = parser.SplitToWords(str);
            var expected = new string[] { };
            Assert.IsTrue(ArrayEquals(expected, words));


        }

        [TestMethod]
        public void BuildInvertIndexTest()
        {
            var allLines = new List<List<string>>()
            {
                new List<string>() {"123", "abcd", "eee"},
                new List<string>() {"awaw", "abcd", "iii", "ewrjhgbw"},

            };

            var parser = new TextParser();

            var actualInvertIndex = parser.BuildInvertIndex(allLines);
            var linesNums = actualInvertIndex["abcd"];
            Assert.AreEqual(linesNums[0],0);
            Assert.AreEqual(linesNums[1], 1);

            //Assert.AreEqual(actualInvertIndex["abcd"],new List<int>(){0,1});
            
        }

        [TestMethod]
        public void BuildInvertIndexTest_wordIn1Line()
        {
            var allLines = new List<List<string>>()
            {
                new List<string>() {"123", "abcd", "eee"},
                new List<string>() {"awaw", "abcd", "iii", "ewrjhgbw"},

            };

            var parser = new TextParser();

            var actualInvertIndex = parser.BuildInvertIndex(allLines);
            var linesNums = actualInvertIndex["iii"];
            Assert.AreEqual(linesNums[0], 1);


            //Assert.AreEqual(actualInvertIndex["abcd"],new List<int>(){0,1});

        }


        [TestMethod]
        public void BuildInvertIndexTest_empty()
        {
            var allLines = new List<List<string>>()
            {
                new List<string>() {"123", "abcd", "eee"},
                new List<string>() {"awaw", "abcd", "iii", "ewrjhgbw"},

            };

            var parser = new TextParser();

            var actualInvertIndex = parser.BuildInvertIndex(allLines);
            Assert.IsFalse(actualInvertIndex.ContainsKey("q"));
            Assert.IsFalse(actualInvertIndex.ContainsKey(""));

        }

        public static bool ArrayEquals(string[] expectedLines, string[] actualLines)
        {
            if (expectedLines.Length != actualLines.Length)
                return false;

            for (int i = 0; i < expectedLines.Length; ++i)
            {
                if (expectedLines[i] != actualLines[i])
                    return false;
            }

            return true;
        }


    }
}
