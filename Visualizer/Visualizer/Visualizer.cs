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
        protected Automaton automatonSort;
        protected bool automaticMode = false;
        protected System.Timers.Timer selfTimer;
        protected int sortId;

        public Visualizer()
        {
            selfTimer = new System.Timers.Timer();
            selfTimer.Elapsed += new System.Timers.ElapsedEventHandler(DoAutomaticStepForward);

            InitializeComponent();
        }

        public void DoAutomaticStepForward(object source, System.Timers.ElapsedEventArgs e)
        {
            this.DrawState(automatonSort.DoStepForward());
        }


        public virtual void ToStart(object sender, EventArgs e)
        {
            this.ClearComments();
            this.sortArray.DeselectAllElements();

            automatonSort.ToStart();

            this.DrawArray();
        }

        public virtual void ClearComments()
        {
            
        }

        public virtual void EnableAutomaticMode(object sender, EventArgs e)
        {
            if (!this.automaticMode)
            {
                this.backwardButton.Enabled = false;
                this.forwardButton.Enabled = false;
                this.continueButton.Enabled = false;

                this.automaticMode = true;
                selfTimer.Interval = 650;
                selfTimer.Start();
            }
        }

        public virtual void DoStepForward(object sender, EventArgs e)
        {
            this.DrawState(automatonSort.DoStepForward());
        }

        public virtual void DoStepBackward(object sender, EventArgs e)
        {
            this.DrawState(automatonSort.DoStepBackward());
        }

        public virtual void DrawState(StateAutomaton stateAutomaton)
        {

        }

        public virtual void DoPause(object sender, EventArgs e)
        {
            this.backwardButton.Enabled = true;
            this.forwardButton.Enabled = true;
            this.continueButton.Enabled = true;
            selfTimer.Stop();
            this.automaticMode = false;
        }

        public virtual void Proceed(object sender, EventArgs e)
        {
            selfTimer.Start();
            this.backwardButton.Enabled = false;
            this.forwardButton.Enabled = false;
            this.continueButton.Enabled = false;
            this.automaticMode = true;
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
            var dataReceiver = new DataReceiverForm(mainForm, sortId);

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
