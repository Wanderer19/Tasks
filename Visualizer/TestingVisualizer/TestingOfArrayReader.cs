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
        public void IsValidInputString()
        {
            Assert.IsTrue(ArrayReader.IsValidInputString("1 2 3"));
            Assert.IsTrue(ArrayReader.IsValidInputString("1    -4   4 5 6    \n 7"));
            Assert.IsTrue(ArrayReader.IsValidInputString("1\n2\n3\n4\n5\n\n\n      6666 7718\n9   0"));

            Assert.IsFalse(ArrayReader.IsValidInputString("1 2334 nfjwkrL"));
            Assert.IsFalse(ArrayReader.IsValidInputString("1\n2\n3\n4\n  6 +9 * h"));

        }

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
