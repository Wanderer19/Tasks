using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Visualizer;

namespace TestingVisualizer
{
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
}
