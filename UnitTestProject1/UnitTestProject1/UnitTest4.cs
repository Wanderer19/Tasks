using System;
using System.Collections.Generic;
using ConsoleApplication1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class PrinterTest4
    {
        [TestMethod]
        public void GetResultTest1()
        {
            var reply = new List<int>(){1,2,6,10, 15};
           
            Assert.AreEqual("1,2,6,10,15", Printer.GetResult(reply, ",", 20));
        }

        [TestMethod]
        public void GetResultTest2()
        {
            var reply = new List<int>() { 1, 2, 6, 10, 15 };

            Assert.AreEqual("1,2,6,10", Printer.GetResult(reply, ",", 4));
        }
    }
}
