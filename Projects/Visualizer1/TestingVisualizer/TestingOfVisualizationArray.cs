using System;
using System.Drawing;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Visualizer;

namespace TestingVisualizer
{
    [TestClass]
    public class TestingOfVisualizationArray
    {
        [TestMethod]
        public void GetCoordinates()
        {
            var visulizationArray = new VisualizationArray(5);
            visulizationArray.IdentifyCoordinates();
            
            Assert.AreEqual(new Point(3, 200), visulizationArray.GetCoordinates(0));
            Assert.AreEqual(new Point(203, 200), visulizationArray.GetCoordinates(2));
            Assert.AreEqual(new Point(403, 200), visulizationArray.GetCoordinates(4));
        }

        [TestMethod]
        public void IsSelected()
        {
            var visulizationArray = new VisualizationArray(8);
            visulizationArray.SelectElements(0, 2, 5, 7);

            Assert.IsTrue(visulizationArray.IsSelected(0));
            Assert.IsTrue(visulizationArray.IsSelected(5));
            Assert.IsTrue(visulizationArray.IsSelected(2));
            Assert.IsTrue(visulizationArray.IsSelected(7));

            Assert.IsFalse(visulizationArray.IsSelected(1));
            Assert.IsFalse(visulizationArray.IsSelected(3));
            Assert.IsFalse(visulizationArray.IsSelected(4));
            Assert.IsFalse(visulizationArray.IsSelected(6));
        }

        [TestMethod]
        public void GetColorElement()
        {
            var visulizationArray = new VisualizationArray(4);
            visulizationArray.SelectElements(0, 2);

            Assert.AreEqual(VisualizationArray.ElementColor, visulizationArray.GetColorElement(1, new Point(0, 0)));
            Assert.AreEqual(VisualizationArray.ElementColor, visulizationArray.GetColorElement(3, new Point(0, 0)));

            Assert.AreEqual(VisualizationArray.SelectedElementColor, visulizationArray.GetColorElement(2, new Point(0, 0)));
            Assert.AreEqual(VisualizationArray.ElementColor, visulizationArray.GetColorElement(1, new Point(-1, -1)));
            
            Assert.AreEqual(VisualizationArray.colorSortedPart, visulizationArray.GetColorElement(0, new Point(0, 0)));
            Assert.AreEqual(VisualizationArray.colorSortedPart, visulizationArray.GetColorElement(1, new Point(0, 2)));
            Assert.AreEqual(VisualizationArray.colorSortedPart, visulizationArray.GetColorElement(2, new Point(0, 2)));
        }
    }
}
