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
        }
    }
}
