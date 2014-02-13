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

        public virtual StateAutomaton DoStepForward()
        {
            throw new NotImplementedException();
        }

        public virtual StateAutomaton DoStepBackward()
        {
            var newStepsCount = StepsCount-1;
            StepsCount = 0;
            var state = new StateAutomaton();

            if (newStepsCount + 1 == 0)
                return state;
            
            while (StepsCount != newStepsCount)
            {
                state = DoStepForward();
            }

            return state;
        
        }

        public virtual StateAutomaton ToStart()
        {
            var stateAutomaton = this.DoStepBackward();

            while (stateAutomaton.StateNumber != 0)
            {
                stateAutomaton = this.DoStepBackward();
            }

            return stateAutomaton;
        }
    }
}
