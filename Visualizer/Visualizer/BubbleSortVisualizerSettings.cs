using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visualizer
{
    public class BubbleSortVisualizerSettings
    {
        public static readonly Point PositionFirstElement = new Point(3, 200);
        public static readonly int WidthElemet = 100;
        public static readonly Color SelectedElementColor = Color.Fuchsia;
        public static readonly Color ElementColor = Color.LightCyan;
        public static readonly Size ElementSize = new Size(100, 100);
        public static readonly string HelpFile = "hel.txt";
        public static readonly Rectangle UpperCommentField = new Rectangle(0, 0, 1500, 200);
        public static readonly Rectangle BottomCommentField = new Rectangle(300, 400, 1500, 500);
        public static readonly PointF LocationBottomCommentField = new PointF(400, 400);
    }
}
