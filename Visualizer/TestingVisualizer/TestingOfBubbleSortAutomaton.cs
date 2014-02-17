using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Visualizer;

namespace TestingVisualizer
{
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

            state = automaton.DoStepForward();

            Assert.AreEqual((int) AutomatonBubbleSort.States.Condition, state.StateId);

            state = automaton.DoStepForward();

            Assert.AreEqual((int)AutomatonBubbleSort.States.SwappingAdjacentElements, state.StateId);

            state = automaton.DoStepForward();

            Assert.AreEqual((int)AutomatonBubbleSort.States.Condition, state.StateId);

            state = automaton.DoStepForward();

            Assert.AreEqual((int)AutomatonBubbleSort.States.Condition, state.StateId);

            state = automaton.DoStepForward();

            while (state.StateId != (int) AutomatonBubbleSort.States.FinalState)
            {
                Assert.AreEqual((int)AutomatonBubbleSort.States.Condition, state.StateId);
                state = automaton.DoStepForward();
            }


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

            state = automaton.DoStepBackward();
            Assert.AreEqual((int)AutomatonBubbleSort.States.Condition, state.StateId);

            state = automaton.DoStepForward();
            state = automaton.DoStepForward();
            state = automaton.DoStepForward();

            state = automaton.DoStepBackward();
            Assert.AreEqual((int)AutomatonBubbleSort.States.SwappingAdjacentElements, state.StateId);

            state = automaton.DoStepBackward();
            state = automaton.DoStepBackward();
            Assert.AreEqual((int)AutomatonBubbleSort.States.Condition, state.StateId);

        }
        public bool ArrayEquals(int[] expectedArray, int[] actualArray)
        {
            if (expectedArray.Length != actualArray.Length)
                return false;

            return !expectedArray.Where((t, i) => t != actualArray[i]).Any();
        }
    }
}
