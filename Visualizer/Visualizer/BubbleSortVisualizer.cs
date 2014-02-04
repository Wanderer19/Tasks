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
        private readonly System.Timers.Timer selfTimer;
 
        public BubbleSortVisualizer(SortingForm bubbleSortForm, int[] array)
        {
            this.bubbleSortForm = bubbleSortForm;
            
            this.bubbleSortArray = new BubbleSortArray(array);
            this.automatonBubbleSort = new AutomatonBubbleSort(array);
            drawingTools = new DrawingTools(BubbleSortVisualizerSettings.FontDigits, BubbleSortVisualizerSettings.FormatDrawing,
                                             BubbleSortVisualizerSettings.BrushDigit, BubbleSortVisualizerSettings.BrushElement, 
                                             BubbleSortVisualizerSettings.PenElement);

           selfTimer = new System.Timers.Timer();
           selfTimer.Elapsed += new System.Timers.ElapsedEventHandler(DoAutomaticStepForward);
           
           
            this.Paint += new PaintEventHandler(DrawInitialState);
         }

        public void DoAutomaticStepForward(object source, System.Timers.ElapsedEventArgs e)
        {
            this.DoStepForward(null, new EventArgs());
        }

        public void DrawInitialState(object sender, PaintEventArgs e)
        {
            graphics = this.CreateGraphics();
   
            this.DrawArray();
        }

        public override void ShowHelpMessage(object sender, EventArgs e)
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



        public override void ChangeData(object sender, EventArgs e)
        {
            var dataReceiver = new DataReceiverForm(bubbleSortForm, 1);
            
            this.Visible = false;
            this.Dispose();
            dataReceiver.Show();
        }


        public override void CloseBubbleSortVisualizer(object sender, EventArgs e)
        {
            bubbleSortForm.Visible = true;
        }

        public override void DoStepForward(object sender, EventArgs e)
        {
            if (!(this.automaticMode && sender is System.Windows.Forms.Button))
                this.DrawState(automatonBubbleSort.DoStepForward());
        }

        public override void DoStepBackward(object sender, EventArgs e)
        {
            if (!(this.automaticMode && sender is System.Windows.Forms.Button))
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
            bubbleSortArray.SelectElements(indexes);
            
            this.DrawArray();
            
            bubbleSortArray.DeselectElements(indexes);

        }

        public override void EnableAutomaticMode(object sender, EventArgs e)
        {
            if (!this.automaticMode)
            {
                this.automaticMode = true;
                selfTimer.Interval = 650;
                selfTimer.Start();
            }
        }

        public override void DoPause(object sender, EventArgs e)
        {
            selfTimer.Stop();
            this.automaticMode = false;
        }

        public override void Proceed(object sender, EventArgs e)
        {
            selfTimer.Start();
            this.automaticMode = true;
        }

        public override void ToStart(object sender, EventArgs e)
        {
           this.ClearComments();
           this.bubbleSortArray.DeselectAllElements();
           
           automatonBubbleSort.ToStart();

           this.DrawArray();
            
        }
    }
}
