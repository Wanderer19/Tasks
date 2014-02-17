using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Visualizer
{
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
            public int ArraySize { get; private set; }
            public int[] Array { get; private set; }
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

            StateAutomaton state = new StateHeapSortAutomaton(-1, -1, -1, (int)dataModel.State, "", dataModel.Array, -1);  
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
                       if (automatonSiftDown.State != AutomatonSiftDown.States.FinalState)
                       {
                           isInterestingState = true;
                           state = automatonSiftDown.DoStepForward(dataModel.Index, dataModel.ArraySize, dataModel.SortedPart);

                           dataModel.State = States.SiftingElementInBuildingPyramid;
                        }
                        else
                       {
                           automatonSiftDown.State = AutomatonSiftDown.States.InitialState;
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
                        state = GetStateHeapSortAutomaton(dataModel.State);
                        isInterestingState = true;
                        
                        dataModel.SwappingElements();
                        
                        dataModel.SortedPart = dataModel.Index - 1;
                       
                        dataModel.State = States.SiftingElementInSorting;
                       
                        break;
                    }
                    case States.SiftingElementInSorting:
                    {
                        
                        if (automatonSiftDown.State != AutomatonSiftDown.States.FinalState)
                        {
                            isInterestingState = true;
                            state = automatonSiftDown.DoStepForward(0, dataModel.Index - 1, dataModel.SortedPart);

                            dataModel.State = States.SiftingElementInSorting;
                        }
                        else
                        {
                            automatonSiftDown.State = AutomatonSiftDown.States.InitialState;
                            
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
                        state = GetStateHeapSortAutomaton(dataModel.State);
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

            return base.DoStepBackward();
        }

        public StateAutomaton GetStateHeapSortAutomaton(States state)
        {
            var comment = "";

            switch (state)
            {
                case States.SwappingElements:
                {
                    comment = String.Format("Обмен элеентов с индексами {0} и {1}. Далее, если не конец, восстанавливаем пирамиду", 0, dataModel.Index - 1);

                    return new StateHeapSortAutomaton(0, dataModel.Index - 1, -1, (int) state, comment, dataModel.Array, dataModel.SortedPart);
                }
                case States.SiftingElementInSorting:
                {
                    comment = String.Format("Восстановение пирамиды, просеиваем 0-й элемент");

                    return new StateHeapSortAutomaton(-1, -1, 0, (int)state, comment, dataModel.Array, dataModel.SortedPart);
                }
                case States.FinalState:
                {
                    comment = String.Format("Конец сортировки");

                    return new StateHeapSortAutomaton(-1, -1, -1, (int)state, comment, dataModel.Array, dataModel.SortedPart);
                }
                default:
                {
                    return new StateHeapSortAutomaton(-1, -1, -1, (int)state, comment, dataModel.Array, dataModel.SortedPart);
                }
            }
        }

        public override StateAutomaton ToStart()
        {
            StepsCount = 0;
            var copyArray = (int[])array.Clone();

            dataModel = new DataModel(copyArray);
            automatonSiftDown = new AutomatonSiftDown(copyArray);

            return new StateHeapSortAutomaton(-1, -1, -1, -1, "", copyArray, dataModel.SortedPart);
        }
    }
}
