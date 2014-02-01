using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
          
      
          

            for (var i = 0; i < Array.Length; ++i)
            {
                var rect = new System.Drawing.Rectangle(arrays.RectangleCoordinates[i],
                    new System.Drawing.Size(100, 100));
                graphics.DrawRectangle(drawPen, rect);
                graphics.FillRectangle(new SolidBrush(arrays.Colors[i]), rect);
                graphics.DrawString(Array[i].ToString(), drawFont, drawBrush, arrays.ValuesCoordinates[i], drawFormat);
               
             
            }
            
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
            state = res.Item1;
            reverseState = state;

            graphics.DrawString(currentComment, drawFont, drawBrush1, new PointF(400, 400), drawFormat);
            graphics.DrawString(res.Item2, drawFont, drawBrush, new PointF(400, 400), drawFormat);
            currentComment = res.Item2;

        }

        private void backwardButton_Click(object sender, EventArgs e)
        {
            var res = automate.ReverseAutomate(state);
            state = res.Item1;
            reverseState = state;

            graphics.DrawString(currentComment, drawFont, drawBrush1, new PointF(400, 400), drawFormat);
            graphics.DrawString(res.Item2, drawFont, drawBrush, new PointF(400, 400), drawFormat);
            currentComment = res.Item2;
        }
    }
}
