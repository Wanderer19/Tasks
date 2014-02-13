using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Visualizer
{
    class AutomatonSiftDown :Automaton
    {
        public enum States
        {
            InitialState = 0,
            InitializeVariables = 1,
            StartLoop = 2,
            Loop = 3,
            InitializingIndexMaximumChild = 4,
            ConditionOnUpdateMaximumChild = 5,
            UpdateMaximalChild = 6,
            EndingConditionOnUpdateMaximumChild = 7,
            ConditionOnUpdateParent = 8,
            SwappingParentWithMaximumChild = 9,
            EndLoop = 10,
            EndingConditionOnUpdateParent = 11,
            FinalState = 12
        }

        private class  DataModel 
        {
            public bool IsDone { get; set; }
            public States State { get; set; }
            public int[] Array { get; private set; }
            public int ArraySize { get; private set; }
            public int IndexMaximumChild { get; set; }
            public int SortedPart { get; set; }
            public int Counter { get; set; }

            public DataModel(int[] array)
            {
                Array = array;
                ArraySize = array.Length;
                State = States.InitialState;
                Counter = 0;
                IndexMaximumChild = 0;
                IsDone = false;
            }

            public void SwapParentWithMaximumChild()
            {
                var copy = Array[Counter];
                Array[Counter] = Array[IndexMaximumChild];
                Array[IndexMaximumChild] = copy;
                
                Counter = IndexMaximumChild;
            }

        }

        private DataModel dataModel;
        public int State { get { return (int)dataModel.State; } set { dataModel.State = (States)value; }}

        public AutomatonSiftDown(int[] array)
        {
            dataModel = new DataModel(array);
        }

        public StateAutomaton DoStepForward(int i, int j, int sortedPart)
        {
            var isInterestingState = false;

            StateAutomaton state = new StateHeapSortAutomaton(-1, -1, -1, "", "", dataModel.Array, dataModel.SortedPart);

            while (!isInterestingState)
            {
                switch (dataModel.State)
                {
                    case States.InitialState:
                    {
                        dataModel.State = States.InitializeVariables;
                        break;
                    }
                    case States.InitializeVariables:
                    {
                        dataModel.IsDone = false;
                        
                        dataModel.State = States.StartLoop;
                        
                        break;
                    }
                    case States.StartLoop:
                    {
                        dataModel.SortedPart = sortedPart;
                        
                        dataModel.Counter = i;
                        
                        dataModel.State = States.Loop;
                        
                        break;
                    }
                    case States.Loop:
                    {
                        isInterestingState = true;
                        
                        state = GetStateShiftDownAutomaton(dataModel.State);
                        
                        dataModel.State = dataModel.Counter * 2 + 1 < j && !dataModel.IsDone ?
                            States.InitializingIndexMaximumChild : States.FinalState;
                       
                        break;
                    }
                    case States.InitializingIndexMaximumChild:
                    {
                        dataModel.IndexMaximumChild = dataModel.Counter * 2 + 1;
                        
                        dataModel.State = States.ConditionOnUpdateMaximumChild;

                        break;
                    }
                    case States.ConditionOnUpdateMaximumChild:
                    {
                        isInterestingState = true;
                        
                        state = GetStateShiftDownAutomaton(dataModel.State);
                        
                        dataModel.State = dataModel.Counter * 2 + 2 < j &&
                                          dataModel.Array[dataModel.IndexMaximumChild] < dataModel.Array[dataModel.Counter*2 + 2]
                            ? States.UpdateMaximalChild
                            : States.EndingConditionOnUpdateMaximumChild;
                        
                        break;
                    }
                    case States.UpdateMaximalChild:
                    {
                        dataModel.IndexMaximumChild = dataModel.Counter * 2 + 2;

                        dataModel.State = States.EndingConditionOnUpdateMaximumChild;
                        
                        break;
                    }
                    case States.EndingConditionOnUpdateMaximumChild:
                    {
                        isInterestingState = true;
                        
                        state = GetStateShiftDownAutomaton(dataModel.State);
                        
                        dataModel.State = States.ConditionOnUpdateParent;

                        break;
                    }
                    case States.ConditionOnUpdateParent:
                    {
                        isInterestingState = true;

                        state = GetStateShiftDownAutomaton(dataModel.State);
                        
                        dataModel.State = dataModel.Array[dataModel.Counter] < dataModel.Array[dataModel.IndexMaximumChild] ?
                            States.SwappingParentWithMaximumChild : States.EndLoop;
                        
                        break;
                    }
                    case States.SwappingParentWithMaximumChild:
                    {
                        isInterestingState = true;

                        state = GetStateShiftDownAutomaton(dataModel.State);
                        
                        dataModel.SwapParentWithMaximumChild();
                        
                        dataModel.State = States.EndingConditionOnUpdateParent;
                        
                        break;
                    }
                    case States.EndLoop:
                    {
                        state = GetStateShiftDownAutomaton(dataModel.State);
                        
                       isInterestingState = true;
                        
                        dataModel.IsDone = true;
                        
                        dataModel.State = States.FinalState;
                       
                        break;
                    }
                    case States.EndingConditionOnUpdateParent:
                    {
                       dataModel.State = States.Loop;
                        
                        break;
                    }
                    case States.FinalState:
                    {
                        state = GetStateShiftDownAutomaton(States.EndLoop);
                        isInterestingState = true;
                        
                        break;
                    }
                }
            }

            return state;
        }

        public StateAutomaton GetStateShiftDownAutomaton(States state)
        {
            var stateId = "";
            var comment = "";

            switch (state)
            {
                case States.Loop:
                {
                    stateId = "shifting";
                    comment = String.Format("Просеивание элемента с индексом {0}", dataModel.Counter);

                    return new StateHeapSortAutomaton(-1, -1, dataModel.Counter, stateId, comment, dataModel.Array, dataModel.SortedPart);
                }
                case States.ConditionOnUpdateMaximumChild:
                {
                    stateId = "compare";
                    comment = String.Format("Определяем максимального ребёнка элемента с индексом {0}", dataModel.Counter);

                    return new StateHeapSortAutomaton(dataModel.IndexMaximumChild, dataModel.Counter * 2 + 2, dataModel.Counter, stateId, comment, dataModel.Array, dataModel.SortedPart);
                 }
                case States.EndingConditionOnUpdateMaximumChild:
                {
                    stateId = "maxChild";
                    comment = String.Format("Максимальный ребёнок - элемент с индексом {0}", dataModel.IndexMaximumChild);

                    return new StateHeapSortAutomaton(-1, -1, dataModel.IndexMaximumChild, stateId, comment, dataModel.Array, dataModel.SortedPart);
                }
                case States.ConditionOnUpdateParent:
                {
                    stateId = "compare";
                    comment = String.Format("Сравнение значения в узле с его наибольшим ребенком");

                    return new StateHeapSortAutomaton(dataModel.Counter, dataModel.IndexMaximumChild, -1, stateId, comment, dataModel.Array, dataModel.SortedPart);
                }
                case States.SwappingParentWithMaximumChild:
                {
                    stateId = "swap";
                    comment = String.Format("Обмен узла с его наибольшим ребёнком");

                    return new StateHeapSortAutomaton(dataModel.Counter, dataModel.IndexMaximumChild, -1, stateId, comment, dataModel.Array, dataModel.SortedPart);
                }
                case States.EndLoop:
                {
                    stateId = "endShifting";
                    comment = String.Format("Конец просеиванию");

                    return new StateHeapSortAutomaton(-1, -1, -1, stateId, comment, dataModel.Array, dataModel.SortedPart);
                }
                default:
                {
                    return new StateHeapSortAutomaton(-1, -1, -1, stateId, comment, dataModel.Array, dataModel.SortedPart);
                }
            }
        }
    }
    
    class AutomatonHeapSort : Automaton
    {
        public enum States
        {
            InitialState = 0,
            StartLoopBuildingPyramid = 1,
            LoopBuildingPyramid = 2,
            SiftingElementInBuildingPyramid = 3,
            DecrementCounterInBuildingPyramid = 4,
            StartLoopSorting = 5,
            LoopSorting = 6,
            SwappingElements = 7,
            SiftingElementInSorting = 8,
            DecrementCounterSorting = 9,
            FinalState = 10
        }

        private class DataModel
        {
            private int index;
            public int ArraySize { get; private set; }
            public int[] Array { get; set; }
            public States State { get; set; }
            public int SortedPart { get; set; }
            public int Index { get; set; }

            public void SwappingElements()
            {
                var copy = Array[0];
                Array[0] = Array[Index - 1];
                Array[Index - 1] = copy;
            }

            public DataModel(int[] array)
            {
                Index = 0;
                ArraySize = array.Length;
                Array = array;
                State = States.InitialState;
                SortedPart = -1;
            }
        }
        
        private AutomatonSiftDown automatonSiftDown;
        private int[] array;
        private DataModel dataModel;

        public AutomatonHeapSort(int[] array)
        {
           automatonSiftDown = new AutomatonSiftDown(array);
           dataModel = new DataModel(array);
           this.array = (int[]) array.Clone();
        }

        public override StateAutomaton DoStepForward()
        {
            var isInterestingState = false;
            StepsCount++;

            StateAutomaton state = new StateHeapSortAutomaton(-1, -1, -1, "","", dataModel.Array, -1);  
            while (!isInterestingState)
            {
                switch (dataModel.State)
                {
                    case States.InitialState:
                    {
                        dataModel.State = States.StartLoopBuildingPyramid;
                        break;
                    }
                    case States.StartLoopBuildingPyramid:
                    {
                       dataModel.Index = (dataModel.ArraySize / 2) - 1;
                       
                        dataModel.State = States.LoopBuildingPyramid;
                       
                        break;
                    }
                    case States.LoopBuildingPyramid:
                    {
                        dataModel.State = dataModel.Index >= 0 ? States.SiftingElementInBuildingPyramid : States.StartLoopSorting;

                        break;
                    }
                    case States.SiftingElementInBuildingPyramid:
                    {
                       if (automatonSiftDown.State != 12)
                       {
                           isInterestingState = true;
                           state = automatonSiftDown.DoStepForward(dataModel.Index, dataModel.ArraySize, dataModel.SortedPart);

                           dataModel.State = States.SiftingElementInBuildingPyramid;
                        }
                        else
                       {
                           automatonSiftDown.State = 0;
                           dataModel.State = States.DecrementCounterInBuildingPyramid;
                        }

                        break;
                    }
                    case States.DecrementCounterInBuildingPyramid:
                    {
                        dataModel.Index--;
                        dataModel.State = States.LoopBuildingPyramid;

                        break;
                    }
                    case States.StartLoopSorting:
                    {
                       dataModel.Index = dataModel.ArraySize;
                       
                       dataModel.State = States.LoopSorting;
                       
                       break;
                    }
                    case States.LoopSorting:
                    {
                        dataModel.State = dataModel.Index > 0 ? States.SwappingElements : States.FinalState;

                        break;
                    }
                    case States.SwappingElements:
                    {
                        state = GetStateHeapSortAutomaton(7);
                        isInterestingState = true;
                        
                        dataModel.SwappingElements();
                        
                        dataModel.SortedPart = dataModel.Index - 1;
                       
                        dataModel.State = States.SiftingElementInSorting;
                       
                        break;
                    }
                    case States.SiftingElementInSorting:
                    {
                        
                        if (automatonSiftDown.State != 12)
                        {
                            isInterestingState = true;
                            state = automatonSiftDown.DoStepForward(0, dataModel.Index - 1, dataModel.SortedPart);

                            dataModel.State = States.SiftingElementInSorting;
                        }
                        else
                        {
                            automatonSiftDown.State = 0;
                            
                            dataModel.State = States.DecrementCounterSorting;
                        }
                        
                        break;
                    }
                    case States.DecrementCounterSorting:
                    {
                       dataModel.Index--;
                       
                        dataModel.State = States.LoopSorting;
                       
                        break;
                    }
                    case States.FinalState:
                    {
                        state = GetStateHeapSortAutomaton(10);
                        dataModel.State = States.InitialState;
                        isInterestingState = true;
                       
                        break;
                    }
                }

            }

            return state;
        }

        public override StateAutomaton DoStepBackward()
        {
            var copyArray = (int[]) array.Clone();
            
            dataModel = new DataModel(copyArray);
            automatonSiftDown = new AutomatonSiftDown(copyArray);

            if (StepsCount - 1 == 0 || StepsCount == 0)
            {
                return new StateHeapSortAutomaton(-1, -1, -1, "start", "", copyArray, -1);
            }

            return base.DoStepBackward();
        }

        public StateAutomaton GetStateHeapSortAutomaton(int state)
        {
            var stateId = "";
            var comment = "";

            switch (state)
            {
                case 3:
                {
                    stateId = automatonSiftDown.State != 12 ? "shifting" : "endShifting";
                    comment = "";

                    return new StateHeapSortAutomaton(-1, -1, dataModel.Index, stateId, comment, dataModel.Array, dataModel.SortedPart);
                }
                case 7:
                {
                    stateId = "swap - sorting";
                    comment = String.Format("Обмен элеентов с индексами {0} и {1}. Далее, если не конец, восстанавливаем пирамиду", 0, dataModel.Index - 1);

                    return new StateHeapSortAutomaton(0, dataModel.Index - 1, -1, stateId, comment, dataModel.Array, dataModel.SortedPart);
                }
                case 8:
                {
                    stateId = "restore pyramid";
                    comment = String.Format("Восстановение пирамиды, просеиваем 0-й элемент");

                    return new StateHeapSortAutomaton(-1, -1, 0, stateId, comment, dataModel.Array, dataModel.SortedPart);
                }
                case 10:
                {
                    stateId = "end";
                    comment = String.Format("Конец сортировки");

                    return new StateHeapSortAutomaton(-1, -1, -1, stateId, comment, dataModel.Array, dataModel.SortedPart);
                }
                default:
                {
                    stateId = "start";
                    return new StateHeapSortAutomaton(-1, -1, -1, stateId, comment, dataModel.Array, dataModel.SortedPart);
                }
            }
        }

   

        public override StateAutomaton ToStart()
        {
            StepsCount = 0;
            var copyArray = (int[])array.Clone();

            dataModel = new DataModel(copyArray);
            automatonSiftDown = new AutomatonSiftDown(copyArray);

            return new StateSelectionSortAutomaton();
        }
    }
}
