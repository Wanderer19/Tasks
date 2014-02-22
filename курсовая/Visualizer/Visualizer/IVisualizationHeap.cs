using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Visualizer
{
    public interface IVisualizationHeap
    {
        void DrawHeap(StateAutomaton state, Graphics graphics);
    }
}
