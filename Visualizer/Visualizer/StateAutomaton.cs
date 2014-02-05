using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Visualizer
{
    public class StateAutomaton
    {
        public string DescriptionState { get; private set; }
        public Tuple<int, int> IndexesSelectedItemsCompare { get; private set; }
        public Tuple<int, int> IndexesSelectedItemsSwap { get; private set; }
        public string StateId { get; private set; }
        public int StateNumber { get; private set; }
        public int Min { get; private set; }
        public int FirstIndex { get; private set; }

        public StateAutomaton(string descriptionState, string stateId, int stateNumber, int firstndex, int secondindex)
        {
            DescriptionState = descriptionState;
            StateId = stateId;
            StateNumber = stateNumber;
            IndexesSelectedItemsCompare = Tuple.Create(firstndex, secondindex);
            IndexesSelectedItemsSwap = Tuple.Create(firstndex, secondindex);
        }

        public StateAutomaton(string descriptionState, string stateId, int stateNumber, int firstndex, int secondindex, int min)
        {
            DescriptionState = descriptionState;
            StateId = stateId;
            StateNumber = stateNumber;
            IndexesSelectedItemsCompare = Tuple.Create(secondindex, min);
            IndexesSelectedItemsSwap = Tuple.Create(firstndex, min);
            FirstIndex = firstndex;
            Min = min;
        }
    }
}
