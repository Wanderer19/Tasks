using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visualizer
{
    public interface IAutomaton
    {
        StateAutomaton DoStepForward();
        StateAutomaton DoStepBackward();
        StateAutomaton ToStart();
    }
}
