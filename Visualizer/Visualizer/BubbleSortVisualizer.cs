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
        private readonly SortingForm bubbleSortForm;
        private Graphics graphics;
        private readonly BubbleSortArray bubbleSortArray;
        private readonly AutomatonBubbleSort automatonBubbleSort;
        private readonly DrawingTools drawingTools;
        private bool automaticMode = false;

        public BubbleSortVisualizer(SortingForm bubbleSortForm, int[] array)
        {
            this.bubbleSortForm = bubbleSortForm;
            
            this.bubbleSortArray = new BubbleSortArray(array);
            this.automatonBubbleSort = new AutomatonBubbleSort(array);
            drawingTools = new DrawingTools(BubbleSortVisualizerSettings.FontDigits, BubbleSortVisualizerSettings.FormatDrawing,
                                             BubbleSortVisualizerSettings.BrushDigit, BubbleSortVisualizerSettings.BrushElement, 
                                             BubbleSortVisualizerSettings.PenElement);
           
            this.Paint += new PaintEventHandler(DrawInitialState);
            InitializeComponent();
         }

        public void DrawInitialState(object sender, PaintEventArgs e)
        {
            graphics = this.CreateGraphics();
   
            this.DrawArray();
        }

        private void ShowHelpMessage(object sender, EventArgs e)
        {
            MessageBox.Show(System.IO.File.ReadAllText(BubbleSortVisualizerSettings.HelpFile));
        }

        private void DrawArray()
        {
            for (var i = 0; i < bubbleSortArray.Length; ++i)
            {
                var rectangle = new System.Drawing.Rectangle(bubbleSortArray.GetCoordinates(i), BubbleSortVisualizerSettings.ElementSize);

                graphics.FillRectangle(new SolidBrush(bubbleSortArray.GetColorElement(i)), rectangle);
                graphics.DrawRectangle(drawingTools.PenElement, rectangle);
                graphics.DrawString(bubbleSortArray.GetValue(i), drawingTools.FontDigits, drawingTools.BrushDigit, bubbleSortArray.GetCoordinates(i), drawingTools.FormatDrawing);
            }
        }

       

        private void ChangeData(object sender, EventArgs e)
        {
            var dataReceiver = new DataReceiverForm(bubbleSortForm, 1);
            
            this.Visible = false;
            this.Dispose();
            dataReceiver.Show();
        }


        private void CloseBubbleSortVisualizer(object sender, EventArgs e)
        {
            bubbleSortForm.Visible = true;
        }

        private void DoStepForward(object sender, EventArgs e)
        {
            this.DrawState(automatonBubbleSort.DoStepForward());
        }

        private void DoStepBackward(object sender, EventArgs e)
        {
            this.DrawState(automatonBubbleSort.DoStepBackward());
        }

        private void DrawState(StateAutomaton stateAutomaton)
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
            //TO-DO придумать куда вынести
            var points = new Point[] { new Point(53 + index * 100, 180), new Point(47 + 53 + index * 100, 155), new Point(100 + 53 + index * 100, 180) };
            graphics.DrawCurve(drawingTools.PenElement, points);
        }

        private void DrawSymbolComparison(int index)
        {
            graphics.DrawString(BubbleSortVisualizerSettings.SymbolComparison, drawingTools.FontDigits, drawingTools.BrushDigit, 80 + 100 * index, 100, drawingTools.FormatDrawing);
        }

        private void DrawSwap(Tuple<int, int> indexes)
        {
            bubbleSortArray.SelectElements(indexes);
            
            this.DrawArray();
            
            bubbleSortArray.DeselectElements(indexes);

        }

        private void EnableAutomaticMode(object sender, EventArgs e)
        {
            if (this.automaticMode)
            {
                
            }
        }
    }
}
