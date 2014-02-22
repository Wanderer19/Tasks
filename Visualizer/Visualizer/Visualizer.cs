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
using System.Timers;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace Visualizer
{
    public partial class Visualizer : Form
    {
        protected ResourceManager settings;
        protected Graphics graphics;
        protected IVisualizationArray visualizationArray;
        protected SortingForm parentWindow;
        protected IAutomaton automatonSort;
        protected bool isAutomaticMode = false;
        protected Timer selfTimer = new Timer();
        protected Application.IdentifiersSorts sortId;
        protected int[] inputArray;
        protected int countUpdateScreen = 0;
        protected readonly Rectangle UpperCommentField = new Rectangle(0, 0, 1500, 200);

        public Visualizer()
        {
            DownloadConfigurationFile("Visualizer.VisualizerSettings");
            
            selfTimer.Elapsed += new ElapsedEventHandler(DoAutomaticStepForward);
            Paint += new PaintEventHandler(DrawInitialState);

            selfTimer.Interval = 300;
            InitializeComponent();
        }

        public void DownloadConfigurationFile(string fileName)
        {
            var assembly = Assembly.GetExecutingAssembly();

            settings = new ResourceManager(fileName, assembly);
        }

        public  virtual void DrawComment(string message)
        {
            commentsBox.Text = message;
        }

        public void DoAutomaticStepForward(object source, ElapsedEventArgs e)
        {
            var state = automatonSort.DoStepForward();

            if (state.StateId.Equals(Automaton.StateEnd))
                DoPause(null, new EventArgs());

            DrawState(state);
        }

        public virtual void ToStart(object sender, EventArgs e)
        {
            DrawState(automatonSort.ToStart());
        }

        public virtual void ClearOldComments()
        {
            commentsBox.Text = "";
        }

        public virtual void EnableAutomaticMode(object sender, EventArgs e)
        {
            if (!isAutomaticMode)
            {
                ToDisableButtons();
                isAutomaticMode = true;
               
                selfTimer.Start();
            }
        }

        public virtual void DoStepForward(object sender, EventArgs e)
        {
            DrawState(automatonSort.DoStepForward());
        }

        public virtual void DoStepBackward(object sender, EventArgs e)
        {
            DrawState(automatonSort.DoStepBackward());
        }

        public virtual void DrawState(StateAutomaton stateAutomaton)
        {
           
        }

        public virtual void DoPause(object sender, EventArgs e)
        {
            ToEnableButtons();
            selfTimer.Stop();
            isAutomaticMode = false;
        }

        public virtual void DrawSwap(StateAutomaton state)
        {
            visualizationArray.DrawArray(state, graphics);
        }

        public virtual void Proceed(object sender, EventArgs e)
        {
            selfTimer.Start();
            ToDisableButtons();
            isAutomaticMode = true;
        }  

        public virtual void CloseVisualizer(object sender, EventArgs e)
        {
            parentWindow.Visible = true;
        }

        public virtual void ChangeData(object sender, EventArgs e)
        {
            var dataReceiver = new DataReceiverForm(parentWindow, sortId);

            HideMainWindow();
            dataReceiver.Show();
        }

        public void ToDisableButtons()
        {
            backwardButton.Enabled = false;
            forwardButton.Enabled = false;
            continueButton.Enabled = false;
        }

        public void ToEnableButtons()
        {
            backwardButton.Enabled = true;
            forwardButton.Enabled = true;
            continueButton.Enabled = true;
        }

        public void HideMainWindow()
        {
            Visible = false;
            Dispose();
        }

        public virtual void DrawInitialState(object sender, PaintEventArgs e)
        {
            if (countUpdateScreen == 0)
            {
                graphics = CreateGraphics();

                visualizationArray.DrawArray(new StateAutomaton(inputArray), graphics);

                countUpdateScreen++;
            }
            
            
        }

    }
}
