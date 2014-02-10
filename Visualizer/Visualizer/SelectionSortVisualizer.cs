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
    public partial class SelectionSortVisualizer : Visualizer
    {
        public const string StateCompare = "compare";
        public const string StateSwap = "swap";
        public const string StateMin = "min";
        
        private readonly System.Drawing.Font digitsFont = new System.Drawing.Font("Arial", 20);
        private readonly System.Drawing.StringFormat formatDrawing = new System.Drawing.StringFormat();
        private readonly System.Drawing.SolidBrush digitsBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
        private readonly System.Drawing.SolidBrush elementsBrush = new System.Drawing.SolidBrush(System.Drawing.Color.LightCyan);

        public SelectionSortVisualizer(SortingForm parentWindow, int [] array)
        {
            this.parentWindow = parentWindow;
            this.inputArray = (int []) array.Clone();
            this.visualizationArray = new VisualizationArray(array.Length);
            selfTimer.Interval = 1000;
            this.automatonSort = new AutomatonSelectionSort(array);
            this.sortId = 2;
            InitializeComponent();
            this.Paint += new PaintEventHandler(DrawInitialState);
        }

        public override void DrawState(StateAutomaton stateAutomaton)
        {
            this.ClearOldComments();
           
            switch (stateAutomaton.StateId)
            {
                case StateCompare:
                {
                    this.DrawCompare(stateAutomaton);
                    
                    break;
                }
                case StateSwap:
                {
                    this.DrawSwap(stateAutomaton);

                    break;
                }
                case StateMin:
                {
                    this.DrawMin(stateAutomaton);
                    
                    break;
                }
            }


            this.DrawComment(stateAutomaton.DescriptionState);
            this.visualizationArray.DrawSortedPartArray(stateAutomaton, graphics);

        }

        private void DrawMin(StateAutomaton state)
        {
            this.visualizationArray.DrawArray(state.Array, this.graphics);
            
            graphics.DrawString(String.Format("Текущий минимум  = {0}", state.Min), digitsFont, digitsBrush, 80 + 100 * 4, 100, formatDrawing);
        }

        private void DrawComment(string message)
        {
            this.commentsBox.Text = message;
        }

        private void DrawCompare(StateAutomaton state)
        {
            this.DrawMin(state);
            
            visualizationArray.SelectElements(state.SelectedElements.ToArray());
            
            this.visualizationArray.DrawArray(state.Array, this.graphics);
            
            visualizationArray.DeselectElements(state.SelectedElements.ToArray());
      
        }

        public override void ClearOldComments()
        {
            base.ClearOldComments();
            graphics.FillRectangle(elementsBrush, BubbleSortVisualizerSettings.UpperCommentField);
        }

        public override void ToStart(object sender, EventArgs e)
        {
            visualizationArray = new VisualizationArray(inputArray.Length);
            automatonSort.ToStart();
            this.visualizationArray.DrawArray(inputArray, this.graphics);
        }
    }
}
