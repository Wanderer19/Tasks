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
        private Array arrays;
        private System.Drawing.Font drawFont = new System.Drawing.Font("Arial", 20);
        private System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat();
        private System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
        private System.Drawing.SolidBrush drawBrush1 = new System.Drawing.SolidBrush(System.Drawing.Color.LightCyan);
        private Pen drawPen = new Pen(Color.Blue, 7);
        private BubbleSortForm bubbleSortForm;
        private BubbleSortAutomate automate;
        private int state ;
        private int reverseState;
        private Graphics graphics;
        private string currentComment = "";


        public BubbleSortVisualizer(BubbleSortForm bubbleSortForm)
        {
            state = 0;
            reverseState = 0;
            this.bubbleSortForm = bubbleSortForm;
            InitializeComponent();
         
            this.Paint += new PaintEventHandler(Form1_Paint);
         
        }

       

        void Form1_Paint(object sender, PaintEventArgs e)
        {
            graphics = this.CreateGraphics();
            arrays = new Array(this.Array);
            automate = new BubbleSortAutomate(this.Array);
            state = 0;
            reverseState = 0;
      
            this.DrawArray(-1, -1);


            
        }

        private void ShowHelpMessage(object sender, EventArgs e)
        {
            MessageBox.Show(System.IO.File.ReadAllText("help.txt"));
        }

        private void help_Click(object sender, EventArgs e)
        {

        }

        private void BubbleSortVisualizer_Load(object sender, EventArgs e)
        {
            
        }

        private void buttonChangeData_Click(object sender, EventArgs e)
        {
            Data d = new Data(this);
            this.Visible = false;
            d.Show();
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            
        }

        private void CloseBubbleSortVisualizer(object sender, EventArgs e)
        {
            bubbleSortForm.Visible = true;
        }

        private void forwardButton_Click(object sender, EventArgs e)
        {
            var res = automate.DirectAutomate(state);
            state = res.state;
            reverseState = state;

            this.DrawState(res);
            //graphics.FillRectangle(drawBrush1, 300, 400, 1500, 500);
           // graphics.DrawString(currentComment, drawFont, drawBrush1, new PointF(400, 400), drawFormat);
            //graphics.DrawString(res.fullMessage, drawFont, drawBrush, new PointF(400, 400), drawFormat);
            //currentComment = res.fullMessage;

        }

        private void backwardButton_Click(object sender, EventArgs e)
        {
            var res = automate.ReverseAutomate(state);
            state = res.state;
            reverseState = state;

            graphics.FillRectangle(drawBrush1, 300, 400, 1500, 500);
            //graphics.DrawString(currentComment, drawFont, drawBrush1, new PointF(400, 400), drawFormat);
            graphics.DrawString(res.fullMessage, drawFont, drawBrush, new PointF(400, 400), drawFormat);
            currentComment = res.fullMessage;
        }

        private void DrawState(BubbleSortAutomate.State state)
        {
            graphics.FillRectangle(drawBrush1, 0, 0, 1500, 200);
            if (state.currentState.Equals("compare"))
                this.DrawCompare(state.firstIndex, state.secondIndex);
            else
                this.DrawSwap(state.firstIndex, state.secondIndex);

            this.DrawComment(state.fullMessage);
        }

        private void DrawComment(string message)
        {
            graphics.FillRectangle(drawBrush1, 300, 400, 1500, 500);
            graphics.DrawString(message, drawFont, drawBrush, new PointF(400, 400), drawFormat);
        }

        private void DrawCompare(int i, int j)
        {
            this.DrawArray(-1, -1);
            drawPen.StartCap = LineCap.ArrowAnchor;
            drawPen.EndCap = LineCap.ArrowAnchor;
           
            Point[] points = new Point[] { new Point(53 + i * 100, 180), new Point(47 + 53 + i * 100, 155), new Point(100 + 53 + i * 100, 180) };
            graphics.DrawCurve(drawPen, points);
            graphics.DrawString("VS", drawFont, drawBrush, 80*(i+1), 100, drawFormat);
        }

        private void DrawSwap(int i, int j)
        {
            arrays.Swap(i, j);

            this.DrawArray(i, j);

        }

        private void DrawArray(int x, int y)
        {
           
            for (var i = 0; i < Array.Length; ++i)
            {
                var color = i == x || i == y ? Color.Fuchsia : Color.LightCyan;
                var rect = new System.Drawing.Rectangle(arrays.RectangleCoordinates[i],
                    new System.Drawing.Size(100, 100));
                graphics.FillRectangle(new SolidBrush(color), rect);
                graphics.DrawRectangle(drawPen, rect);
               
                graphics.DrawString(arrays.GetValue(i).ToString(), drawFont, drawBrush, arrays.ValuesCoordinates[i], drawFormat);


            }
        }
    }
}
