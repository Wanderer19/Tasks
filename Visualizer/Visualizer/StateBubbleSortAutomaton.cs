using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Visualizer
{
    class StateBubbleSortAutomaton : StateAutomaton
    {
        public StateBubbleSortAutomaton(int firstIndex, int secondIndex, string stateId, string comment, int [] array, int state)
        {
            SelectedElements = new List<int>();
            SelectedElements.Add(firstIndex);
            SelectedElements.Add(secondIndex);

            this.Array = array;
            this.DescriptionState = comment;
            this.StateId = stateId;
            this.StateNumber = state;
        }
    }
}
