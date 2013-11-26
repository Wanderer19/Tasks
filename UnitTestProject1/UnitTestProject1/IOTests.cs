using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class IOTests
    {
        [TestMethod]
        public void ReadFileTest()
        {
            string fname = "../../TestFiles/simple.txt";
            string[] lines = File.ReadAllLines(fname);
            string[] expected = new[] {"qwerty 123"};
            Assert.AreEqual(expected[0], lines[0]);
            
        }
    }


}
