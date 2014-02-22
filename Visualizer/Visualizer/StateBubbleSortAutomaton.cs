using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Visualizer
{
    class StateBubbleSortAutomaton : StateAutomaton
    {
        public StateBubbleSortAutomaton(int firstIndex, int secondIndex, int stateId, string comment, int [] array)
        {
            SelectedElements = new List<int> {firstIndex, secondIndex};

            this.Array = array;
            this.Comment = comment;
            this.StateId = stateId;
        }
    }
}
