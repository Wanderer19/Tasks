using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;

namespace Visualizer
{
    public class DrawingTools
    {
        public System.Drawing.Font FontDigits { get; private set; }
        public System.Drawing.StringFormat FormatDrawing { get; private set;}
        public System.Drawing.SolidBrush BrushDigit { get; private set;}
        public System.Drawing.SolidBrush BrushElement { get; private set;} 
        public Pen PenElement { get; private set;}

        public DrawingTools(Font font, StringFormat format, SolidBrush brushDigit, SolidBrush brushElement, Pen penElement)
        {
            FontDigits = font;
            FormatDrawing = format;
            BrushDigit = brushDigit;
            BrushElement = brushElement;
            
            PenElement = penElement;
            PenElement.StartCap = LineCap.ArrowAnchor;
            PenElement.EndCap = LineCap.ArrowAnchor;
        }
    }
}
