using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication14
{
    public class ShiftAutomate
    {
        private struct DataModel
        {
            public bool done;
            public int maxChild;
            public int state;
            public int i;


        }

        private DataModel data;

        public ShiftAutomate()
        {
            data = new DataModel();
        }

        public int DoStepForward(int i, int j, int[] array)
        {
            switch (data.state)
            {
                case 0:
                {
                    data.state = 1;
                    break;
                }
                case 1:
                {
                    data.done = false;
                    data.state = 2;
                    break;

                }
                case 2:
                {
                    data.i = i;
                    data.state = 3;
                    break;
                }
                case 3:
                {
                    if (((data.i * 2) < j) && (!data.done))
                    {
                        data.state = 4;
                        break;
                    }
                    else
                    {
                        data.state = 15;
                        break;
                    }
                }
                case 4:
                {
                    if (data.i * 2 == j)
                    {
                        data.state = 5;
                        break;
                    }
                    else
                    {
                        data.state = 6;
                        break;
                    }
                }
                case 5:
                {
                    data.maxChild = data.i * 2;
                    data.state = 9;
                    break;
                }
                case 6:
                {
                    if (array[data.i * 2] > array[data.i * 2 + 1])
                    {
                        data.state = 7;
                        break;
                    }
                    else
                    {
                        data.state = 8;
                        break;
                    }
                }
                case 7:
                {
                    data.maxChild = data.i * 2;
                    data.state = 9;
                    break;
                }
                case 8:
                {
                    data.maxChild = data.i * 2 + 1;
                    data.state = 9;
                    break;
                }
                case 9:
                {
                    data.state = 10;
                    break;
                }
                case 10:
                {
                    if (array[data.i] < array[data.maxChild])
                    {
                        data.state = 11;
                        break;
                    }
                    else
                    {
                        data.state = 13;
                        break;
                    }
                }
                case 11:
                {
                    
                    var tmp = array[data.i];
                    array[data.i] = array[data.maxChild];
                    array[data.maxChild] = tmp;
                    data.i = data.maxChild;
                    data.state = 12;
                    break;
                }
                case 12:
                {
                    
                    data.state = 14;
                    break;
                }
                case 13:
                {
                    data.done = true;
                    data.state = 14;
                    break;
                }
                case 14:
                {
                    data.state = 3;
                    break;
                }
                case 15:
                {
                    data.state = 0;
                    break;
                }

            }

            return data.state;
        }
    }

    public class MainAutomate
    {
        private struct DataModel
        {
            public int i;
            public int length;
            public int[] array;
            public int state;
            public int shiftState;

            public DataModel(int[] array)
            {
                i = 0;
                length = array.Length;
                this.array = array;
                state = 0;
                shiftState = 0;
            }
        }

        private DataModel data;
        private ShiftAutomate shift;

        public MainAutomate(int[] array)
        {
            data = new DataModel(array);
            shift = new ShiftAutomate();
        }

        public int DoStepForward()
        {
            //Console.WriteLine(data.state);
            switch (data.state)
            {
                case 0:
                {
                    data.state = 1;
                    break;
                }
                case 1:
                {
                    data.i = (data.length/2)-1;
                    data.state = 2;
                    break;
                }
                case 2:
                {
                    if (data.i >= 0)
                    {
                        data.state = 3;
                        break;
                    }
                    else
                    {
                        data.state = 5;
                        break;
                    }
                }
                case 3:
                {
                    if (data.shiftState != 15)
                    {
                        data.shiftState = shift.DoStepForward(data.i, data.length, data.array);
                        data.state = 3;
                    }
                    else
                    {
                        data.state = 4;
                        data.shiftState = 0;
                    }
                    
                    break;
                }
                case 4:
                {
                    data.i --;
                    data.state = 2;
                    break;
                }
                case 5:
                {
                    data.i = data.length - 1;
                    data.state = 6;
                    break;
                }
                case 6:
                {
                    if (data.i >= 1)
                    {
                        data.state = 7;
                        break;
                    }
                    else
                    {
                        data.state = 10;
                        break;
                    }
                }
                case 7:
                {
                    var tmp = data.array[0];
                    data.array[0] = data.array[data.i];
                    data.array[data.i] = tmp;

                    data.state = 8;
                    break;
                }
                case 8:
                {
                    if (data.shiftState != 15)
                    {
                        data.shiftState = shift.DoStepForward(0, data.i - 1, data.array);
                        data.state = 8;
                    }
                    else
                    {
                        data.shiftState = 0;
                        data.state = 9;
                    }
                    break;
                }
                case 9:
                {
                    data.i --;
                    data.state = 6;
                    break;
                }
                case 10:
                {
                    data.state = 10;
                    break;
                }
            }

            return data.state;
        }

        public void Print()
        {
            foreach (var i in data.array)
            {
                Console.WriteLine(i);
            }
        }
    }

    class Program
    {
        

       
        static void Main(string[] args)
        {
            var a = new int[] {1, -2, 3, 4, 0, -100, 500, 20};
          
            var automate = new MainAutomate(a);

            var state = automate.DoStepForward();

            while (state != 10)
            {
                state = automate.DoStepForward();
            }

            automate.Print();
        }
    }
}
