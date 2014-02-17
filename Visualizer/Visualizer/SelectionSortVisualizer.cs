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
        private readonly System.Drawing.Font digitsFont = new System.Drawing.Font("Arial", 20);
        private readonly System.Drawing.StringFormat formatDrawing = new System.Drawing.StringFormat();
        private readonly System.Drawing.SolidBrush digitsBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
        private readonly System.Drawing.SolidBrush elementsBrush = new System.Drawing.SolidBrush(System.Drawing.Color.LightCyan);

        public SelectionSortVisualizer(SortingForm parentWindow, int [] array)
        {
            this.parentWindow = parentWindow;
            this.sortId = Application.IdentifiersSorts.SelectionSort;
            this.inputArray = (int []) array.Clone();
            
            this.visualizationArray = new VisualizationArray();
            this.automatonSort = new AutomatonSelectionSort(array);
        }

        public override void DrawState(StateAutomaton stateAutomaton)
        {
            this.ClearOldComments();


            switch (stateAutomaton.StateId)
            {
                case (int) AutomatonSelectionSort.States.Condition:
                {
                    this.DrawCompare(stateAutomaton);
                    
                    break;
                }
                case (int) AutomatonSelectionSort.States.SwappingElements:
                {
                    this.DrawSwap(stateAutomaton);

                    break;
                }
                case (int) AutomatonSelectionSort.States.InitializeIndexMinimum:
                {
                    this.DrawMin(stateAutomaton);
                    
                    break;
                }
                case (int)AutomatonSelectionSort.States.UpdateMinimum:
                {
                    this.DrawMin(stateAutomaton);

                    break;
                }
                case (int)AutomatonSelectionSort.States.FinalState:
                {
                    this.visualizationArray.DrawArray(stateAutomaton, this.graphics);
                    selfTimer.Stop();
                    break;
                }
                default:
                {
                    this.visualizationArray.DrawArray(stateAutomaton, this.graphics);

                    break;
                }
            }
            
            this.DrawComment(stateAutomaton.Comment);
        }

        private void DrawMin(StateAutomaton state)
        {
            this.visualizationArray.DrawArray(state, this.graphics);
            
            graphics.DrawString(String.Format("Текущий минимум  = {0}", state.Minimum), digitsFont, digitsBrush, 80 + 100 * 4, 100, formatDrawing);
        }

        private void DrawCompare(StateAutomaton state)
        {
            this.DrawMin(state);
            
            this.visualizationArray.DrawArray(state, this.graphics);
        }

        public override void ClearOldComments()
        {
            base.ClearOldComments();
           
            graphics.FillRectangle(elementsBrush, UpperCommentField);
        }

        public override void ToStart(object sender, EventArgs e)
        {
            visualizationArray = new VisualizationArray();
            
            automatonSort.ToStart();
            
            this.visualizationArray.DrawArray(new StateAutomaton(inputArray), this.graphics);
        }
    }
}
