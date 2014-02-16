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
        public enum States
        {
            InitialState = 0,
            StartOuterLoop = 1,
            OuterLoop = 2,
            StartInnerLoop = 3,
            InnerLoop = 4,
            Condition = 5,
            SwappingAdjacentElements = 6,
            EndingConditions = 7,
            IncrementInnerCounter = 8,
            IncrementOuterCounter = 9,
            FinalState = 10
        }

        private class DataModel
        {
            public int OuterCounter { get; set; }
            public int InnerCounter { get; set; }
            public States State { get; set; }
           

            public int ArraySize { get; private set; }
            public int[] Array { get; private set; }

            public DataModel(int[] array)
            {
                ArraySize = array.Length;
                Array = array;
                OuterCounter = 0;
                InnerCounter = 0;
                State = States.InitialState;
            }

            public void SwapAdjacentElements()
            {
                var copyItem = Array[InnerCounter];
                Array[InnerCounter] = Array[InnerCounter + 1];
                Array[InnerCounter + 1] = copyItem;
            }
        }

        public AutomatonBubbleSort(int[] array)
        {
            dataModel = new DataModel(array);
            
            this.array = (int[])array.Clone();
        }

        private DataModel dataModel;

        public override StateAutomaton DoStepForward()
        {
            var isInterestingState = false;

            StateAutomaton state = new StateBubbleSortAutomaton(-1, -1, (int)dataModel.State, "", dataModel.Array);

            StepsCount++;
            while (!isInterestingState)
            {
                switch (dataModel.State)
                {
                    case States.InitialState:
                    {
                        dataModel.State = States.StartOuterLoop;

                        break;
                    }
                    case States.StartOuterLoop:
                    {
                        dataModel.OuterCounter = 1;

                        dataModel.State = States.OuterLoop;

                        break;
                    }
                    case States.OuterLoop:
                    {
                        dataModel.State = dataModel.OuterCounter < dataModel.ArraySize ? States.StartInnerLoop : States.FinalState;

                        break;
                    }
                    case States.StartInnerLoop:
                    {
                        dataModel.InnerCounter = 0;
                        
                        dataModel.State = States.InnerLoop;

                        break;
                    }
                    case States.InnerLoop:
                    {
                        dataModel.State = dataModel.InnerCounter < dataModel.ArraySize - 1 ? States.Condition : States.IncrementOuterCounter;

                        break;
                    }
                    case States.Condition:
                    {
                        isInterestingState = true;
                        state = GetStateBubbleSortAutomaton(dataModel.State);

                        dataModel.State = dataModel.Array[dataModel.InnerCounter] > dataModel.Array[dataModel.InnerCounter + 1] ? 
                            States.SwappingAdjacentElements : States.EndingConditions;

                        break;
                    }
                    case States.SwappingAdjacentElements:
                    {
                        isInterestingState = true;
                        state = GetStateBubbleSortAutomaton(dataModel.State);

                        dataModel.SwapAdjacentElements();
                        
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
                    case States.IncrementOuterCounter:
                    {
                        dataModel.OuterCounter++;

                        dataModel.State = States.OuterLoop;

                        break;
                    }
                    case States.FinalState:
                    {
                        isInterestingState = true;

                        state = GetStateBubbleSortAutomaton(dataModel.State);

                        break;
                    }
                }
            }

            return state;
        }

        public StateAutomaton GetStateBubbleSortAutomaton(States state)
        {
            var stateId = "";
            var comment = "";

            switch (state)
            {
                case States.Condition:
                {
                    comment = String.Format("Сравнение элемента с индексом {0} и с индексом {1}",
                            dataModel.InnerCounter, dataModel.InnerCounter + 1);

                    return new StateBubbleSortAutomaton(dataModel.InnerCounter, dataModel.InnerCounter + 1, (int)dataModel.State, comment, dataModel.Array);
                }
                case States.SwappingAdjacentElements:
                {
                    comment = String.Format("Обмен эелементов и синдексами {0} и {1}",
                            dataModel.InnerCounter, dataModel.InnerCounter + 1);

                    return new StateBubbleSortAutomaton(dataModel.InnerCounter, dataModel.InnerCounter + 1, (int)dataModel.State, comment, dataModel.Array);
                }
                case States.FinalState:
                {
                    return new StateBubbleSortAutomaton(-1, -1, (int)dataModel.State, comment, dataModel.Array);
                }
                default:
                {
                    return new StateBubbleSortAutomaton(-1, -1, (int) dataModel.State, comment, dataModel.Array);
                }
            }
        }

        public override StateAutomaton DoStepBackward()
        {
            dataModel = new DataModel((int[])array.Clone());
            
            return base.DoStepBackward();
        }

        public override StateAutomaton ToStart()
        {
            StepsCount = 0;
            dataModel = new DataModel((int[])array.Clone());

            return new StateBubbleSortAutomaton(-1, -1, (int)dataModel.State, "", dataModel.Array);
        }
    }
}
