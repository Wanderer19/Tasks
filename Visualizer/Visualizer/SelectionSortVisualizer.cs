using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Visualizer
{
    public partial class SelectionSortVisualizer : Visualizer
    {
        public const string StateCompare = "compare";
        public const string StateSwap = "swap";
        public const string StateMin = "min";
        private List<int> sortedPartArray = new List<int>();

        public SelectionSortVisualizer(SortingForm mainForm, int [] array)
        {
            this.mainForm = mainForm;

            this.sortArray = new SortArray(array);
            this.automatonSort = new AutomatonSelectionSort(array);
            drawingTools = new DrawingTools(BubbleSortVisualizerSettings.FontDigits, BubbleSortVisualizerSettings.FormatDrawing,
                                             BubbleSortVisualizerSettings.BrushDigit, BubbleSortVisualizerSettings.BrushElement,
                                             BubbleSortVisualizerSettings.PenElement);
            InitializeComponent();
            sortId = 2;
            this.Paint += new PaintEventHandler(DrawInitialState);
        }

        public override void DrawState(StateAutomaton stateAutomaton)
        {
            this.ClearComments();
           
            switch (stateAutomaton.StateId)
            {

                case StateCompare:
                    {
                        this.DrawMin(stateAutomaton.Min);
                        this.DrawCompare(stateAutomaton.IndexesSelectedItemsCompare);
                        
                        break;
                    }
                case StateSwap:
                    {
                        sortedPartArray.Add(stateAutomaton.FirstIndex);
                        this.DrawSwap(stateAutomaton.IndexesSelectedItemsSwap);
                        break;
                    }
                case StateMin:
                {
                    this.DrawArray();
                    this.DrawMin(stateAutomaton.Min);
                    break;
                }
                default:
                {
                    sortedPartArray.Add(sortArray.Length - 1);
                    break;
                }
            }

            this.DrawSortedPartArray();

            this.DrawComment(stateAutomaton.DescriptionState);
        }

        private void DrawMin(int index)
        {
            graphics.DrawString(String.Format("Текущий минимум  = {0}", this.sortArray.GetValue(index)), drawingTools.FontDigits, drawingTools.BrushDigit, 80 + 100 * 4, 100, drawingTools.FormatDrawing);
        }

        private void DrawComment(string message)
        {
            graphics.DrawString(message, drawingTools.FontDigits, drawingTools.BrushDigit, BubbleSortVisualizerSettings.LocationBottomCommentField, drawingTools.FormatDrawing);
        }

        private void DrawCompare(Tuple<int, int> indexes)
        {
            sortArray.SelectElement(indexes.Item1);
            this.DrawArray();
            sortArray.DeselectElement(indexes.Item1);
            //this.DrawCursor(indexes.Item1);
            //this.DrawSymbolComparison(indexes.Item1);
        }

        private void ClearComments()
        {
            graphics.FillRectangle(drawingTools.BrushElement, BubbleSortVisualizerSettings.UpperCommentField);
            graphics.FillRectangle(drawingTools.BrushElement, BubbleSortVisualizerSettings.BottomCommentField);
        }

        private void DrawSwap(Tuple<int, int> indexes)
        {
            sortArray.SelectElements(indexes);

            this.DrawArray();

           sortArray.DeselectElements(indexes);

        }

        private void DrawSortedPartArray()
        {
            foreach (var i in sortedPartArray)
            {
                var rectangle = new System.Drawing.Rectangle(sortArray.GetCoordinates(i), BubbleSortVisualizerSettings.ElementSize);

                graphics.FillRectangle(new SolidBrush(Color.DeepSkyBlue), rectangle);
                graphics.DrawRectangle(drawingTools.PenElement, rectangle);
                graphics.DrawString(sortArray.GetValue(i), drawingTools.FontDigits, drawingTools.BrushDigit, sortArray.GetCoordinates(i), drawingTools.FormatDrawing);
            }
        }

        public override void ToStart(object sender, EventArgs e)
        {

        }

    }
}
