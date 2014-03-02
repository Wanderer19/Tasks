using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Visualizer;

namespace TestingVisualizer
{
    [TestClass]
    public class TestingOfArrayReader
    {
        [TestMethod]
        public void IsValidValuesElementsInArray()
        {
            Assert.IsTrue(ArrayReader.IsValidValuesElementsInArray(new int[] {-1, 2, 3, 45, 6}, 10, 100));
            Assert.IsTrue(ArrayReader.IsValidValuesElementsInArray(new int[] { -100, 200, 3, 45, 6 }, 5, 1000));
            Assert.IsTrue(ArrayReader.IsValidValuesElementsInArray(new int[] { -10, 20, 30, 45, 60 }, 6, 100));

            Assert.IsFalse(ArrayReader.IsValidValuesElementsInArray(new int[] { -10, 20, 30, 45, 60 }, 6, 10));
            Assert.IsFalse(ArrayReader.IsValidValuesElementsInArray(new int[] { -10, 20, 30, 45, 60 }, 2, 100));
            Assert.IsFalse(ArrayReader.IsValidValuesElementsInArray(new int[] { -1000, 2000, 30, 45, 60 }, 20, 1000));
            Assert.IsFalse(ArrayReader.IsValidValuesElementsInArray(new int[] { -100, 20, 30, 45, 60 }, 2, 100));
        }

        [TestMethod]
        public void ReadDataTest1()
        {
            var expectedArray = new[] {1, 2, 3, 4, 5};
            var actualArray = ArrayReader.ReadData("1 2 3 4 5");

            Assert.IsTrue(ArrayEquals(expectedArray, actualArray));
        }

        [TestMethod]
        public void ReadDataTest2()
        {
            var expectedArray = new[] { 1, 2, 3, 4, 50, -10, 0 };
            var actualArray = ArrayReader.ReadData("1\n\n 2 3 4 50     -10\n 0");

            Assert.IsTrue(ArrayEquals(expectedArray, actualArray));
        }

        [TestMethod]
        public void ReadDataTest3()
        {
            var expectedArray = new[] { 1, 2, 3, 4, 50, -10, 0 };
            var actualArray = ArrayReader.ReadData("1\n\n 2 3 4 50     -10\n 00000");

            Assert.IsTrue(ArrayEquals(expectedArray, actualArray));
        }

        [TestMethod]
        public void ReadDataTest4()
        {
            var expectedArray = new int[] {};
            var actualArray = ArrayReader.ReadData("1\n\n 2 3 4 50     ---10\n 00000");

            Assert.IsTrue(ArrayEquals(expectedArray, actualArray));
        }

        [TestMethod]
        public void ReadDataTest5()
        {
            var expectedArray = new int[] { };
            var actualArray = ArrayReader.ReadData("1 2 2938 je83 ff-93");

            Assert.IsTrue(ArrayEquals(expectedArray, actualArray));
        }

        public bool ArrayEquals(int[] expectedArray, int[] actualArray)
        {
            if(expectedArray.Length != actualArray.Length)
             return false;

            return !expectedArray.Where((t, i) => t != actualArray[i]).Any();
        }

    }
}
