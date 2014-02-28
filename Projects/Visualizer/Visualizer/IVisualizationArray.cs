using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Visualizer
{
    public interface IVisualizationArray
    {
    	//Интерфес, предоставляющий функцию для рисования одномерного массива на данное форме и с текущим состоянием
        void DrawArray(StateAutomaton state, Graphics graphics);
    }
}
