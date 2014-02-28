using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Visualizer
{
    class BubbleSortAutomate
    {
        internal struct Data
        {
            public int i;
            public int j;
            public int size;
            public int[] array;

            public Data(int[] array)
            {
                size = array.Length;
                this.array = array;
                i = 0;
                j = 0;
            }
        }

        internal struct State
        {
            public string currentState;
            public int secondIndex;
            public int firstIndex;

            public string fullMessage;
            public int state;

            public State(string currState, string message, int i, int j, int state)
            {
                this.currentState = currState;
                this.fullMessage = message;
                this.firstIndex = i;
                this.secondIndex = j;
                this.state = state;
            }
        }

        private Data data;
        private Stack<object> stack;

        public BubbleSortAutomate(int[] array)
        {
            data = new Data(array);
            stack = new Stack<object>();
        }

        public State ReverseAutomate(int state)
        {
            var comment = "";
            var currentState = "";
            var firstIndex = 0;
            var secondIndex = 0;

            var isInterestingState = false;

            while (!isInterestingState)

            {
                switch (state)
                {
                    case 0:
                    {
                        comment = "Начало сортировки";
                  

                        state = -1;

                        break;
                    }
                    case 1:
                    {
                        comment = "Начало цикла, i = 1";
                     

                        state = 0;

                        break;
                    }
                    case 2:
                    {
                        comment = String.Format("Сравнение индекса i =  {0} и длина массива {1}", data.i, data.size);
                  
                        state = data.i <= 1 ? 1 : 9;

                        break;
                    }
                    case 3:
                    {
                        comment = "Начало второго цикла, j = 0";


                        state = 2;

                        break;
                    }
                    case 4:
                    {
                        comment = String.Format("Сравнение индекса j =  {0} и длина массива  - 1 = {1}", data.i,
                            data.size - 1);
                   
                        state = data.j <= 0 ? 3 : 8;

                        break;

                    }
                    case 5:
                    {
                        comment = String.Format("Сравнение элемента с индексом {0} и с индексом {1}", data.j, data.j + 1);
                        isInterestingState = true;
                        firstIndex = data.j;
                        secondIndex = data.j + 1;
                        currentState = "compare";
                        state = 4;

                        break;
                    }
                    case 6:
                    {
                        comment = String.Format("Обмен эелементов и синдексами {0} и {1}", data.j, data.j + 1);
                        isInterestingState = true;
                        firstIndex = data.j;
                        secondIndex = data.j + 1;
                        currentState = "swap";

                        data.array[data.j + 1] = (int)stack.Pop();
                        data.array[data.j] = (int)stack.Pop();

                        state = 5;

                        break;
                    }
                    case 7:
                    {
                        var isTrue = (bool)stack.Pop();
                        state = isTrue ? 6 : 5;

                        break;
                    }
                    case 8:
                    {
                        comment = "Инкремент j";
                       
                        data.j--;

                        state = 7;

                        break;
                    }
                    case 9:
                    {
                        comment = "Инкремент i";
                       
                        data.i--;
                        data.j = data.size - 1;

                        state = 4;

                        break;
                    }
                    case 10:
                    {
                        comment = "Конец сортировки";
                        isInterestingState = true;
                        currentState = "end";

                        state = 2;

                        break;
                    }
                    default:
                    {
                        state = -1;
                        break;
                    }
                }
            }
            return new State(currentState, comment, firstIndex, secondIndex, state);
        }

        public State DirectAutomate(int state)
        {
            var comment = "";
            var isInterestingState = false;
            var currentState = "";
            var firstIndex = 0;
            var secondIndex = 0;

            while (!isInterestingState)
            {
                switch (state)
                {
                    case 0:
                    {
                        state = 1;
                        comment = "Начало сортировки";
                        break;
                    }
                    case 1:
                    {
                        data.i = 1;
                        state = 2;
                        comment = "Начало цикла, i = 1";
                      

                        break;
                    }
                    case 2:
                    {
                        comment = String.Format("Сравнение индекса i =  {0} и длина массива {1}", data.i, data.size);
                       

                        state = data.i < data.size ? 3 : -1;

                        break;
                    }
                    case 3:
                    {
                        comment = "Начало второго цикла, j = 0";
                       
                        data.j = 0;
                        state = 4;

                        break;
                    }
                    case 4:
                    {
                        comment = String.Format("Сравнение индекса j =  {0} и длина массива  - 1 = {1}", data.i,
                            data.size - 1);
              
                        state = data.j < data.size - 1 ? 5 : 9;

                        break;
                    }
                    case 5:
                    {
                        isInterestingState = true;
                        currentState = "compare";
                        firstIndex = data.j;
                        secondIndex = data.j + 1;

                        comment = String.Format("Сравнение элемента с индексом {0} и с индексом {1}", data.j, data.j + 1);
                        
                        if (data.array[data.j] > data.array[data.j + 1])
                        {
                            stack.Push(data.array[data.j]);
                            stack.Push(data.array[data.j + 1]);
                            state = 6;
                        }
                        else
                        {
                            state = 7;

                            stack.Push(false);
                        }

                        break;
                    }
                    case 6:
                    {
                        isInterestingState = true;
                        firstIndex = data.j;
                        secondIndex = data.j + 1;
                        currentState = "swap";

                        comment = String.Format("Обмен эелементов и синдексами {0} и {1}", data.j, data.j + 1);
                      
                        var tmp = data.array[data.j];
                        data.array[data.j] = data.array[data.j + 1];
                        data.array[data.j + 1] = tmp;

                        state = 7;

                        stack.Push(true);

                        break;
                    }
                    case 7:
                    {
                        state = 8;

                        break;
                    }
                    case 8:
                    {
                        comment = "Инкремент j";
                        
                        data.j++;

                        state = 4;

                        break;
                    }
                    case 9:
                    {
                        comment = "Инкремент i";
                    
                        data.i++;

                        state = 2;

                        break;
                    }
                    default:
                    {
                        isInterestingState = true;
                        firstIndex = -1;
                        secondIndex = -1;
                        comment = "Конец";
                        currentState = "end";
                        break;
                    }
                }
            }

            return new State(currentState, comment, firstIndex, secondIndex, state);
        }

        public void Print()
        {
            foreach (var i in data.array)
            {
                Console.WriteLine(i);
            }
        }
    }
}
