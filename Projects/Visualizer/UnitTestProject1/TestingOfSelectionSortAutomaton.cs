using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Visualizer;

namespace TestingVisualizer
{
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
}
