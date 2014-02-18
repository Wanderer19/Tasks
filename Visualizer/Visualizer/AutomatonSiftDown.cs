using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Visualizer
{
    public class AutomatonSiftDown : Automaton
    {
        public enum States
        {
            InitialState = 11,
            InitializeVariables = 12,
            StartLoop = 13,
            Loop = 14,
            InitializingIndexMaximumChild = 15,
            ConditionOnUpdateMaximumChild = 16,
            UpdateMaximalChild = 17,
            EndingConditionOnUpdateMaximumChild = 18,
            ConditionOnUpdateParent = 19,
            SwappingParentWithMaximumChild = 20,
            EndLoop = 21,
            EndingConditionOnUpdateParent = 22,
            FinalState = 23
        }

        private class DataModel
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

        private readonly DataModel dataModel;

        public States State
        {
            get { return dataModel.State; }
            set { dataModel.State = value; }
        }

        public AutomatonSiftDown(int[] array)
        {
            dataModel = new DataModel(array);
        }

        public StateAutomaton DoStepForward(int i, int j, int sortedPart)
        {
            var isInterestingState = false;

            StateAutomaton state = new StateHeapSortAutomaton(-1, -1, -1, (int) dataModel.State, "", dataModel.Array,
                dataModel.SortedPart);

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

                        dataModel.State = dataModel.Counter*2 + 1 < j && !dataModel.IsDone
                            ? States.InitializingIndexMaximumChild
                            : States.FinalState;

                        break;
                    }
                    case States.InitializingIndexMaximumChild:
                    {
                        dataModel.IndexMaximumChild = dataModel.Counter*2 + 1;

                        dataModel.State = States.ConditionOnUpdateMaximumChild;

                        break;
                    }
                    case States.ConditionOnUpdateMaximumChild:
                    {
                        isInterestingState = true;

                        state = GetStateShiftDownAutomaton(dataModel.State);

                        dataModel.State = dataModel.Counter*2 + 2 < j &&
                                          dataModel.Array[dataModel.IndexMaximumChild] <
                                          dataModel.Array[dataModel.Counter*2 + 2]
                            ? States.UpdateMaximalChild
                            : States.EndingConditionOnUpdateMaximumChild;

                        break;
                    }
                    case States.UpdateMaximalChild:
                    {
                        dataModel.IndexMaximumChild = dataModel.Counter*2 + 2;

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

                        dataModel.State = dataModel.Array[dataModel.Counter] <
                                          dataModel.Array[dataModel.IndexMaximumChild]
                            ? States.SwappingParentWithMaximumChild
                            : States.EndLoop;

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
            var comment = "";

            switch (state)
            {
                case States.Loop:
                {
                    comment = String.Format("Просеивание элемента с индексом {0}", dataModel.Counter);

                    return new StateHeapSortAutomaton(-1, -1, dataModel.Counter, (int) state, comment, dataModel.Array,
                        dataModel.SortedPart);
                }
                case States.ConditionOnUpdateMaximumChild:
                {
                    comment = String.Format("Определяем максимального ребёнка элемента с индексом {0}",
                        dataModel.Counter);

                    return new StateHeapSortAutomaton(dataModel.IndexMaximumChild, dataModel.Counter*2 + 2,
                        dataModel.Counter, (int) state, comment, dataModel.Array, dataModel.SortedPart);
                }
                case States.EndingConditionOnUpdateMaximumChild:
                {
                    comment = String.Format("Максимальный ребёнок - элемент с индексом {0}", dataModel.IndexMaximumChild);

                    return new StateHeapSortAutomaton(-1, -1, dataModel.IndexMaximumChild, (int) state, comment,
                        dataModel.Array, dataModel.SortedPart);
                }
                case States.ConditionOnUpdateParent:
                {
                    comment = String.Format("Сравнение значения в узле с его наибольшим ребенком");

                    return new StateHeapSortAutomaton(dataModel.Counter, dataModel.IndexMaximumChild, -1, (int) state,
                        comment, dataModel.Array, dataModel.SortedPart);
                }
                case States.SwappingParentWithMaximumChild:
                {
                    comment = String.Format("Обмен узла с его наибольшим ребёнком");

                    return new StateHeapSortAutomaton(dataModel.Counter, dataModel.IndexMaximumChild, -1, (int) state,
                        comment, dataModel.Array, dataModel.SortedPart);
                }
                case States.EndLoop:
                {
                    comment = String.Format("Конец просеиванию");

                    return new StateHeapSortAutomaton(-1, -1, -1, (int) state, comment, dataModel.Array,
                        dataModel.SortedPart);
                }
                default:
                {
                    return new StateHeapSortAutomaton(-1, -1, -1, (int) state, comment, dataModel.Array,
                        dataModel.SortedPart);
                }
            }
        }
    }
}
