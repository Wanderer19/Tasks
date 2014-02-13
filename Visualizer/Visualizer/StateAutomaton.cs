using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Visualizer
{
    public class StateAutomaton
    {
        public string Comment { get; protected set; }
        public List<int> SelectedElements { get; protected set; } 
        public string StateId { get; protected set; }
        public int StateNumber { get; protected set; }
        public int[] Array { get; protected set; }
        public int IndexMinimum { get; protected set; }
        public int BorderSortedPart { get; protected set; }
        public int SiftingElement { get; protected set; }

        public StateAutomaton()
        {
            SelectedElements = new List<int>();
            BorderSortedPart = -1;
            SiftingElement = -1;
        }
    }
}
