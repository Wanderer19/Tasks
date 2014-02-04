using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Visualizer
{
    public partial class Visualizer : Form
    {
        protected Graphics graphics;
        protected SortArray sortArray;
        protected DrawingTools drawingTools;
        protected SortingForm mainForm;

        public Visualizer()
        {
            InitializeComponent();
        }

        public virtual void ToStart(object sender, EventArgs e)
        {
            
        }

        public virtual void EnableAutomaticMode(object sender, EventArgs e)
        {
            
        }

        public virtual void DoStepForward(object sender, EventArgs e)
        {
            
        }

        public virtual void DoStepBackward(object sender, EventArgs e)
        {
            
        }

        public virtual void DoPause(object sender, EventArgs e)
        {
            
        }

        public virtual void Proceed(object sender, EventArgs e)
        {
            
        }

        public virtual void CloseVisualizer(object sender, EventArgs e)
        {
            mainForm.Visible = true;
        }

        public virtual void ShowHelpMessage(object sender, EventArgs e)
        {
            MessageBox.Show(System.IO.File.ReadAllText(BubbleSortVisualizerSettings.HelpFile));
        }

        public virtual void ChangeData(object sender, EventArgs e)
        {
            var dataReceiver = new DataReceiverForm(mainForm, 1);

            this.Visible = false;
            this.Dispose();
            dataReceiver.Show();
        }

        public virtual void DrawInitialState(object sender, PaintEventArgs e)
        {
            graphics = this.CreateGraphics();

            this.DrawArray();
        }

        public virtual void DrawArray()
        {
            for (var i = 0; i < sortArray.Length; ++i)
            {
                var rectangle = new System.Drawing.Rectangle(sortArray.GetCoordinates(i), BubbleSortVisualizerSettings.ElementSize);

                graphics.FillRectangle(new SolidBrush(sortArray.GetColorElement(i)), rectangle);
                graphics.DrawRectangle(drawingTools.PenElement, rectangle);
                graphics.DrawString(sortArray.GetValue(i), drawingTools.FontDigits, drawingTools.BrushDigit, sortArray.GetCoordinates(i), drawingTools.FormatDrawing);
            }
        }

    }
}
