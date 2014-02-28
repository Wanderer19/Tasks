using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Visualizer
{
    public class VisualizationArray : IVisualizationArray   
    {
        private bool[] selectedIndexes = new bool[]{};
        private bool [] indexesSortedPart = new bool[]{};
        private  List<Point> coordinatesElements;
        private int arrayLength;
        
        private readonly System.Drawing.Font digitsFont = new System.Drawing.Font("Arial", 20);
        private readonly System.Drawing.StringFormat formatDrawing = new System.Drawing.StringFormat();
        private readonly System.Drawing.SolidBrush digitsBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
        private readonly System.Drawing.SolidBrush elementsBrush = new System.Drawing.SolidBrush(System.Drawing.Color.LightCyan);
        private readonly Pen elementsPen = new Pen(Color.Blue, 5);
        private readonly System.Drawing.SolidBrush brushSortedPartArray = new SolidBrush(Color.DeepSkyBlue);
        public static readonly Color colorSortedPart = Color.DeepSkyBlue;

        public static readonly Point PositionFirstElement = new Point(3, 100);
        public static readonly int WidthElemet = 70;
        public static readonly Color SelectedElementColor = Color.Fuchsia;
        public static readonly Color ElementColor = Color.LightCyan;
        public static readonly Size ElementSize = new Size(70, 70);

        public VisualizationArray()
        {
        }

        public VisualizationArray(int arrayLength)
        {
            this.arrayLength = arrayLength;
        }

        public void IdentifyCoordinates()
        {
            coordinatesElements = new List<Point>();

            for (var i = 0; i < arrayLength; ++i)
            {
                coordinatesElements.Add(new Point(PositionFirstElement.X + i * WidthElemet, PositionFirstElement.Y));
            }
        }

        public bool IsSelected(int index)
        {
            return selectedIndexes[index];
        }

       
        public Point GetCoordinates(int index)
        {
            return coordinatesElements[index];
        }

        public Color GetColorElement(int index, Point sortedPart)
        {
            if (sortedPart.Y >= 0 && sortedPart.X >= 0 && index >= sortedPart.X && index <= sortedPart.Y)
                return colorSortedPart;

            return this.IsSelected(index) ? SelectedElementColor : ElementColor;
        }

        public void SelectElements(params int [] indexes)
        {
            selectedIndexes = Enumerable.Range(0, arrayLength).Select(i => false).ToArray();

            foreach (var index in indexes.Where(i => i >=0 && i < arrayLength))
            {
                selectedIndexes[index] = true;
            }
        }

        public void DrawArray(StateAutomaton state, Graphics graphics)
        {
            arrayLength = state.Array.Length;
            IdentifyCoordinates();
            SelectElements(state.SelectedElements.ToArray());

            for (var i = 0; i < arrayLength; ++i)
            {
                    var rectangle = new Rectangle(GetCoordinates(i), ElementSize);

                    graphics.FillRectangle(new SolidBrush(GetColorElement(i, state.BoundariesSortedPart)), rectangle);
                    graphics.DrawRectangle(elementsPen, rectangle);
                    graphics.DrawString(state.Array[i].ToString(), digitsFont, digitsBrush,
                    GetCoordinates(i), formatDrawing);
            }

        }
    }
}
