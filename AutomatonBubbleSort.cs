using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Visualizer;

namespace Visualizer
{
    public class AutomatonBubbleSort : Automaton
    {
        private class DataModel
        {
            private int firstIndex;
            private int secondIndex;
            public int State { get; set; }
           
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

            public int ArraySize { get; private set; }
            public int[] Array { get; private set; }

            public DataModel(int[] array)
            {
                ArraySize = array.Length;
                Array = array;
                firstIndex = 0;
                secondIndex = 0;
                State = 0;
            }

            public void Swap()
            {
                var copyItem = Array[secondIndex];
                Array[secondIndex] = Array[secondIndex + 1];
                Array[secondIndex + 1] = copyItem;
            }
        }

        public AutomatonBubbleSort(int[] array)
        {
            dataModel = new DataModel(array);
            stack = new Stack<object>();
        }

        private DataModel dataModel;
        private Stack<object> stack;

        public override StateAutomaton DoStepForward()
        {
            var descriptionState = "";
            var isInterestingState = false;
            var stateId = "";
            var firstIndex = -1;
            var secondIndex = -1;

            while (!isInterestingState)
            {
                switch (dataModel.State)
                {
                    case 0:
                    {
                        dataModel.State = 1;

                        break;
                    }
                    case 1:
                    {
                        dataModel.FirstIndex = 1;
                        dataModel.State = 2;

                        break;
                    }
                    case 2:
                    {
                        dataModel.State = dataModel.FirstIndex < dataModel.ArraySize ? 3 : -1;

                        break;
                    }
                    case 3:
                    {
                        dataModel.SecondIndex = 0;
                        dataModel.State = 4;

                        break;
                    }
                    case 4:
                    {
                        dataModel.State = dataModel.SecondIndex < dataModel.ArraySize - 1 ? 5 : 9;

                        break;
                    }
                    case 5:
                    {
                        isInterestingState = true;
                        descriptionState = String.Format("Сравнение элемента с индексом {0} и с индексом {1}",
                            dataModel.SecondIndex, dataModel.SecondIndex + 1);
                        stateId = "compare";

                        firstIndex = dataModel.SecondIndex;
                        secondIndex = dataModel.SecondIndex + 1;

                        if (dataModel.Array[dataModel.SecondIndex] > dataModel.Array[dataModel.SecondIndex + 1])
                        {
                            stack.Push(dataModel.Array[dataModel.SecondIndex]);
                            stack.Push(dataModel.Array[dataModel.SecondIndex + 1]);

                            dataModel.State = 6;
                        }
                        else
                        {
                            stack.Push(false);

                            dataModel.State = 7;
                        }

                        break;
                    }
                    case 6:
                    {
                        isInterestingState = true;
                        descriptionState = String.Format("Обмен эелементов и синдексами {0} и {1}",
                            dataModel.SecondIndex, dataModel.SecondIndex + 1);
                        stateId = "swap";

                        firstIndex = dataModel.SecondIndex;
                        secondIndex = dataModel.SecondIndex + 1;

                        dataModel.Swap();

                        stack.Push(true);

                        dataModel.State = 7;

                        break;
                    }
                    case 7:
                    {
                        dataModel.State = 8;

                        break;
                    }
                    case 8:
                    {
                        dataModel.SecondIndex++;

                        dataModel.State = 4;

                        break;
                    }
                    case 9:
                    {
                        dataModel.FirstIndex++;

                        dataModel.State = 2;

                        break;
                    }
                    default:
                    {
                        isInterestingState = true;
                        descriptionState = "Конец";
                        stateId = "end";

                        break;
                    }
                }
            }

            return new StateBubbleSortAutomaton(firstIndex, secondIndex,stateId,  descriptionState, dataModel.Array, dataModel.State);
        }

        public override StateAutomaton DoStepBackward()
        {
            var descriptionState = "";
            var stateId = "";
            var firstIndex = -1;
            var secondIndex = -1;
            var isInterestingState = false;

            while (!isInterestingState)
            {
                switch (dataModel.State)
                {
                    case 0:
                    {
                        isInterestingState = true;

                        dataModel.State = 0;

                        break;
                    }
                    case 1:
                    {
                        dataModel.State = 0;

                        break;
                    }
                    case 2:
                    {
                        dataModel.State = dataModel.FirstIndex <= 1 ? 1 : 9;

                        break;
                    }
                    case 3:
                    {
                        dataModel.State = 2;

                        break;
                    }
                    case 4:
                    {
                        dataModel.State = dataModel.SecondIndex <= 0 ? 3 : 8;

                        break;
                    }
                    case 5:
                    {
                        descriptionState = String.Format("Сравнение элемента с индексом {0} и с индексом {1}",
                            dataModel.SecondIndex, dataModel.SecondIndex + 1);
                        stateId = "compare";
                        isInterestingState = true;

                        firstIndex = dataModel.SecondIndex;
                        secondIndex = dataModel.SecondIndex + 1;

                        dataModel.State = 4;

                        break;
                    }
                    case 6:
                    {
                        descriptionState = String.Format("Обмен эелементов и синдексами {0} и {1}",
                            dataModel.SecondIndex, dataModel.SecondIndex + 1);
                        stateId = "swap";
                        isInterestingState = true;

                        firstIndex = dataModel.SecondIndex;
                        secondIndex = dataModel.SecondIndex + 1;

                        dataModel.Array[dataModel.SecondIndex + 1] = (int) stack.Pop();
                        dataModel.Array[dataModel.SecondIndex] = (int) stack.Pop();

                        dataModel.State = 5;

                        break;
                    }
                    case 7:
                    {
                        var isTrue = (bool) stack.Pop();

                        dataModel.State = isTrue ? 6 : 5;

                        break;
                    }
                    case 8:
                    {
                        dataModel.SecondIndex--;

                        dataModel.State = 7;

                        break;
                    }
                    case 9:
                    {
                        dataModel.FirstIndex--;
                        dataModel.SecondIndex = dataModel.ArraySize - 1;

                        dataModel.State = 4;

                        break;
                    }
                    case 10:
                    {
                        descriptionState = "Конец сортировки";
                        stateId = "end";
                        isInterestingState = true;

                        dataModel.State = 2;

                        break;
                    }
                    default:
                    {
                        isInterestingState = true;

                        dataModel.State = 10;

                        break;
                    }
                }
            }
            
            return new StateBubbleSortAutomaton(firstIndex, secondIndex, stateId, descriptionState, dataModel.Array, dataModel.State);
        }
    }
}
