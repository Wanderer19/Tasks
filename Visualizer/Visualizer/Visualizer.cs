using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Visualizer
{
    public partial class Visualizer : Form
    {
        protected readonly System.Resources.ResourceManager settings;
        protected Graphics graphics;
        protected VisualizationArray visualizationArray;
        protected SortingForm parentWindow;
        protected Automaton automatonSort;
        protected bool automaticMode = false;
        protected System.Timers.Timer selfTimer;
        protected int sortId;
        protected int[] inputArray;

        public Visualizer()
        {
            selfTimer = new System.Timers.Timer();
            var assembly = Assembly.GetExecutingAssembly();

            settings = new ResourceManager("Visualizer.VisualizerSettings", assembly);
            selfTimer.Elapsed += new System.Timers.ElapsedEventHandler(DoAutomaticStepForward);
            
            InitializeComponent();
        }


        public  virtual void DrawComment(string message)
        {
            this.commentsBox.Text = message;
        }

        public void DoAutomaticStepForward(object source, System.Timers.ElapsedEventArgs e)
        {
            this.DrawState(automatonSort.DoStepForward());
        }

        public virtual void ToStart(object sender, EventArgs e)
        {
            this.ClearOldComments();
            this.visualizationArray.DeselectAllElements();

            var state = automatonSort.ToStart();

            this.visualizationArray.DrawArray(state.Array, this.graphics);
        }

        public virtual void ClearOldComments()
        {
            this.commentsBox.Text = "";
        }

        public virtual void EnableAutomaticMode(object sender, EventArgs e)
        {
            if (!this.automaticMode)
            {
                this.backwardButton.Enabled = false;
                this.forwardButton.Enabled = false;
                this.continueButton.Enabled = false;

                this.automaticMode = true;
               
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
            ToEnableButtons();
            selfTimer.Stop();
            this.automaticMode = false;
        }

        public virtual void DrawSwap(StateAutomaton state)
        {
            visualizationArray.SelectElements(state.SelectedElements.ToArray());

            this.visualizationArray.DrawArray(state.Array, this.graphics);

            visualizationArray.DeselectElements(state.SelectedElements.ToArray());

        }
        public virtual void Proceed(object sender, EventArgs e)
        {
            selfTimer.Start();
            ToDisableButtons();
            this.automaticMode = true;
        }  

        public virtual void CloseVisualizer(object sender, EventArgs e)
        {
            parentWindow.Visible = true;
        }

        public virtual void ShowHelpMessage(object sender, EventArgs e)
        {
            MessageBox.Show(System.IO.File.ReadAllText(BubbleSortVisualizerSettings.HelpFile));
        }

        public virtual void ChangeData(object sender, EventArgs e)
        {
            var dataReceiver = new DataReceiverForm(parentWindow, sortId);

            HideMainWindow();
            dataReceiver.Show();
        }

        public void ToDisableButtons()
        {
            this.backwardButton.Enabled = false;
            this.forwardButton.Enabled = false;
            this.continueButton.Enabled = false;
        }

        public void ToEnableButtons()
        {
            this.backwardButton.Enabled = true;
            this.forwardButton.Enabled = true;
            this.continueButton.Enabled = true;
        }

        public void HideMainWindow()
        {
            this.Visible = false;
            this.Dispose();
        }

        public virtual void DrawInitialState(object sender, PaintEventArgs e)
        {
            graphics = this.CreateGraphics();

            this.visualizationArray.DrawArray(this.inputArray, graphics);
        }

    }
}
