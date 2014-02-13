using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Visualizer
{
    public class AutomatonSelectionSort : Automaton
    {
        public enum States
        {
            InitialState = 0,
            StartOuterLoop = 1,
            OuterLoop = 2,
            InitializeIndexMinimum = 3,
            StartInnerLoop = 4,
            InnerLoop = 5,
            Condition = 6,
            UpdateMinimum = 7,
            EndingConditions = 8,
            IncrementInnerCounter = 9,
            SwappingElements = 10,
            IncrementOuterCounter = 11,
            FinalState = 12
        }

        private class DataModel
        {
            public int OuterCounter { get; set; }
            public int InnerCounter { get; set; }
            public int IndexMinimum { get; set; }
            public States State { get; set; }
            public int BorderSortedPart { get; set; }

            
            public int ArraySize { get; private set; }
            public int[] Array { get; private set; }

            public DataModel(int[] array)
            {
                ArraySize = array.Length;
                Array = array;
                OuterCounter = 0;
                InnerCounter = 0;
                IndexMinimum = 0;
                State = States.InitialState;
                BorderSortedPart = -1;
            }

            public void SwapElements()
            {
                var copyItem = Array[OuterCounter];
                Array[OuterCounter] = Array[IndexMinimum];
                Array[IndexMinimum] = copyItem;

                BorderSortedPart = OuterCounter;
            }
        }

        public AutomatonSelectionSort(int[] array)
        {
            dataModel = new DataModel(array);
            
            this.array = (int[]) array.Clone();
        }

        private DataModel dataModel;
        private readonly int[] array;

        public override StateAutomaton DoStepForward()
        {
            var isInterestingState = false;
            StepsCount++;

            var state = new StateSelectionSortAutomaton();

            while (!isInterestingState)
            {
                switch (dataModel.State)
                {
                    case States.InitialState:
                    {
                        dataModel.BorderSortedPart = -1;
                        dataModel.State = States.StartOuterLoop;
                       
                        break;
                    }
                    case States.StartOuterLoop:
                        {
                            dataModel.OuterCounter = 0;
                            dataModel.State = States.OuterLoop;
                            
                            break;
                        }
                    case States.OuterLoop:
                    {
                        dataModel.State = dataModel.OuterCounter < dataModel.ArraySize - 1 ? States.InitializeIndexMinimum : States.FinalState;

                        break;
                    }
                    case States.InitializeIndexMinimum:
                    {
                        dataModel.IndexMinimum = dataModel.OuterCounter;
                        isInterestingState = true;
                        state = GetStateSelectionSortAutomaton(3);
                        dataModel.State = States.StartInnerLoop;
                            
                        break;
                    }
                    case States.StartInnerLoop:
                    {
                        dataModel.InnerCounter = dataModel.OuterCounter + 1;
                            
                        dataModel.State = States.InnerLoop;
                           
                        break;
                    }
                    case States.InnerLoop:
                    {
                        dataModel.State = dataModel.InnerCounter < dataModel.ArraySize ? States.Condition : States.SwappingElements;
                        
                        break;
                    }
                    case States.Condition:
                    {
                        isInterestingState = true;
                        state = GetStateSelectionSortAutomaton(6);
                        
                        dataModel.State = dataModel.Array[dataModel.InnerCounter] < dataModel.Array[dataModel.IndexMinimum] ? 
                            States.UpdateMinimum : States.EndingConditions;

                        break;
                    }
                    case States.UpdateMinimum:
                    {
                        dataModel.IndexMinimum = dataModel.InnerCounter;
                        isInterestingState = true;
                        state = GetStateSelectionSortAutomaton(7);
                        dataModel.State = States.EndingConditions;
                         
                        break;
                    }
                    case States.EndingConditions:
                    {
                        dataModel.State = States.IncrementInnerCounter;
                            
                        break;
                    }
                    case States.IncrementInnerCounter:
                    {
                        dataModel.InnerCounter++;
                        dataModel.State = States.InnerLoop;
                        
                        break;
                    }
                    case States.SwappingElements:
                    {
                        dataModel.SwapElements();
                        state = GetStateSelectionSortAutomaton(10);
                        isInterestingState = true;
                           
                        dataModel.State = States.IncrementOuterCounter;
                            
                        break;
                    }
                    case States.IncrementOuterCounter:
                    {
                        dataModel.OuterCounter++;
                        dataModel.State = States.OuterLoop;
                            
                        break;
                    }
                    case States.FinalState:
                    {
                        isInterestingState = true;
                        dataModel.BorderSortedPart = dataModel.ArraySize - 1;

                        state = GetStateSelectionSortAutomaton(12);
                        
                        break;
                    }
                }
            }

            return state;
        }

        private StateSelectionSortAutomaton GetStateSelectionSortAutomaton(int state)
        {
            var stateId = "";
            var descriptionState = "";
            var selectedIndexes = new List<int>();
           
            switch (state)
            {
                case 3:
                {
                    stateId = "min";
                    break;
                }
                case 6:
                {
                    stateId = "compare";
                    descriptionState = String.Format("Сравнение элемента с индексом {0} с текущим минимумом", dataModel.InnerCounter);
                    
                    selectedIndexes.Add(dataModel.InnerCounter);

                    break;
                }
                case 7:
                {
                    stateId = "min";
                    break;
                }
                case 10:
                {
                    stateId = "swap";
                    descriptionState = String.Format("Обмен элемента с индексом {0} с текущим минимумом", dataModel.OuterCounter);

                    selectedIndexes.Add(dataModel.OuterCounter);
                    selectedIndexes.Add(dataModel.IndexMinimum);
                    
                   break;
                }
                case 12:
                {
                    stateId = "end";
                    descriptionState = "Конец Сортировки";
                    break;
                }
            }

            return new StateSelectionSortAutomaton(selectedIndexes, dataModel.BorderSortedPart, dataModel.Array[dataModel.IndexMinimum], stateId, descriptionState, dataModel.Array);
        }

        public override StateAutomaton DoStepBackward()
        {

            dataModel = new DataModel((int[]) array.Clone());
            return base.DoStepBackward();
        }

        public override StateAutomaton ToStart()
        {
            StepsCount = 0;
            dataModel = new DataModel((int[])array.Clone());

            return new StateSelectionSortAutomaton();
        }
    }
}
