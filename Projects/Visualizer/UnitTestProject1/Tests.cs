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
	
	[TestClass]
    public class TestingOfAutomatonHeapSort
    {
        [TestMethod]
        public void DoStepForward()
        {
            var automate = new AutomatonHeapSort(new[] {-1, 0, 2});

            var state = automate.DoStepForward();
            Assert.AreEqual((int)AutomatonSiftDown.States.Loop, state.StateId);
            Assert.AreEqual(0, state.SiftingElement);

            state = automate.DoStepForward();
            Assert.AreEqual((int)AutomatonSiftDown.States.ConditionOnUpdateMaximumChild, state.StateId);

            state = automate.DoStepForward();
            Assert.AreEqual((int)AutomatonSiftDown.States.EndingConditionOnUpdateMaximumChild, state.StateId);

            state = automate.DoStepForward();
            Assert.AreEqual((int)AutomatonSiftDown.States.ConditionOnUpdateParent, state.StateId);

            state = automate.DoStepForward();
            Assert.AreEqual((int)AutomatonSiftDown.States.SwappingParentWithMaximumChild, state.StateId);

            state = automate.DoStepForward();
            Assert.AreEqual((int)AutomatonSiftDown.States.Loop, state.StateId);

            state = automate.DoStepForward();
            Assert.AreEqual((int)AutomatonHeapSort.States.SwappingElements, state.StateId);

            state = automate.DoStepForward();
            Assert.AreEqual((int)AutomatonSiftDown.States.Loop, state.StateId);

            state = automate.DoStepForward();
            Assert.AreEqual((int)AutomatonSiftDown.States.ConditionOnUpdateMaximumChild, state.StateId);

            state = automate.DoStepForward();
            Assert.AreEqual((int)AutomatonSiftDown.States.EndingConditionOnUpdateMaximumChild, state.StateId);

            state = automate.DoStepForward();
            Assert.AreEqual((int)AutomatonSiftDown.States.ConditionOnUpdateParent, state.StateId);

            state = automate.DoStepForward();
            Assert.AreEqual((int)AutomatonSiftDown.States.SwappingParentWithMaximumChild, state.StateId);

            state = automate.DoStepForward();
            Assert.AreEqual((int)AutomatonSiftDown.States.Loop, state.StateId);

            state = automate.DoStepForward();
            Assert.AreEqual((int)AutomatonHeapSort.States.SwappingElements, state.StateId);

            state = automate.DoStepForward();
            Assert.AreEqual((int)AutomatonSiftDown.States.Loop, state.StateId);

            state = automate.DoStepForward();
            Assert.AreEqual((int)AutomatonHeapSort.States.FinalState, state.StateId);

        }
    }
	
	[TestClass]
    public class TestingOfBubbleSortAutomaton
    {
        [TestMethod]
        public void DoStepForward1()
        {
            var automaton = new AutomatonBubbleSort(new[] {1, -2, 4});

            var state = automaton.DoStepForward();

            while (state.StateId != (int) AutomatonBubbleSort.States.FinalState)
            {
                state = automaton.DoStepForward();
            }

            Assert.IsTrue(ArrayEquals(new [] {-2, 1, 4}, state.Array));
        }

        [TestMethod]
        public void DoStepForward2()
        {
            var automaton = new AutomatonBubbleSort(new[] { -1, 2, 3, 4, 5 });

            var state = automaton.DoStepForward();

            while (state.StateId != (int)AutomatonBubbleSort.States.FinalState)
            {
                state = automaton.DoStepForward();
            }

            Assert.IsTrue(ArrayEquals(new[] { -1, 2, 3, 4, 5 }, state.Array));
        }

        [TestMethod]
        public void DoStepForward3()
        {
            var automaton = new AutomatonBubbleSort(new[] { -1});

            var state = automaton.DoStepForward();

            while (state.StateId != (int)AutomatonBubbleSort.States.FinalState)
            {
                state = automaton.DoStepForward();
            }

            Assert.IsTrue(ArrayEquals(new[] { -1}, state.Array));
        }

        [TestMethod]
        public void DoStepForward4()
        {
            var automaton = new AutomatonBubbleSort(new[] { -1, 2, 0 });

            var state = automaton.DoStepForward();

            Assert.AreEqual((int)AutomatonBubbleSort.States.Condition, state.StateId);
            Assert.IsTrue(ArrayEquals(new[] { -1, 2, 0 }, state.Array));
            Assert.IsTrue(ArrayEquals(new [ ] {0, 1 }, state.SelectedElements.ToArray()));

            state = automaton.DoStepForward();

            Assert.AreEqual((int) AutomatonBubbleSort.States.Condition, state.StateId);
            Assert.IsTrue(ArrayEquals(new[] { -1, 2, 0 }, state.Array));
            Assert.IsTrue(ArrayEquals(new[] { 1, 2 }, state.SelectedElements.ToArray()));

            state = automaton.DoStepForward();

            Assert.AreEqual((int)AutomatonBubbleSort.States.SwappingAdjacentElements, state.StateId);
            Assert.IsTrue(ArrayEquals(new[] { -1, 0, 2 }, state.Array));
            Assert.IsTrue(ArrayEquals(new[] { 1, 2 }, state.SelectedElements.ToArray()));

            state = automaton.DoStepForward();

            Assert.AreEqual((int)AutomatonBubbleSort.States.Condition, state.StateId);
            Assert.IsTrue(ArrayEquals(new[] { -1, 0, 2 }, state.Array));
            Assert.IsTrue(ArrayEquals(new[] { 0, 1 }, state.SelectedElements.ToArray()));
            state = automaton.DoStepForward();

            Assert.AreEqual((int)AutomatonBubbleSort.States.Condition, state.StateId);
            Assert.IsTrue(ArrayEquals(new[] { -1, 0, 2 }, state.Array));
            Assert.IsTrue(ArrayEquals(new[] { 1, 2 }, state.SelectedElements.ToArray()));
            
            state = automaton.DoStepForward();

            while (state.StateId != (int) AutomatonBubbleSort.States.FinalState)
            {
                Assert.AreEqual((int)AutomatonBubbleSort.States.Condition, state.StateId);
                state = automaton.DoStepForward();
            }

            automaton.DoStepForward();
            Assert.AreEqual((int)AutomatonBubbleSort.States.FinalState, state.StateId);

            automaton.DoStepForward();
            Assert.AreEqual((int)AutomatonBubbleSort.States.FinalState, state.StateId);
            Assert.IsTrue(ArrayEquals(new[] { -1, 0, 2 }, state.Array));
        }

        [TestMethod]
        public void Steps()
        {
            var automaton = new AutomatonBubbleSort(new[] { -1, 2, 0 });

            var state = automaton.DoStepBackward();
            Assert.AreEqual(-1, state.StateId);
            
            state = automaton.DoStepForward();
            state = automaton.DoStepForward();
            state = automaton.DoStepForward();

            state = automaton.DoStepBackward();
            Assert.AreEqual((int)AutomatonBubbleSort.States.Condition, state.StateId);
            Assert.IsTrue(ArrayEquals(new[] { -1, 2, 0 }, state.Array));
            Assert.IsTrue(ArrayEquals(new[] { 1, 2 }, state.SelectedElements.ToArray()));
            
            state = automaton.DoStepBackward();
            Assert.AreEqual((int)AutomatonBubbleSort.States.Condition, state.StateId);
            Assert.IsTrue(ArrayEquals(new[] { -1, 2, 0 }, state.Array));
            Assert.IsTrue(ArrayEquals(new[] { 0, 1 }, state.SelectedElements.ToArray()));

            state = automaton.DoStepForward();
            state = automaton.DoStepForward();
            state = automaton.DoStepForward();

            state = automaton.DoStepBackward();
            Assert.AreEqual((int)AutomatonBubbleSort.States.SwappingAdjacentElements, state.StateId);
            Assert.IsTrue(ArrayEquals(new[] { -1, 0, 2 }, state.Array));
            Assert.IsTrue(ArrayEquals(new[] { 1, 2 }, state.SelectedElements.ToArray()));

            state = automaton.DoStepBackward();
            state = automaton.DoStepBackward();
            Assert.AreEqual((int)AutomatonBubbleSort.States.Condition, state.StateId);
            Assert.IsTrue(ArrayEquals(new[] { -1, 2, 0 }, state.Array));
            Assert.IsTrue(ArrayEquals(new[] { 0, 1 }, state.SelectedElements.ToArray()));
        }
       
        public bool ArrayEquals(int[] expectedArray, int[] actualArray)
        {
            if (expectedArray.Length != actualArray.Length)
                return false;

            return !expectedArray.Where((t, i) => t != actualArray[i]).Any();
        }
    }
	
	[TestClass]
    public class TestingOfSelectionSortAutomaton
    {
        [TestMethod]
        public void DoStepForward()
        {
            var automate = new AutomatonSelectionSort(new[] {-1, 2, 0});

            var state = automate.DoStepForward();
            
            Assert.AreEqual((int)AutomatonSelectionSort.States.InitializeIndexMinimum, state.StateId);
            Assert.AreEqual(-1, state.Minimum);

            state = automate.DoStepForward();
            Assert.AreEqual((int) AutomatonSelectionSort.States.Condition, state.StateId);
            Assert.IsTrue(ArrayEquals(new []{1}, state.SelectedElements.ToArray()));

            state = automate.DoStepForward();
            Assert.AreEqual((int)AutomatonSelectionSort.States.Condition, state.StateId);
            Assert.IsTrue(ArrayEquals(new [] {2}, state.SelectedElements.ToArray()));

        }

        [TestMethod]
        public void Steps1()
        {
            var automate = new AutomatonSelectionSort(new[] {-1});

            var state = automate.DoStepForward();
            Assert.AreEqual((int)AutomatonSelectionSort.States.FinalState, state.StateId);

            state = automate.DoStepBackward();
            Assert.AreEqual(-1, state.StateId);

        }
        
        [TestMethod]
        public void Steps()
        {
            var automate = new AutomatonSelectionSort(new[] {-1, -5, 0});

            var state = automate.DoStepBackward();
            Assert.AreEqual(-1, state.StateId);
            
            state = automate.DoStepForward();
            state = automate.DoStepForward();
            state = automate.DoStepForward();
            state = automate.DoStepForward();
            state = automate.DoStepForward();

            Assert.AreEqual((int)AutomatonSelectionSort.States.SwappingElements, state.StateId);
            Assert.IsTrue(ArrayEquals(new []{-5, -1, 0}, state.Array));
            Assert.IsTrue(ArrayEquals(new [] {0, 1}, state.SelectedElements.ToArray()));

            state = automate.DoStepBackward();

            Assert.AreEqual((int)AutomatonSelectionSort.States.Condition, state.StateId);
            Assert.IsTrue(ArrayEquals(new[] { 2}, state.SelectedElements.ToArray()));

            while (state.StateId != (int) AutomatonSelectionSort.States.FinalState)
            {
                state = automate.DoStepForward();
            }
            Assert.IsTrue(ArrayEquals(new[] { -5, -1, 0 }, state.Array));

        }

        public bool ArrayEquals(int[] expectedArray, int[] actualArray)
        {
            if (expectedArray.Length != actualArray.Length)
                return false;

            return !expectedArray.Where((t, i) => t != actualArray[i]).Any();
        }
    }
	
	[TestClass]
    public class TestingOfVisualizationArray
    {
        [TestMethod]
        public void GetCoordinates()
        {
            var visulizationArray = new VisualizationArray(5);
            visulizationArray.IdentifyCoordinates();
            
            Assert.AreEqual(new Point(3, 100), visulizationArray.GetCoordinates(0));
            Assert.AreEqual(new Point(153, 100), visulizationArray.GetCoordinates(2));
            Assert.AreEqual(new Point(303, 100), visulizationArray.GetCoordinates(4));
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

            var root = new Rectangle((int)(VisualizationHeap.rootsCoordinates.X),
               (int)VisualizationHeap.rootsCoordinates.Y,
               VisualizationHeap.NodesDiameter, VisualizationHeap.NodesDiameter);

            var nextNode1 = new Rectangle(root.X - VisualizationHeap.OffsetBetweenNeighbors, root.Y + VisualizationHeap.DistanceBetweenLevels, VisualizationHeap.NodesDiameter, VisualizationHeap.NodesDiameter);
            var nextNode2 = new Rectangle(root.X + VisualizationHeap.OffsetBetweenNeighbors, root.Y + VisualizationHeap.DistanceBetweenLevels, VisualizationHeap.NodesDiameter, VisualizationHeap.NodesDiameter);
            var nextNode3 = new Rectangle(nextNode1.X - VisualizationHeap.OffsetBetweenNeighbors / 2, nextNode1.Y + VisualizationHeap.DistanceBetweenLevels, VisualizationHeap.NodesDiameter, VisualizationHeap.NodesDiameter);
            var nextNode7 = new Rectangle(nextNode3.X - VisualizationHeap.OffsetBetweenNeighbors/3,
                nextNode3.Y + VisualizationHeap.DistanceBetweenLevels, VisualizationHeap.NodesDiameter,
                VisualizationHeap.NodesDiameter);




            Assert.AreEqual(new PointF(root.X + VisualizationHeap.offsetTextNode.X, root.Y + VisualizationHeap.offsetTextNode.Y), visualizationHeap.GetCoordinatesValue(0));
            Assert.AreEqual(new PointF(nextNode1.X + VisualizationHeap.offsetTextNode.X, nextNode1.Y + VisualizationHeap.offsetTextNode.Y), visualizationHeap.GetCoordinatesValue(1));
            Assert.AreEqual(new PointF(nextNode2.X + VisualizationHeap.offsetTextNode.X, nextNode2.Y + VisualizationHeap.offsetTextNode.Y), visualizationHeap.GetCoordinatesValue(2));
            Assert.AreEqual(new PointF(nextNode3.X + VisualizationHeap.offsetTextNode.X, nextNode3.Y + VisualizationHeap.offsetTextNode.Y), visualizationHeap.GetCoordinatesValue(3));
            Assert.AreEqual(new PointF(nextNode7.X + VisualizationHeap.offsetTextNode.X, nextNode7.Y + VisualizationHeap.offsetTextNode.Y), visualizationHeap.GetCoordinatesValue(7));

   
        }

        [TestMethod]
        public void GetCoordinatesEdge()
        {
            var visualizationHeap = new VisualizationHeap(8);
            visualizationHeap.DefineCoordinates();

            var root = new Rectangle((int)(VisualizationHeap.rootsCoordinates.X),
              (int)VisualizationHeap.rootsCoordinates.Y,
              VisualizationHeap.NodesDiameter, VisualizationHeap.NodesDiameter);

            var nextNode1 = new Rectangle(root.X - VisualizationHeap.OffsetBetweenNeighbors, root.Y + VisualizationHeap.DistanceBetweenLevels, VisualizationHeap.NodesDiameter, VisualizationHeap.NodesDiameter);
            var nextNode2 = new Rectangle(root.X + VisualizationHeap.OffsetBetweenNeighbors, root.Y + VisualizationHeap.DistanceBetweenLevels, VisualizationHeap.NodesDiameter, VisualizationHeap.NodesDiameter);
            var nextNode3 = new Rectangle(nextNode1.X - VisualizationHeap.OffsetBetweenNeighbors / 2, nextNode1.Y + VisualizationHeap.DistanceBetweenLevels, VisualizationHeap.NodesDiameter, VisualizationHeap.NodesDiameter);
            var nextNode7 = new Rectangle(nextNode3.X - VisualizationHeap.OffsetBetweenNeighbors / 3,
                nextNode3.Y + VisualizationHeap.DistanceBetweenLevels, VisualizationHeap.NodesDiameter,
                VisualizationHeap.NodesDiameter);

            var d = VisualizationHeap.NodesDiameter;
            Assert.AreEqual(Tuple.Create(new Point(root.X + d/2, root.Y + d), new Point(nextNode1.X + d/2, nextNode1.Y)), visualizationHeap.GetCoordinatesEdge(1));
            Assert.AreEqual(Tuple.Create(new Point(root.X + d / 2, root.Y + d), new Point(nextNode2.X + d / 2, nextNode2.Y)), visualizationHeap.GetCoordinatesEdge(2));
            Assert.AreEqual(Tuple.Create(new Point(nextNode1.X + d / 2, nextNode1.Y + d), new Point(nextNode3.X + d / 2, nextNode3.Y)), visualizationHeap.GetCoordinatesEdge(3));
            Assert.AreEqual(Tuple.Create(new Point(nextNode3.X + d / 2, nextNode3.Y + d), new Point(nextNode7.X + d / 2, nextNode7.Y)), visualizationHeap.GetCoordinatesEdge(7));
        }
    }
}
