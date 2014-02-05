using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Visualizer
{
    public class AutomatonSelectionSort : Automaton
    {
        public AutomatonSelectionSort(int[] array)
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
            
            var min = 0;
            
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
                            dataModel.FirstIndex = 0;
                            dataModel.State = 2;
                            
                            stack.Push(false);
                            
                            break;
                        }
                    case 2:
                    {
                        dataModel.State = dataModel.FirstIndex < dataModel.ArraySize - 1 ? 3 : 12;

                        break;
                    }
                    case 3:
                    {
                       
                            stack.Push(dataModel.Min);
                            dataModel.Min = dataModel.FirstIndex;

                            isInterestingState = true;
                            stateId = "min";
                           // descriptionState = String.Format("Текущий минимум = {0}", dataModel.Array[dataModel.Min]);
                            min = dataModel.Min;

                            dataModel.State = 4;
                            break;
                        }
                    case 4:
                        {
                            stack.Push(dataModel.SecondIndex);
                            dataModel.SecondIndex = dataModel.FirstIndex + 1;
                            dataModel.State = 5;
                           
                            stack.Push(false);
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
                        stateId = "compare";
                        descriptionState = String.Format("Сравнение элемента с индексом {0} с текущим минимумом",
                            dataModel.SecondIndex);
                      
                            if (dataModel.Array[dataModel.SecondIndex] < dataModel.Array[dataModel.Min])
                            {
                                dataModel.State = 7;
                            }
                            else
                            {
                                stack.Push(false);
                                dataModel.State = 8;
                            }

                            break;

                        }
                    case 7:
                    {
                        stack.Push(dataModel.Min);

                        dataModel.Min = dataModel.SecondIndex;

                        isInterestingState = true;
                        stateId = "min";
                        min = dataModel.Min;
                        stack.Push(true);
                         
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
                            stack.Push(dataModel.SecondIndex);
                            dataModel.SecondIndex++;
                            dataModel.State = 5;
                            stack.Push(true);
                            break;
                        }
                    case 10:
                        {
                            
                            stack.Push(dataModel.Array[dataModel.FirstIndex]);
                            stack.Push(dataModel.Array[dataModel.Min]);

                            dataModel.Swap(dataModel.FirstIndex, dataModel.Min);

                            isInterestingState = true;
                            stateId = "swap";
                            descriptionState = String.Format("Обмен элемента с индексом {0} с текущим минимумом", dataModel.FirstIndex);
                            dataModel.State = 11;
                            
                            break;

                        }
                    case 11:
                        {
                            stack.Push(dataModel.FirstIndex);
                            dataModel.FirstIndex++;
                            dataModel.State = 2;
                            stack.Push(true);
                            break;
                        }
                    case 12:
                    {
                        isInterestingState = true;
                        stateId = "end";
                        descriptionState = "Конец Сортировки";
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


           // MessageBox.Show(String.Join(",", stack) + "-"+dataModel.State.ToString());
            return new StateAutomaton(descriptionState, stateId, dataModel.State, dataModel.FirstIndex, dataModel.SecondIndex, dataModel.Min);
        }


        public override StateAutomaton DoStepBackward()
        {
           // MessageBox.Show(String.Join(",", stack) + "-" + dataModel.State.ToString());
            var descriptionState = "";
            var isInterestingState = false;
            var stateId = "";
            var firstIndex = -1;
            var secondIndex = -1;
            var min = 0;

             while (!isInterestingState)
            {
                switch (dataModel.State)
                {

                    case 0:
                        {

                            dataModel.State = -1;
                            break;
                        }
                    case 1:
                    {
                        isInterestingState = true;
                            dataModel.State = 0;
                            break;
                        }
                    case 2:
                        {
                            var flag = (bool)stack.Pop();

                            dataModel.State = flag ? 11 : 1;
                            break;
                        }
                    case 3:
                        {

                            dataModel.Min = (int)stack.Pop();
                            dataModel.State = 2;

                            isInterestingState = true;
                            stateId = "min";
                            min = dataModel.Min;
                            descriptionState = String.Format("Текущий минимум = {0}", dataModel.Min);

                            break;
                        }
                    case 4:
                        {
                            dataModel.SecondIndex = (int)stack.Pop();
                            dataModel.State = 3;
                            break;
                        }
                    case 5:
                        {
                            var flag = (bool)stack.Pop();
                            dataModel.State = flag ? 9 : 4;
                            break;
                        }
                    case 6:
                        {
                            isInterestingState = true;
                            stateId = "compare";
                            firstIndex = dataModel.SecondIndex;
                            secondIndex = dataModel.Min;
                            descriptionState = String.Format("Сравнение элементов с индексами {0} и {1}",
                                dataModel.SecondIndex, dataModel.Min);
                            dataModel.State = 5;
                            break;
                        }
                    case 7:
                        {
                         
                            dataModel.Min = (int)stack.Pop();

                            isInterestingState = true;
                            stateId = "min";
                            min = dataModel.Min;
                            descriptionState = String.Format("Текущий минимум = {0}", dataModel.Min);
                         

                            dataModel.State = 6;
                            break;

                        }
                    case 8:
                        {
                            var flag = (bool)stack.Pop();

                            dataModel.State = flag ? 7 : 6;
                            break;
                        }
                    case 9:
                        {
                            dataModel.SecondIndex = (int)stack.Pop();
                            dataModel.State = 8;
                            break;
                        }
                    case 10:
                        {
                            dataModel.Array[dataModel.Min] = (int)stack.Pop();
                            dataModel.Array[dataModel.FirstIndex] = (int)stack.Pop();

                            isInterestingState = true;
                            stateId = "swap";
                            firstIndex = dataModel.FirstIndex;
                            secondIndex = dataModel.Min;

                            descriptionState = String.Format("Обмен элементов с индексами {0} и {1}",
                                dataModel.FirstIndex, dataModel.Min);
                            dataModel.State = 5;
                            break;
                        }
                    case 11:
                        {
                            dataModel.FirstIndex = (int)stack.Pop();
                            dataModel.State = 10;
                            break;
                        }
                    case 12:
                        {
                            isInterestingState = true;
                            stateId = "end";
                            dataModel.State = 2;
                            break;
                        }
                    default:
                    {
                        isInterestingState = true;
                        dataModel.State = -1;
                        break;
                    }
                }
            }

            
            return new StateAutomaton(descriptionState, stateId, dataModel.State, firstIndex, secondIndex, min);
        }

        public override void ToStart()
        {
            var state = this.DoStepBackward();

            while (state.StateNumber != 0)
            {
                state = this.DoStepBackward();
            }
        }
    }
}
