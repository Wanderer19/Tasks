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
    
        public SelectionSortVisualizer(SortingForm parentWindow, int [] array)
        {
            this.parentWindow = parentWindow;
            this.inputArray = (int []) array.Clone();
            this.sortArray = new SortArray(array.Length);
            selfTimer.Interval = 1000;
            this.automatonSort = new AutomatonSelectionSort(array);
            this.sortId = 2;

            drawingTools = new DrawingTools(BubbleSortVisualizerSettings.FontDigits, BubbleSortVisualizerSettings.FormatDrawing,
                                             BubbleSortVisualizerSettings.BrushDigit, BubbleSortVisualizerSettings.BrushElement,
                                             BubbleSortVisualizerSettings.PenElement);
            InitializeComponent();
            this.Paint += new PaintEventHandler(DrawInitialState);
        }

        public override void DrawState(StateAutomaton stateAutomaton)
        {
            this.ClearComments();
           
            switch (stateAutomaton.StateId)
            {

                case StateCompare:
                    {
                        
                        this.DrawCompare(stateAutomaton);
                        break;
                    }
                case StateSwap:
                    {
                        this.DrawSwap(stateAutomaton);

                        break;
                    }
                case StateMin:
                {
                    this.DrawMin(stateAutomaton);
                    break;
                }
            }


            this.DrawComment(stateAutomaton.DescriptionState);
            this.DrawSortedPartArray(stateAutomaton);

        }

        private void DrawMin(StateAutomaton state)
        {
            this.DrawArray(state.Array);
            graphics.DrawString(String.Format("Текущий минимум  = {0}", state.Min), drawingTools.FontDigits, drawingTools.BrushDigit, 80 + 100 * 4, 100, drawingTools.FormatDrawing);
        }

        private void DrawComment(string message)
        {
            graphics.DrawString(message, drawingTools.FontDigits, drawingTools.BrushDigit, BubbleSortVisualizerSettings.LocationBottomCommentField, drawingTools.FormatDrawing);
        }

        private void DrawCompare(StateAutomaton state)
        {
            this.DrawMin(state);
            
            sortArray.SelectElements(state.SelectedElements.ToArray());
            
            this.DrawArray(state.Array);
            
            sortArray.DeselectElements(state.SelectedElements.ToArray());
      
        }

        private void ClearComments()
        {
            graphics.FillRectangle(drawingTools.BrushElement, BubbleSortVisualizerSettings.UpperCommentField);
            graphics.FillRectangle(drawingTools.BrushElement, BubbleSortVisualizerSettings.BottomCommentField);
        }

        private void DrawSortedPartArray(StateAutomaton state)
        {
            for(var i = 0; i <= state.FirstIndex; ++i)
            {
                var rectangle = new System.Drawing.Rectangle(sortArray.GetCoordinates(i), BubbleSortVisualizerSettings.ElementSize);

                graphics.FillRectangle(new SolidBrush(Color.DeepSkyBlue), rectangle);
                graphics.DrawRectangle(drawingTools.PenElement, rectangle);
                graphics.DrawString(state.Array[i].ToString(), drawingTools.FontDigits, drawingTools.BrushDigit, sortArray.GetCoordinates(i), drawingTools.FormatDrawing);
            }
        }
        
        public override void ToStart(object sender, EventArgs e)
        {
            sortArray = new SortArray(inputArray.Length);
            automatonSort.ToStart();
            DrawArray(inputArray);
        }

    }
}
