using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Visualizer
{
    public class AutomatonSelectionSort : Automaton
    {
        private class DataModel
        {
            private int firstIndex;
            private int secondIndex;
            private int minIndex;
            public int State { get; set; }
            public int BorderSortedPart { get; set; }

            public int FirstIndex
            {
                get { return firstIndex; }
                set
                {
                    if (value <= ArraySize && value >= 0)
                    {
                        firstIndex = value;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
            }

            public int SecondIndex
            {
                get { return secondIndex; }
                set
                {
                    if (value <= ArraySize && value >= 0)
                    {
                        secondIndex = value;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
            }

            public int Min
            {
                get { return minIndex; }
                set
                {
                    if (value <= ArraySize && value >= 0)
                    {
                        minIndex = value;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
            }

            public int ArraySize { get; private set; }
            public int[] Array { get; private set; }

            public DataModel(int[] array)
            {
                ArraySize = array.Length;
                Array = array;
                firstIndex = 0;
                secondIndex = 0;
                minIndex = 0;
                State = 0;
                BorderSortedPart = -1;
            }

            public void Swap()
            {
                var copyItem = Array[FirstIndex];
                Array[FirstIndex] = Array[Min];
                Array[Min] = copyItem;

                BorderSortedPart = FirstIndex;
            }
        }

        public AutomatonSelectionSort(int[] array)
        {
            dataModel = new DataModel((int[])array.Clone());
            this.array = (int[]) array.Clone();
            stepsCount = 0;
        }

        private DataModel dataModel;
        private readonly int[] array;
        private int stepsCount;

        public override StateAutomaton DoStepForward()
        {
            var isInterestingState = false;
            stepsCount++;

            var state = new StateSelectionSortAutomaton();

            while (!isInterestingState)
            {

                switch (dataModel.State)
                {
                    case 0:
                    {
                        dataModel.BorderSortedPart = -1;
                       dataModel.State = 1;
                       
                        break;
                    }
                    case 1:
                        {
                            dataModel.FirstIndex = 0;
                            dataModel.State = 2;
                            
                            break;
                        }
                    case 2:
                    {
                        dataModel.State = dataModel.FirstIndex < dataModel.ArraySize - 1 ? 3 : 12;

                        break;
                    }
                    case 3:
                    {
                        dataModel.Min = dataModel.FirstIndex;
                        isInterestingState = true;
                        state = GetStateSelectionSortAutomaton(3);
                        dataModel.State = 4;
                            
                        break;
                    }
                    case 4:
                        {
                            dataModel.SecondIndex = dataModel.FirstIndex + 1;
                            dataModel.State = 5;
                           
                            break;

                        }
                    case 5:
                    {
                        dataModel.State = dataModel.SecondIndex < dataModel.ArraySize ? 6 : 10;
                        
                        break;
                    }
                    case 6:
                    {
                        isInterestingState = true;
                        state = GetStateSelectionSortAutomaton(6);
                        dataModel.State = dataModel.Array[dataModel.SecondIndex] < dataModel.Array[dataModel.Min] ? 7 : 8;

                     
                        break;

                        }
                    case 7:
                    {

                        dataModel.Min = dataModel.SecondIndex;
                        isInterestingState = true;
                        state = GetStateSelectionSortAutomaton(7);
                        dataModel.State = 8;
                         
                        break;

                    }
                    case 8:
                        {
                            dataModel.State = 9;
                            break;

                        }
                    case 9:
                        {
                            
                            dataModel.SecondIndex++;
                            dataModel.State = 5;
                            
                            break;
                        }
                    case 10:
                        {

                            dataModel.Swap();
                            state = GetStateSelectionSortAutomaton(10);
                            isInterestingState = true;
                           
                            dataModel.State = 11;
                            
                            break;

                        }
                    case 11:
                        {
                            dataModel.FirstIndex++;
                            dataModel.State = 2;
                            
                            break;
                        }
                    case 12:
                    {
                     
                        isInterestingState = true;
                        dataModel.BorderSortedPart = dataModel.ArraySize - 1;

                        state = GetStateSelectionSortAutomaton(12);
                        dataModel.State = -1;
                            break;
                        }
                    default:
                        {
                            dataModel.State = 12;
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
                    descriptionState = String.Format("Сравнение элемента с индексом {0} с текущим минимумом", dataModel.SecondIndex);
                    
                    selectedIndexes.Add(dataModel.SecondIndex);

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
                    descriptionState = String.Format("Обмен элемента с индексом {0} с текущим минимумом", dataModel.FirstIndex);

                    selectedIndexes.Add(dataModel.FirstIndex);
                    selectedIndexes.Add(dataModel.Min);
                    
                   break;
                }
                case 12:
                {
                    stateId = "end";
                    descriptionState = "Конец Сортировки";
                    break;
                }
            }

            return new StateSelectionSortAutomaton(selectedIndexes, dataModel.BorderSortedPart, dataModel.Array[dataModel.Min], stateId, descriptionState, dataModel.Array);
        }

        public override StateAutomaton DoStepBackward()
        {

            dataModel = new DataModel((int[]) array.Clone());
            var newStepsCount = stepsCount-1;
            stepsCount = 0;
            StateAutomaton state = new StateSelectionSortAutomaton();

            if (newStepsCount + 1 == 0) return state;
            
            while (stepsCount != newStepsCount)
            {
                state = DoStepForward();
            }

            return state;
        }

        public override StateAutomaton ToStart()
        {
            stepsCount = 0;
            dataModel = new DataModel((int[])array.Clone());

            return new StateSelectionSortAutomaton();
        }
    }
}
