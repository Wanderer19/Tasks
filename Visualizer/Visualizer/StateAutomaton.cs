using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Visualizer
{
    public class StateAutomaton
    {
        public string DescriptionState { get; private set; }
        public Tuple<int, int> IndexesSelectedItems { get; private set; }
        public string StateId { get; private set; }
        public int StateNumber { get; private set; }

        public StateAutomaton(string descriptionState, string stateId, int stateNumber, int firstndex, int secondindex)
        {
            DescriptionState = descriptionState;
            StateId = stateId;
            StateNumber = stateNumber;
            IndexesSelectedItems = Tuple.Create(firstndex, secondindex);
        }
    }
}
