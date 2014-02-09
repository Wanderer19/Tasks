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
    public partial class HeapSortVisualizer : Visualizer
    {
        public HeapSortVisualizer(SortingForm parentWindow, int [] array)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.parentWindow = parentWindow;
            this.inputArray = array;
            this.sortId = 1;
            selfTimer.Interval = 650;
            this.sortArray = new SortArray(array.Length);
            this.automatonSort = new AutomatonBubbleSort(array);

            drawingTools = new DrawingTools(BubbleSortVisualizerSettings.FontDigits, BubbleSortVisualizerSettings.FormatDrawing,
                                             BubbleSortVisualizerSettings.BrushDigit, BubbleSortVisualizerSettings.BrushElement,
                                             BubbleSortVisualizerSettings.PenElement);

            this.Paint += new PaintEventHandler(DrawInitialState);
            
        }

        public override void DrawInitialState(object sender, PaintEventArgs e)
        {
            base.DrawInitialState(sender, e);
            var a = new Dictionary<int, Point> {{0, new Point(1300, 400)}};
            var b = new Dictionary<int, int> {{0, 0}};
            int k = 200;
            int m = 100;
          
            graphics.DrawEllipse(drawingTools.PenElement, 1300, 400, 60, 60);
            
            //graphics.DrawLine(new Pen(Color.Blue, 2), new Point(1330, 430), new Point(1130, 530) );
            //graphics.DrawLine(new Pen(Color.Blue, 2), new Point(1330, 430), new Point(1530, 530));
            graphics.DrawString(inputArray[0].ToString(), new System.Drawing.Font("Arial Black", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204))), drawingTools.BrushDigit, new PointF(1310, 410), drawingTools.FormatDrawing);
            //graphics.DrawLine(drawingTools.PenElement, new Point(1370, 440), new Point(1500, 510));
           /* graphics.DrawEllipse(drawingTools.PenElement, 1100, 150, 70, 70);
            graphics.DrawString(inputArray[1].ToString(), drawingTools.FontDigits, drawingTools.BrushDigit, new PointF(1120, 160), drawingTools.FormatDrawing);

            graphics.DrawEllipse(drawingTools.PenElement, 1300, 150, 70, 70);
            graphics.DrawString(inputArray[2].ToString(), drawingTools.FontDigits, drawingTools.BrushDigit, new PointF(1320, 160), drawingTools.FormatDrawing);*/

            for (var i = 0; i <= inputArray.Length/2 - 1; ++i)
            {
                if (a.ContainsKey(i))
                {
                    b.Add(i * 2 + 1, b[i] + 1);
                    b.Add(i * 2 + 2, b[i] + 1);
                    if (i*2 + 1 < inputArray.Length)
                    {
                        a.Add(i * 2 + 1, new Point(a[i].X - k / (b[i * 2 + 1]), a[i].Y + m));
                        graphics.DrawEllipse(drawingTools.PenElement, a[i*2+1].X ,a[i*2+1].Y , 60, 60);
                        graphics.DrawLine(new Pen(Color.Blue, 2), new Point(a[i].X + 30, a[i].Y + 60), new Point(a[i * 2 + 1].X + 30, a[i * 2 + 1].Y));
                        graphics.DrawString(inputArray[i * 2 + 1].ToString(), new System.Drawing.Font("Arial Black", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204))), drawingTools.BrushDigit, new PointF(a[i * 2 + 1].X + 10, a[i * 2 + 1].Y + 10), drawingTools.FormatDrawing);
                    }
                    if (i*2 + 2 < inputArray.Length)
                    {
                        a.Add(i * 2 + 2, new Point(a[i].X + k/(b[i*2+2]), a[i].Y + m));
                        graphics.DrawEllipse(drawingTools.PenElement, a[i * 2 + 2].X, a[i * 2 + 2].Y, 60, 60);
                        graphics.DrawLine(new Pen(Color.Blue, 2), new Point(a[i].X + 30, a[i].Y + 60), new Point(a[i * 2 + 2].X + 30, a[i * 2 + 2].Y));
                        graphics.DrawString(inputArray[i * 2 + 2].ToString(), new System.Drawing.Font("Arial Black", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204))), drawingTools.BrushDigit, new PointF(a[i * 2 + 2].X + 10, a[i * 2 + 2].Y + 10), drawingTools.FormatDrawing);
                    }

                   
                   
                }
            }
        }
    }
}
