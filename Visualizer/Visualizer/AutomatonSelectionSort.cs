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

        public override StateAutomaton DoStepForward()
        {
            var isInterestingState = false;
            StepsCount++;

            var state = new StateAutomaton(array);

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
                        isInterestingState = true;
                        
                        dataModel.IndexMinimum = dataModel.OuterCounter;
                        
                        state = GetStateSelectionSortAutomaton(dataModel.State);
                        
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
                        
                        state = GetStateSelectionSortAutomaton(dataModel.State);
                        
                        dataModel.State = dataModel.Array[dataModel.InnerCounter] < dataModel.Array[dataModel.IndexMinimum] ? 
                            States.UpdateMinimum : States.EndingConditions;

                        break;
                    }
                    case States.UpdateMinimum:
                    {
                        isInterestingState = true;
                        
                        dataModel.IndexMinimum = dataModel.InnerCounter;
                       
                        state = GetStateSelectionSortAutomaton(dataModel.State);
                        
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
                        state = GetStateSelectionSortAutomaton(dataModel.State);
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

                        state = GetStateSelectionSortAutomaton(dataModel.State);
                        
                        break;
                    }
                }
            }

            return state;
        }

        private StateSelectionSortAutomaton GetStateSelectionSortAutomaton(States state)
        {
            var descriptionState = "";
            var selectedIndexes = new List<int>();
           
            switch (state)
            {
                case States.InitializeIndexMinimum:
                {
                    break;
                }
                case States.Condition:
                {
                    descriptionState = String.Format("Сравнение элемента с индексом {0} с текущим минимумом", dataModel.InnerCounter);
                    
                    selectedIndexes.Add(dataModel.InnerCounter);

                    break;
                }
                case States.UpdateMinimum:
                {
                    break;
                }
                case States.SwappingElements:
                {
                    descriptionState = String.Format("Обмен элемента с индексом {0} с текущим минимумом", dataModel.OuterCounter);

                    selectedIndexes.Add(dataModel.OuterCounter);
                    selectedIndexes.Add(dataModel.IndexMinimum);
                    
                   break;
                }
                case States.FinalState:
                {
                    descriptionState = "Конец Сортировки";
                    break;
                }
            }

            return new StateSelectionSortAutomaton(selectedIndexes, dataModel.BorderSortedPart, dataModel.Array[dataModel.IndexMinimum], (int) dataModel.State, descriptionState, dataModel.Array);
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

            return new StateSelectionSortAutomaton(new List<int>(), -1, -1, (int)dataModel.State, "", dataModel.Array);
        }
    }
}
