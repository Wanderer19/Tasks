using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Visualizer
{
    public partial class HeapSortVisualizer : Visualizer
    {
        private VisualizationHeap visualizationHeap;

        public HeapSortVisualizer(SortingForm parentWindow, int [] array)
        {
            this.WindowState = FormWindowState.Maximized;
            this.parentWindow = parentWindow;
            this.inputArray = array;
            this.sortId = Application.IdentifiersSorts.HeapSort;
            this.visualizationArray = new VisualizationArray();
            this.visualizationHeap = new VisualizationHeap();
            this.automatonSort = new AutomatonHeapSort(array);
        }
       
        public override void DrawInitialState(object sender, PaintEventArgs e)
        {
            if (countUpdateScreen == 0)
            {
                base.DrawInitialState(sender, e);
                this.visualizationHeap.DrawHeap(new StateAutomaton(inputArray), graphics);
            }
        }

        public override void DrawState(StateAutomaton stateAutomaton)
        {
            base.ClearOldComments();

            switch (stateAutomaton.StateId)
            {
                case (int)AutomatonSiftDown.States.ConditionOnUpdateMaximumChild:
                {
                    DrawCompare(stateAutomaton);
                    break;
                }
                case (int)AutomatonSiftDown.States.ConditionOnUpdateParent:
                {
                    DrawCompare(stateAutomaton);
                    break;
                }
                case (int)AutomatonSiftDown.States.SwappingParentWithMaximumChild:
                {
                    DrawSwap(stateAutomaton);
                    break;
                }
                case (int)AutomatonSiftDown.States.Loop:
                {
                    DrawShifting(stateAutomaton);
                    break;
                }
                case (int)AutomatonHeapSort.States.SwappingElements:
                {
                    DrawSwap(stateAutomaton);
                    break;
                }
                case (int)AutomatonSiftDown.States.EndingConditionOnUpdateMaximumChild:
                {
                    DrawShifting(stateAutomaton);
                    break;
                }
                case (int)AutomatonSiftDown.States.EndLoop:
                {
                    this.visualizationArray.DrawArray(stateAutomaton, graphics);
                    this.visualizationHeap.DrawHeap(stateAutomaton, graphics);
                    break;
                }
                case (int)AutomatonHeapSort.States.FinalState:
                {
                    this.visualizationArray.DrawArray(stateAutomaton, graphics);
                    this.visualizationHeap.DrawHeap(stateAutomaton, graphics);
                    this.selfTimer.Stop();
                    break;
                }
                case (int)AutomatonHeapSort.States.InitialState:
                {
                    this.visualizationArray.DrawArray(stateAutomaton, graphics);
                    this.visualizationHeap.DrawHeap(stateAutomaton, graphics);
                    break;
                }
                default:
                {
                    this.visualizationArray.DrawArray(stateAutomaton, graphics);
                    this.visualizationHeap.DrawHeap(stateAutomaton, graphics);
                    break;
                }
                
            }
            
            visualizationArray.DrawSortedInvertedPartArray(stateAutomaton, graphics);
            visualizationHeap.DrawSortedPartHeap(stateAutomaton, graphics);
            base.DrawComment(stateAutomaton.Comment);
        }

        public void DrawShifting(StateAutomaton stateAutomaton)
        {
            visualizationArray.DrawArray(stateAutomaton, graphics);
            visualizationHeap.DrawHeap(stateAutomaton, graphics);


        }

        public override void DrawSwap(StateAutomaton stateAutomaton)
        {
            base.DrawSwap(stateAutomaton);

            //visualizationHeap.SelectNodes(stateAutomaton.SelectedElements.ToArray());

            visualizationHeap.DrawHeap(stateAutomaton, graphics);
        }

        public void DrawCompare(StateAutomaton stateAutomaton)
        {
           // visualizationHeap.SelectNodes(stateAutomaton.SelectedElements.ToArray());

            visualizationArray.DrawArray(stateAutomaton, graphics);
            visualizationHeap.DrawHeap(stateAutomaton, graphics);
        }

        public override void ToStart(object sender, EventArgs e)
        {
            this.visualizationHeap.DrawHeap(new StateAutomaton(inputArray), this.graphics);
            base.ToStart(sender, e);
          
        }
    }
}
