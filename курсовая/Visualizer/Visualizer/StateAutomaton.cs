using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Visualizer
{
    public class StateAutomaton
    {
        public string Comment { get; protected set; }
        public List<int> SelectedElements { get; protected set; } 
        public int StateId { get; protected set; }
        public int StateNumber { get; protected set; }
        public int[] Array { get; protected set; }
        public int Minimum { get; protected set; }
        public int BorderSortedPart { get; protected set; }
        public int SiftingElement { get; protected set; }
        public string State { get; protected set; }
        public Point BoundariesSortedPart { get; protected set; }

        public StateAutomaton()
        {
            SelectedElements = new List<int>();
            BorderSortedPart = -1;
            SiftingElement = -1;
            BoundariesSortedPart = new Point(-1, -1);
        }

        public StateAutomaton(int[] array)
        {
            Array = array;
            BorderSortedPart = -1;
            SelectedElements = new List<int>();
            StateId = -1;
            SiftingElement = -1;
            BoundariesSortedPart = new Point(-1, -1);
        }
    }
}
