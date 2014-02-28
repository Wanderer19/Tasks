using System.Drawing;

namespace Visualizer
{
    class BubbleSortFormSettings : SortingFormSettings
    {
        public override string MainTitleText { get { return "Пузырьковая Сортировка"; } }
        public override string AboutSortingFile { get { return "bubbleSort.txt"; } }
        public override string SourceCodeCSharp { get { return "BubleSort(c#).txt"; } }
        public override string SourceCodeCPlusPlus { get { return "BubleSort(c++).txt"; } }
        public override string SourceCodeJava { get { return "BubleSort(java).txt"; } }
        public override string SourceCodePython { get { return "BubleSort(python).txt"; } }
        public override int SortID { get { return 1; } }
        public readonly Point PositionFirstElement = new Point(3, 200);
        public readonly int WidthElemet = 100;
        public readonly Color SelectedElementColor = Color.Fuchsia;
        public readonly Color ElementColor = Color.LightCyan;
        public readonly Size ElementSize = new Size(100, 100);
        public readonly string HelpFile = "help.txt";
        public readonly Rectangle UpperCommentField = new Rectangle(0, 0, 1500, 200);
        public readonly Rectangle BottomCommentField = new Rectangle(300, 400, 1500, 500);
        public readonly PointF LocationBottomCommentField = new PointF(400, 400);
        public readonly System.Drawing.Font FontDigits = new System.Drawing.Font("Arial", 20);
        public readonly System.Drawing.StringFormat FormatDrawing = new System.Drawing.StringFormat();
        public  readonly System.Drawing.SolidBrush BrushDigit = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
        public  readonly System.Drawing.SolidBrush BrushElement = new System.Drawing.SolidBrush(System.Drawing.Color.LightCyan);
        public  readonly Pen PenElement = new Pen(Color.Blue, 7);
        public  readonly string SymbolComparison = "VS";
        public  readonly Point[] FirstPointerCoordinates = new Point[] { new Point(53, 180), new Point(100, 155), new Point(153, 180) };
    }
}