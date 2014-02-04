using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Visualizer
{
    public partial class BubbleSortVisualizer : Visualizer
    {
        public const string StateCompare = "compare";
        public const string StateSwap = "swap";
        
 
        public BubbleSortVisualizer(SortingForm bubbleSortForm, int[] array)
        {
            this.mainForm = bubbleSortForm;
            
            this.sortArray = new SortArray(array);
            this.automatonSort = new AutomatonBubbleSort(array);
            drawingTools = new DrawingTools(BubbleSortVisualizerSettings.FontDigits, BubbleSortVisualizerSettings.FormatDrawing,
                                             BubbleSortVisualizerSettings.BrushDigit, BubbleSortVisualizerSettings.BrushElement, 
                                             BubbleSortVisualizerSettings.PenElement);           
           
            this.Paint += new PaintEventHandler(DrawInitialState);
         }

        public override void DrawState(StateAutomaton stateAutomaton)
        {
            this.ClearComments();

            switch (stateAutomaton.StateId)
            {
                case StateCompare:
                {
                    this.DrawCompare(stateAutomaton.IndexesSelectedItems);
                    break;
                }
                case StateSwap:
                {
                    this.DrawSwap(stateAutomaton.IndexesSelectedItems);
                    break;
                }
            }
            
           this.DrawComment(stateAutomaton.DescriptionState);
        }

        private void ClearComments()
        {
            graphics.FillRectangle(drawingTools.BrushElement, BubbleSortVisualizerSettings.UpperCommentField);
            graphics.FillRectangle(drawingTools.BrushElement, BubbleSortVisualizerSettings.BottomCommentField);
        }

        private void DrawComment(string message)
        {
            graphics.DrawString(message, drawingTools.FontDigits, drawingTools.BrushDigit, BubbleSortVisualizerSettings.LocationBottomCommentField, drawingTools.FormatDrawing);
        }

        private void DrawCompare(Tuple <int, int> indexes)
        {
            this.DrawArray();
            this.DrawCursor(indexes.Item1);
            this.DrawSymbolComparison(indexes.Item1);
        }

        private void DrawCursor(int index)
        {
            var points = new Point[]
            {
                new Point(BubbleSortVisualizerSettings.FirstPointerCoordinates[0].X + index * BubbleSortVisualizerSettings.WidthElemet, BubbleSortVisualizerSettings.FirstPointerCoordinates[0].Y), 
                new Point(BubbleSortVisualizerSettings.FirstPointerCoordinates[1].X + index * BubbleSortVisualizerSettings.WidthElemet, BubbleSortVisualizerSettings.FirstPointerCoordinates[1].Y),
                new Point(BubbleSortVisualizerSettings.FirstPointerCoordinates[2].X + index * BubbleSortVisualizerSettings.WidthElemet, BubbleSortVisualizerSettings.FirstPointerCoordinates[2].Y)
            };

            graphics.DrawCurve(drawingTools.PenElement, points);
        }

        private void DrawSymbolComparison(int index)
        {
            graphics.DrawString(BubbleSortVisualizerSettings.SymbolComparison, drawingTools.FontDigits, drawingTools.BrushDigit, 80 + 100 * index, 100, drawingTools.FormatDrawing);
        }

        private void DrawSwap(Tuple<int, int> indexes)
        {
            sortArray.SelectElements(indexes);
            
            this.DrawArray();
            
            sortArray.DeselectElements(indexes);

        }

        public override void ToStart(object sender, EventArgs e)
        {
           this.ClearComments();
           this.sortArray.DeselectAllElements();
           
           automatonSort.ToStart();

           this.DrawArray();
            
        }
    }
}
