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
        public int r = 10;
        private ArrayOld _arraysOld;
        private System.Drawing.Font drawFont = new System.Drawing.Font("Arial", 20);
        private System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat();
        private System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
        private System.Drawing.SolidBrush drawBrush1 = new System.Drawing.SolidBrush(System.Drawing.Color.LightCyan);
        private Pen drawPen = new Pen(Color.Blue, 7);
        private SortingForm bubbleSortForm;
        private BubbleSortAutomate automate;
        private int state ;
        private int reverseState;
        private int prevState;
        private Graphics graphics;
        private string currentComment = "";
        private Array array;

        public BubbleSortVisualizer(SortingForm bubbleSortForm, int[] array)
        {
            state = 0;
            prevState = 0;
            reverseState = 0;
            this.bubbleSortForm = bubbleSortForm;
            this.Paint += new PaintEventHandler(DrawInitialState);
            this.Array = array;
            InitializeComponent();
         }

        public void DrawInitialState(object sender, PaintEventArgs e)
        {
            graphics = this.CreateGraphics();
            _arraysOld = new ArrayOld(this.Array);
            automate = new BubbleSortAutomate(this.Array);
           
      
            this.DrawArrayOld(-1, -1);
        }

        private void ShowHelpMessage(object sender, EventArgs e)
        {
            MessageBox.Show(System.IO.File.ReadAllText(BubbleSortVisualizerSettings.HelpFile));
        }

        private void DrawArray()
        {
            for (var i = 0; i < array.Length; ++i)
            {
                var rectangle = new System.Drawing.Rectangle(array.GetCoordinates(i), BubbleSortVisualizerSettings.ElementSize);

                graphics.FillRectangle(new SolidBrush(IdentefyColorElement(i)), rectangle);
                graphics.DrawRectangle(drawPen, rectangle);
                graphics.DrawString(array.GetValue(i), drawFont, drawBrush, array.GetCoordinates(i), drawFormat);
            }
        }

        private Color IdentefyColorElement(int index)
        {
            return array.IsSelected(index)
                    ? BubbleSortVisualizerSettings.SelectedElementColor
                    : BubbleSortVisualizerSettings.SelectedElementColor;

        
        }
   

        private void ChangeData(object sender, EventArgs e)
        {
            var dataReceiver = new DataReceiverForm(bubbleSortForm, 1);
            
            this.Visible = false;
            dataReceiver.Show();
        }


        private void CloseBubbleSortVisualizer(object sender, EventArgs e)
        {
            bubbleSortForm.Visible = true;
        }

        private void forwardButton_Click(object sender, EventArgs e)
        {
            var res = automate.DirectAutomate(state);
            prevState = state;
            state = res.state;
            reverseState = state;

            this.DrawCurrentState(res);

        }

        private void backwardButton_Click(object sender, EventArgs e)
        {
            var res = automate.ReverseAutomate(state);
            state = res.state;
            reverseState = state;

           this.DrawCurrentState(res);
        }

        private void DrawCurrentState(BubbleSortAutomate.State state)
        {
            this.ClearField();
            if (state.currentState.Equals("compare"))
                this.DrawCompare(state.firstIndex, state.secondIndex);
            else
                this.DrawSwap(state.firstIndex, state.secondIndex);

            this.DrawComment(state.fullMessage);
        }

        private void ClearField()
        {
            graphics.FillRectangle(drawBrush1, BubbleSortVisualizerSettings.UpperCommentField);
            graphics.FillRectangle(drawBrush1, BubbleSortVisualizerSettings.BottomCommentField);
        }

        private void DrawComment(string message)
        {
            
            graphics.DrawString(message, drawFont, drawBrush, BubbleSortVisualizerSettings.locationBottomCommentField, drawFormat);
        }

        private void DrawCompare(int i, int j)
        {
            this.DrawArrayOld(-1, -1);
            drawPen.StartCap = LineCap.ArrowAnchor;
            drawPen.EndCap = LineCap.ArrowAnchor;
           
            Point[] points = new Point[] { new Point(53 + i * 100, 180), new Point(47 + 53 + i * 100, 155), new Point(100 + 53 + i * 100, 180) };
            graphics.DrawCurve(drawPen, points);
            graphics.DrawString("VS", drawFont, drawBrush, 80 + 100*i, 100, drawFormat);
        }

        private void DrawSwap(int i, int j)
        {
            _arraysOld.Swap(i, j);

            this.DrawArrayOld(i, j);

        }

        private void DrawArrayOld(int x, int y)
        {
           
            for (var i = 0; i < Array.Length; ++i)
            {
                var color = i == x || i == y ? Color.Fuchsia : Color.LightCyan;
                var rect = new System.Drawing.Rectangle(_arraysOld.RectangleCoordinates[i],
                    new System.Drawing.Size(100, 100));
                graphics.FillRectangle(new SolidBrush(color), rect);
                graphics.DrawRectangle(drawPen, rect);
               
                graphics.DrawString(_arraysOld.GetValue(i).ToString(), drawFont, drawBrush, _arraysOld.ValuesCoordinates[i], drawFormat);


            }
        }
    }
}
