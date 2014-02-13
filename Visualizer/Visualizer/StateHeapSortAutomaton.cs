using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Visualizer
{
    class StateHeapSortAutomaton : StateAutomaton
    {
        public StateHeapSortAutomaton(int firstIndex, int secondIndex, int siftingElement, string stateId, string comment, int[] array, int sortedPart)
        {
            SelectedElements = new List<int>();
            SelectedElements.Add(firstIndex);
            SelectedElements.Add(secondIndex);
            this.BorderSortedPart = sortedPart;

            SiftingElement = siftingElement;
            StateId = stateId;
            Array = array;
            Comment = comment;
        }
    }
}
