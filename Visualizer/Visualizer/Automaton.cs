using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Visualizer
{
    public class Automaton : IAutomaton
    {
        public virtual StateAutomaton DoStepForward()
        {
            throw new NotImplementedException();
        }

        public virtual StateAutomaton DoStepBackward()
        {
            throw new NotImplementedException();
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
