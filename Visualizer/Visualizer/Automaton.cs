using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Visualizer
{
    public class Automaton : IAutomaton
    {
        public static string StateEnd = "end";
        public static string StateStart = "start";
        protected int StepsCount = 0;
        protected int[] array;

        public virtual StateAutomaton DoStepForward()
        {
            throw new NotImplementedException();
        }

        public virtual StateAutomaton DoStepBackward()
        {
            if (StepsCount - 1 == 0 || StepsCount == 0)
            {
                return new StateAutomaton(array);
            }

            var newStepsCount = StepsCount-1;
            StepsCount = 0;
            var state = new StateAutomaton(array);

            while (StepsCount != newStepsCount)
            {
                state = DoStepForward();
            }

            return state;
        
        }

        public virtual StateAutomaton ToStart()
        {
            return new StateAutomaton(array);
        }
    }
}
