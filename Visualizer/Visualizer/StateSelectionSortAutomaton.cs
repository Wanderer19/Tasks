﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Visualizer
{
    class StateSelectionSortAutomaton : StateAutomaton
    {
        public StateSelectionSortAutomaton(List<int> selectedIndexes, int borderSortedPart, int indexMinimum, int stateId, string comment, int[] array)
        {
            SelectedElements=new List<int>();
            SelectedElements.AddRange(selectedIndexes);

            this.IndexMinimum = indexMinimum;
            this.Array = array;
            this.Comment = comment;
            this.StateId = stateId;
            this.BorderSortedPart = borderSortedPart;
            BoundariesSortedPart = new Point(0, borderSortedPart);
        }
    }
}
