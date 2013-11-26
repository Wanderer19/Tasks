using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApplication1;

namespace UnitTestProject1
{
    [TestClass]
    public class FinderTest3
    {
        [TestMethod]
        public void FindTest1()
        {
            var invertIndex = new Dictionary<string, List<int>>()
            {
                {"foo", new List<int>() {0, 1}},
                {"bar", new List<int>() {0, 1}},
                {"bazz", new List<int>() {1}},
                {"foobar", new List<int>() {2}}
            };

            var finder = new Finder();
            var request = new string[] {"foo", "foo", "foo", "foo"};
            var actual = finder.Find(invertIndex, request);

            var expected = new List<int>(){0, 1};
            Assert.IsTrue(expected.SequenceEqual(actual));
        }
    }
}
