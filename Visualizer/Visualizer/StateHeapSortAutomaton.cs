using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Visualizer
{
    class StateHeapSortAutomaton : StateAutomaton
    {
        public StateHeapSortAutomaton(int firstIndex, int secondIndex, int shiftingElement, string stateId, string comment, int[] array, int sortedPart)
        {
            SelectedElements = new List<int>();
            SelectedElements.Add(firstIndex);
            SelectedElements.Add(secondIndex);
            this.FirstIndex = sortedPart;

            ShiftingElement = shiftingElement;
            StateId = stateId;
            Array = array;
            DescriptionState = comment;
        }
    }
}
