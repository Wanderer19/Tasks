using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Visualizer
{
    class DrawingToolsHeapSort
    {
        public Font DigitsFont
        {
            get
            {
                return new System.Drawing.Font("Arial Black", 16.2F, System.Drawing.FontStyle.Bold,
                    System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            }
        }

        public Pen EdgesPen
        {
            get { return new Pen(Color.Blue, 2); }
        }

    }
}
