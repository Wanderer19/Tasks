using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
                    if (value >= 0 && value <= ArraySize)
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
        public int State { get { return dataModel.State; } }

        public AutomatonShiftDown(int[] array)
        {
            dataModel = new DataModel(array);
        }

        public int DoStepForward(int i, int j)
        {
            var isInterestingState = false;
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
                        dataModel.Index = i;
                        dataModel.State = 3;
                        
                        break;
                    }
                    case 3:
                    {
                        dataModel.State = dataModel.Index*2 < j && !dataModel.IsDone ? 4 : 15;
                       
                        break;
                    }
                    case 4:
                    {
                        dataModel.State = dataModel.Index * 2 == j ? 5 : 6;

                        break;
                    }
                    case 5:
                    {
                        dataModel.MaxChild = dataModel.Index * 2;
                        dataModel.State = 9;
                        
                        break;
                    }
                    case 6:
                    {
                        dataModel.State = dataModel.Array[dataModel.Index*2] > dataModel.Array[dataModel.Index*2 + 1]
                            ? 7
                            : 8;
                        break;
                    }
                    case 7:
                    {
                        dataModel.MaxChild = dataModel.Index * 2;
                        dataModel.State = 9;

                        break;
                    }
                    case 8:
                    {
                        dataModel.MaxChild = dataModel.Index * 2 + 1;
                        dataModel.State = 9;
                        
                        break;
                    }
                    case 9:
                    {
                        dataModel.State = 10;
                        
                        break;
                    }
                    case 10:
                    {
                        dataModel.State = dataModel.Array[dataModel.Index] < dataModel.Array[dataModel.MaxChild]
                            ? 11
                            : 13;
                        
                        break;
                    }
                    case 11:
                    {
                        dataModel.Swap();
                        dataModel.State = 12;
                        
                        break;
                    }
                    case 12:
                    {
                        dataModel.State = 14;
                        
                        break;
                    }
                    case 13:
                    {
                        dataModel.IsDone = true;
                        dataModel.State = 14;
                        
                        break;
                    }
                    case 14:
                    {
                        dataModel.State = 3;
                        
                        break;
                    }
                    case 15:
                    {
                        dataModel.State = 0;
                        
                        break;
                    }

                }
            }

            return dataModel.State;
        
        }

        public override StateAutomaton DoStepBackward()
        {
            return base.DoStepBackward();
        }

        public override StateAutomaton ToStart()
        {
            return base.ToStart();
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

            public int Index
            {
                get { return index; }
                set
                {
                    if (value >= 0 && value <= ArraySize)
                    {
                        index = value;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
            }

            public void Swap()
            {
                var tmp = Array[0];
                Array[0] = Array[Index];
                Array[Index] = tmp;
            }

            public DataModel(int[] array)
            {
                Index = 0;
                ArraySize = array.Length;
                Array = array;
                State = 0;
            }


        }
        
        private AutomatonShiftDown automatonShiftDown;
        public int[] Array { get; private set; }
        private DataModel dataModel;
        private int stepsCount;

        public AutomatonHeapSort(int[] array)
        {
           var copy = (int[]) array.Clone();
           automatonShiftDown = new AutomatonShiftDown(copy);
           dataModel = new DataModel(copy);
           this.Array = array;
            stepsCount = 0;
        }

        public override StateAutomaton DoStepForward()
        {
            var isInterestingState = false;
            stepsCount++;

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
                       if (automatonShiftDown.State != 15)
                       {
                           automatonShiftDown.DoStepForward(dataModel.Index, dataModel.ArraySize);
                           dataModel.State = 3;
                        }
                        else
                        {
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
                       dataModel.Index = dataModel.ArraySize - 1;
                       dataModel.State = 6;
                       
                        break;
                    }
                    case 6:
                    {
                        dataModel.State = dataModel.Index >= 1 ? 7 : 10;

                        break;
                    }
                    case 7:
                    {
                       dataModel.Swap();
                       dataModel.State = 8;
                       
                        break;
                    }
                    case 8:
                    {
                        if (automatonShiftDown.State != 15)
                        {
                            automatonShiftDown.DoStepForward(0, dataModel.Index - 1);
                            dataModel.State = 8;
                        }
                        else
                        {
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
                       dataModel.State = 10;
                       
                        break;
                    }
                }

            }

            return new StateAutomaton();
        }

        public override StateAutomaton DoStepBackward()
        {
            return base.DoStepBackward();
        }

        public override StateAutomaton ToStart()
        {
            return base.ToStart();
        }
    }
}
