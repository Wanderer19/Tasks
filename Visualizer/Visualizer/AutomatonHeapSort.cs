using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Visualizer
{
    class AutomatonShiftDown :Automaton
    {
        private class  DataModel 
        {
            public bool IsDone { get; set; }
            public int State { get; set; }
            private int index;
            public int[] Array { get; private set; }
            public int ArraySize { get; private set; }
            public int MaxChild { get; set; }
            public int SortedPart { get; set; }
            public DataModel(int[] array)
            {
                Array = array;
                ArraySize = array.Length;
                State = 0;
                index = 0;
                MaxChild = 0;
                IsDone = false;
            }

            public void Swap()
            {
                var tmp = Array[Index];
                Array[Index] = Array[MaxChild];
                Array[MaxChild] = tmp;
                
                Index = MaxChild;
            }

            public int Index
            {
                get { return index; }
                set
                {
                    if (value >= 0)
                    {
                        index = value;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
            }
        }

        private DataModel dataModel;
        public int State { get { return dataModel.State; } set { dataModel.State = value; }}

        public AutomatonShiftDown(int[] array)
        {
            dataModel = new DataModel(array);
        }

        public StateAutomaton DoStepForward(int i, int j, int sortedPart)
        {
            var isInterestingState = false;
           // MessageBox.Show(i.ToString());
            StateAutomaton state = new StateHeapSortAutomaton(-1, -1, -1, "", "", dataModel.Array, dataModel.SortedPart);

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
                        dataModel.IsDone = false;
                        dataModel.State = 2;
                        
                        break;
                    }
                    case 2:
                    {

                        dataModel.SortedPart = sortedPart;
                        dataModel.Index = i;
                        dataModel.State = 3;
                        
                        break;
                    }
                    case 3:
                    {
                        isInterestingState = true;
                        state = GetStateShiftDownAutomaton(3);
                        dataModel.State = dataModel.Index*2 + 1 < j && !dataModel.IsDone ? 4 : 12;
                        //MessageBox.Show(dataModel.State.ToString());
                        break;
                    }
                    case 4:
                    {
                        dataModel.MaxChild = dataModel.Index*2 + 1;
                        dataModel.State = 5;

                        break;
                    }
                    case 5:
                    {
                        isInterestingState = true;
                        state = GetStateShiftDownAutomaton(5);
                        dataModel.State = dataModel.Index*2 + 2 < j &&
                                          dataModel.Array[dataModel.MaxChild] < dataModel.Array[dataModel.Index*2 + 2]
                            ? 6
                            : 7;
                        
                        break;
                    }
                    case 6:
                    {
                        dataModel.MaxChild = dataModel.Index * 2 + 2;
                        dataModel.State = 7;
                        
                        break;
                    }
                    case 7:
                    {
                        isInterestingState = true;
                        state = GetStateShiftDownAutomaton(7);
                        dataModel.State = 8;

                        break;
                    }
                    case 8:
                    {
                        isInterestingState = true;
                        state = GetStateShiftDownAutomaton(8);
                        dataModel.State = dataModel.Array[dataModel.Index] < dataModel.Array[dataModel.MaxChild] ? 9 : 10;
                        
                        break;
                    }
                    case 9:
                    {
                        isInterestingState = true;
                        state = GetStateShiftDownAutomaton(9);
                        dataModel.Swap();
                        dataModel.State = 11;
                        break;
                    }
                    case 10:
                    {
                        state = GetStateShiftDownAutomaton(10);
                        isInterestingState = true;
                        dataModel.IsDone = true;
                        dataModel.State = 11;
                        break;
                    }
                    case 11:
                    {
                       
                        dataModel.State = 3;
                        
                        break;
                    }
                    case 12:
                    {
                        state = GetStateShiftDownAutomaton(10);
                        isInterestingState = true;
                        dataModel.State = 0;
                        
                        break;
                    }
                    

                }
            }

            return state;

        }

        public StateAutomaton GetStateShiftDownAutomaton(int state)
        {
            var stateId = "";
            var comment = "";

            switch (state)
            {
                case 3:
                {
                    stateId = "shifting";
                    comment = String.Format("Просеивание элемента с индексом {0}", dataModel.Index);

                    return new StateHeapSortAutomaton(-1, -1, dataModel.Index, stateId, comment, dataModel.Array, dataModel.SortedPart);
                }
                case 5:
                    {
                        stateId = "compare";
                        comment = String.Format("Определяем максимального ребёнка элемента с индексом {0}", dataModel.Index);

                        return new StateHeapSortAutomaton(dataModel.MaxChild, dataModel.Index * 2 + 2, dataModel.Index, stateId, comment, dataModel.Array, dataModel.SortedPart);
                    }
                case 7:
                {
                    stateId = "maxChild";
                    comment = String.Format("Максимальный ребёнок - элемент с индексом {0}", dataModel.MaxChild);

                    return new StateHeapSortAutomaton(-1, -1, dataModel.MaxChild, stateId, comment, dataModel.Array, dataModel.SortedPart);
                }
                case 8:
                {
                    stateId = "compare";
                    comment = String.Format("Сравнение значения в узле с его наибольшим ребенком");

                    return new StateHeapSortAutomaton(dataModel.Index, dataModel.MaxChild, -1, stateId, comment, dataModel.Array, dataModel.SortedPart);
                }
                case 9:
                {
                    stateId = "swap";
                    comment = String.Format("Обмен узла с его наибольшим ребёнком");

                    return new StateHeapSortAutomaton(dataModel.Index, dataModel.MaxChild, -1, stateId, comment, dataModel.Array, dataModel.SortedPart);
                }
                case 10:
                {
                    stateId = "endShifting";
                    comment = String.Format("Конец просеиванию");

                    return new StateHeapSortAutomaton(-1, -1, -1, stateId, comment, dataModel.Array, dataModel.SortedPart);
                }

                default:
                {
                    //stateId = "start";
                    return new StateHeapSortAutomaton(-1, -1, -1, stateId, comment, dataModel.Array, dataModel.SortedPart);
                }

            }
        }
    }
    
    class AutomatonHeapSort : Automaton
    {
        private class DataModel
        {
            private int index;
            public int ArraySize { get; private set; }
            public int[] Array { get; set; }
            public int State { get; set; }
            public int SortedPart { get; set; }

            public int Index
            {
                get { return index; }
                set
                {
                  index = value;
                    
                    
                }
            }

            public void Swap()
            {
                var tmp = Array[0];
                Array[0] = Array[Index - 1];
                Array[Index - 1] = tmp;
            }

            public DataModel(int[] array)
            {
                Index = 0;
                ArraySize = array.Length;
                Array = array;
                State = 0;
                SortedPart = -1;
            }


        }
        
        private AutomatonShiftDown automatonShiftDown;
        private int[] array;
        private DataModel dataModel;

        public AutomatonHeapSort(int[] array)
        {
           //var copy = (int[]) array.Clone();
           automatonShiftDown = new AutomatonShiftDown(array);
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
                    case 0:
                    {
                        dataModel.State = 1;
                        break;
                    }
                    case 1:
                    {
                       dataModel.Index = (dataModel.ArraySize / 2) - 1;
                       dataModel.State = 2;
                       
                        break;
                    }
                    case 2:
                    {
                        dataModel.State = dataModel.Index >= 0 ? 3 : 5;

                        break;
                    }
                    case 3:
                    {
                     
                        
                       if (automatonShiftDown.State != 12)
                       {
                           isInterestingState = true;
                           state = automatonShiftDown.DoStepForward(dataModel.Index, dataModel.ArraySize, dataModel.SortedPart);
                           dataModel.State = 3;
                        }
                        else
                       {
                           automatonShiftDown.State = 0;

                          // MessageBox.Show("yes");
                           dataModel.State = 4;
                        }

                        break;
                    }
                    case 4:
                    {
                        dataModel.Index--;
                        dataModel.State = 2;

                        break;
                    }
                    case 5:
                    {
                       dataModel.Index = dataModel.ArraySize;
                       dataModel.State = 6;
                       
                        break;
                    }
                    case 6:
                    {
                        dataModel.State = dataModel.Index > 0 ? 7 : 10;

                        break;
                    }
                    case 7:
                    {
                        state = GetStateHeapSortAutomaton(7);
                        isInterestingState = true;
                       dataModel.Swap();
                        dataModel.SortedPart = dataModel.Index - 1;
                       dataModel.State = 8;
                       // MessageBox.Show(dataModel.State.ToString());
                      
                       
                        break;
                    }
                    case 8:
                    {
                        
                        if (automatonShiftDown.State != 12)
                        {
                            isInterestingState = true;
                            state = automatonShiftDown.DoStepForward(0, dataModel.Index - 1, dataModel.SortedPart);
                            dataModel.State = 8;
                        }
                        else
                        {
                            automatonShiftDown.State = 0;
                            dataModel.State = 9;
                        }
                        
                        break;
                    }
                    case 9:
                    {
                       dataModel.Index--;
                       dataModel.State = 6;
                       
                        break;
                    }
                    case 10:
                    {
                        state = GetStateHeapSortAutomaton(10);
                        isInterestingState = true;
                        dataModel.State = 10;
                       
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
            automatonShiftDown = new AutomatonShiftDown(copyArray);

            if (StepsCount - 1 == 0)
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
                    stateId = automatonShiftDown.State != 12 ? "shifting" : "endShifting";
                    comment = "";//String.Format("Просеивание элемента с инексом {0}", dataModel.Index);

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
            automatonShiftDown = new AutomatonShiftDown(copyArray);

            return new StateSelectionSortAutomaton();
        }
    }
}
