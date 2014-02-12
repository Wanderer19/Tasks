using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Visualizer
{
    public class StateAutomaton
    {
        public string DescriptionState { get; protected set; }
        public List<int> SelectedElements { get; protected set; } 
        public string StateId { get; protected set; }
        public int StateNumber { get; protected set; }
        public int[] Array { get; protected set; }
        public int Min { get; protected set; }
        public int FirstIndex { get; protected set; }
        public int ShiftingElement { get; protected set; }

        public StateAutomaton()
        {
            SelectedElements = new List<int>();
            FirstIndex = -1;
            ShiftingElement = -1;
        }
    }
}
