using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Visualizer
{
    public interface IVisualizationArray
    {
        void DrawArray(StateAutomaton state, Graphics graphics);
    }
}
