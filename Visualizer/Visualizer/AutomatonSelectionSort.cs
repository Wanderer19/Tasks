using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Visualizer
{
    public class AutomatonSelectionSort : Automaton
    {
        public AutomatonSelectionSort(int[] array)
        {
            dataModel = new DataModel(array);
            stack = new Stack<object>();
        }

        private DataModel dataModel;
        private Stack<object> stack;

        public override StateAutomaton DoStepForward()
        {
            var descriptionState = "";
            var isInterestingState = false;
            var stateId = "";
            var currentIndex = -1;
            var minIndex = -1;

            while (!isInterestingState)
            {
                switch (dataModel.State)
                {
                }
            }

            return new StateAutomaton(descriptionState, stateId, dataModel.State, currentIndex, minIndex);
        }

        public override StateAutomaton DoStepBackward()
        {
            var descriptionState = "";
            var isInterestingState = false;
            var stateId = "";
            var currentIndex = -1;
            var minIndex = -1;

             while (!isInterestingState)
            {
                switch (dataModel.State)
                {
                }
            }

            return new StateAutomaton(descriptionState, stateId, dataModel.State, currentIndex, minIndex);
        }
    }
}
