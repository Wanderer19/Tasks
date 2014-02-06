using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Visualizer
{
    class StateSelectionSortAutomaton : StateAutomaton
    {
        public StateSelectionSortAutomaton() { }
        public StateSelectionSortAutomaton(List<int> selectedIndexes, int firstIndex, int min, string stateId, string comment, int[] array)
        {
            SelectedElements=new List<int>();
            SelectedElements.AddRange(selectedIndexes);

            this.Min = min;
            this.Array = array;
            this.DescriptionState = comment;
            this.StateId = stateId;
            this.FirstIndex = firstIndex;
        }
    }
}
