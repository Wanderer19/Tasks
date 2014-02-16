using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Visualizer;

namespace TestingVisualizer
{
    [TestClass]
    public class TestingOfVisualizationHeap
    {
        [TestMethod]
        public void GetParent()
        {
            Assert.AreEqual(1, VisualizationHeap.GetParent(3));
            Assert.AreEqual(1, VisualizationHeap.GetParent(4));

            Assert.AreEqual(2, VisualizationHeap.GetParent(5));
            Assert.AreEqual(2, VisualizationHeap.GetParent(6));

            Assert.AreEqual(0, VisualizationHeap.GetParent(0));
        }

        [TestMethod]
        public void IsSelected()
        {
            var visualizationHeap = new VisualizationHeap(5);
            visualizationHeap.SelectNodes(1, 3, 4);

            Assert.IsTrue(visualizationHeap.IsSelected(1));
            Assert.IsTrue(visualizationHeap.IsSelected(3));
            Assert.IsTrue(visualizationHeap.IsSelected(4));

            Assert.IsFalse(visualizationHeap.IsSelected(0));
            Assert.IsFalse(visualizationHeap.IsSelected(2));

            visualizationHeap.SelectNode(0);

            Assert.IsTrue(visualizationHeap.IsSelected(1));
            Assert.IsTrue(visualizationHeap.IsSelected(3));
            Assert.IsTrue(visualizationHeap.IsSelected(4));
            Assert.IsTrue(visualizationHeap.IsSelected(0));

            Assert.IsFalse(visualizationHeap.IsSelected(2));

            visualizationHeap.SelectNodes(2);
            Assert.IsTrue(visualizationHeap.IsSelected(2));

            Assert.IsFalse(visualizationHeap.IsSelected(0));
            Assert.IsFalse(visualizationHeap.IsSelected(1));
            Assert.IsFalse(visualizationHeap.IsSelected(3));
            Assert.IsFalse(visualizationHeap.IsSelected(4));
        }

        [TestMethod]
        public void GetColor()
        {
            var visualizationHeap = new VisualizationHeap(4);
            visualizationHeap.SelectNodes(1, 3);

            Assert.AreEqual(VisualizationHeap.nodeColor, visualizationHeap.GetColorElement(0, -1));
            Assert.AreEqual(VisualizationHeap.nodeColor, visualizationHeap.GetColorElement(2, -1));
            Assert.AreEqual(VisualizationHeap.selectedNodeColor, visualizationHeap.GetColorElement(1, -1));
            Assert.AreEqual(VisualizationHeap.selectedNodeColor, visualizationHeap.GetColorElement(3, -1));

            Assert.AreEqual(VisualizationHeap.colorSortedPart, visualizationHeap.GetColorElement(1, 1));
            Assert.AreEqual(VisualizationHeap.colorSortedPart, visualizationHeap.GetColorElement(3, 2));
            Assert.AreEqual(VisualizationHeap.selectedNodeColor, visualizationHeap.GetColorElement(1, 2));
        }

        [TestMethod]
        public void GetCoordinatesNode()
        {
            var visualizationHeap = new VisualizationHeap(8);
            visualizationHeap.DefineCoordinates();
            var root = new Rectangle((int) (VisualizationHeap.rootsCoordinates.X) ,
                (int) VisualizationHeap.rootsCoordinates.Y,
                VisualizationHeap.NodesDiameter, VisualizationHeap.NodesDiameter);

            var nextNode1 = new Rectangle(root.X - VisualizationHeap.OffsetBetweenNeighbors, root.Y + VisualizationHeap.DistanceBetweenLevels, VisualizationHeap.NodesDiameter, VisualizationHeap.NodesDiameter);
            var nextNode2 = new Rectangle(root.X + VisualizationHeap.OffsetBetweenNeighbors, root.Y + VisualizationHeap.DistanceBetweenLevels, VisualizationHeap.NodesDiameter, VisualizationHeap.NodesDiameter);
            var nextNode3 = new Rectangle(nextNode1.X - VisualizationHeap.OffsetBetweenNeighbors / 2, nextNode1.Y + VisualizationHeap.DistanceBetweenLevels, VisualizationHeap.NodesDiameter, VisualizationHeap.NodesDiameter);
            var nextNode7 = new Rectangle(nextNode3.X - VisualizationHeap.OffsetBetweenNeighbors / 3, nextNode3.Y + VisualizationHeap.DistanceBetweenLevels, VisualizationHeap.NodesDiameter, VisualizationHeap.NodesDiameter);
            
            Assert.AreEqual(root, visualizationHeap.GetCoordinatesNode(0));
            Assert.AreEqual(nextNode1, visualizationHeap.GetCoordinatesNode(1));
            Assert.AreEqual(nextNode2, visualizationHeap.GetCoordinatesNode(2));
            Assert.AreEqual(nextNode3, visualizationHeap.GetCoordinatesNode(3));
            Assert.AreEqual(nextNode7, visualizationHeap.GetCoordinatesNode(7));
        }

        [TestMethod]
        public void GetCoordinatesValue()
        {
            var visualizationHeap = new VisualizationHeap(8);
            visualizationHeap.DefineCoordinates();


            Assert.AreEqual(Tuple.Create(new Point(), new Point()), visualizationHeap.GetCoordinatesValue(0));
            Assert.AreEqual(Tuple.Create(new Point(), new Point()), visualizationHeap.GetCoordinatesValue(1));
            Assert.AreEqual(Tuple.Create(new Point(), new Point()), visualizationHeap.GetCoordinatesValue(2));
            Assert.AreEqual(Tuple.Create(new Point(), new Point()), visualizationHeap.GetCoordinatesValue(3));
            Assert.AreEqual(Tuple.Create(new Point(), new Point()), visualizationHeap.GetCoordinatesValue(7));
        }

        [TestMethod]
        public void GetCoordinatesEdge()
        {
            var visualizationHeap = new VisualizationHeap(8);
            visualizationHeap.DefineCoordinates();


            Assert.AreEqual(new PointF(), visualizationHeap.GetCoordinatesEdge(0));
            Assert.AreEqual(new PointF(), visualizationHeap.GetCoordinatesEdge(1));
            Assert.AreEqual(new PointF(), visualizationHeap.GetCoordinatesEdge(2));
            Assert.AreEqual(new PointF(), visualizationHeap.GetCoordinatesEdge(3));
            Assert.AreEqual(new PointF(), visualizationHeap.GetCoordinatesEdge(7));
        }
    }
}
