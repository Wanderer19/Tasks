using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Visualizer
{
    public class VisualizationArray
    {
        private readonly bool[] selectedIndexes = new bool[]{};
        private readonly List<Point> coordinatesElements;
        private readonly int arrayLength;
        private readonly System.Drawing.Font digitsFont = new System.Drawing.Font("Arial", 20);
        private readonly System.Drawing.StringFormat formatDrawing = new System.Drawing.StringFormat();
        private readonly System.Drawing.SolidBrush digitsBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
        private readonly System.Drawing.SolidBrush elementsBrush = new System.Drawing.SolidBrush(System.Drawing.Color.LightCyan);
        private readonly Pen elementsPen = new Pen(Color.Blue, 7);
        private readonly System.Drawing.SolidBrush brushSortedPartArray = new SolidBrush(Color.DeepSkyBlue);

        public VisualizationArray(int arrayLength)
        {
            this.arrayLength = arrayLength;
            
            selectedIndexes = Enumerable.Range(0, arrayLength).Select(i => false).ToArray();
            
            coordinatesElements = new List<Point>();
            
            for (var i = 0; i < arrayLength; ++i)
            {
                coordinatesElements.Add(new Point(BubbleSortVisualizerSettings.PositionFirstElement.X + i * BubbleSortVisualizerSettings.WidthElemet,
                    BubbleSortVisualizerSettings.PositionFirstElement.Y));
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

        public Color GetColorElement(int index)
        {
            return this.IsSelected(index)
                    ? BubbleSortVisualizerSettings.SelectedElementColor
                    : BubbleSortVisualizerSettings.ElementColor;
        }

        private void SelectElement(int index)
        {
            selectedIndexes[index] = true;
        }

        private void DeselectElement(int index)
        {
            selectedIndexes[index] = false;
        }
       
        public void SelectElements(params int [] indexes)
        {
            foreach (var index in indexes)
            {
                this.SelectElement(index);
            }
        }

        public void DeselectElements(params int [] indexes)
        {
            foreach (var index in indexes)
            {
                this.DeselectElement(index);
            }
        }

        public void DeselectAllElements()
        {
            for (var i = 0; i < arrayLength; ++i)
                selectedIndexes[i] = false;
        }

        public void DrawArray(int[] array, Graphics graphics)
        {
            if (array.Length == arrayLength)
            {
                for (var i = 0; i < arrayLength; ++i)
                {
                    var rectangle = new Rectangle(GetCoordinates(i), BubbleSortVisualizerSettings.ElementSize);

                    graphics.FillRectangle(new SolidBrush(GetColorElement(i)), rectangle);
                    graphics.DrawRectangle(elementsPen, rectangle);
                    graphics.DrawString(array[i].ToString(), digitsFont, digitsBrush,
                        GetCoordinates(i), formatDrawing);
                }
            }
            else
            {
                throw new Exception();
            }
        }


        public  void DrawSortedPartArray(StateAutomaton state, Graphics graphics)
        {
            for (var i = 0; i <= state.FirstIndex; ++i)
            {
                var rectangle = new System.Drawing.Rectangle(GetCoordinates(i), BubbleSortVisualizerSettings.ElementSize);

                graphics.FillRectangle(brushSortedPartArray, rectangle);
                graphics.DrawRectangle(elementsPen, rectangle);
                graphics.DrawString(state.Array[i].ToString(), digitsFont, digitsBrush, GetCoordinates(i), formatDrawing);
            }
        }
    }
}
