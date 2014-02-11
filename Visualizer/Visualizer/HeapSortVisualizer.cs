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
        private const string StateSwap = "swap";
        private const string StateCompare = "compare";
        private const string StateShifting = "shifting";

        private const string StateEndShifting = "endShifting";
        private const string StateSwapSorting = "swap - sorting";
        private const string StateEndSorting = "endSorting";
        private const string StateMaxChild = "maxChild";


        public HeapSortVisualizer(SortingForm parentWindow, int [] array)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.parentWindow = parentWindow;
            this.inputArray = array;
            this.sortId = 1;
            selfTimer.Interval = 650;
            this.visualizationArray = new VisualizationArray(array.Length);
            this.visualizationHeap = new VisualizationHeap(array.Length);
            this.automatonSort = new AutomatonHeapSort(array);

            this.Paint += new PaintEventHandler(DrawInitialState);
            
        }
       
        public override void DrawInitialState(object sender, PaintEventArgs e)
        {
            base.DrawInitialState(sender, e);
            this.visualizationHeap.DrawHeap(inputArray, graphics);
        }

        public override void DrawState(StateAutomaton stateAutomaton)
        {
            base.ClearOldComments();

            switch (stateAutomaton.StateId)
            {
                case StateCompare:
                {
                    DrawCompare(stateAutomaton);
                    break;
                }
                case StateSwap:
                {
                    DrawSwap(stateAutomaton);
                    break;
                }
                case StateShifting:
                {
                    DrawShifting(stateAutomaton);
                    break;
                }
                case StateSwapSorting:
                {
                    DrawSwap(stateAutomaton);
                    //удаление ребра
                    break;
                }
                case StateMaxChild:
                {
                    DrawShifting(stateAutomaton);
                    break;
                }
                case StateEndSorting:
                {
                    
                    break;
                }
                
            }
            visualizationArray.DrawSortedInvertedPartArray(stateAutomaton, graphics);
            visualizationHeap.DrawSortedPartHeap(stateAutomaton, graphics);
            base.DrawComment(stateAutomaton.DescriptionState);
        }

        public void DrawShifting(StateAutomaton stateAutomaton)
        {
            visualizationArray.SelectElements(stateAutomaton.ShiftingElement);
            visualizationHeap.SelectNodes(stateAutomaton.ShiftingElement);

            visualizationArray.DrawArray(stateAutomaton.Array, graphics);
            visualizationHeap.DrawHeap(stateAutomaton.Array, graphics);

            visualizationArray.DeselectElements(stateAutomaton.ShiftingElement);
            visualizationHeap.DeselectNodes(stateAutomaton.ShiftingElement);

        }

        public override void DrawSwap(StateAutomaton stateAutomaton)
        {
            base.DrawSwap(stateAutomaton);

            visualizationHeap.SelectNodes(stateAutomaton.SelectedElements.ToArray());

            visualizationHeap.DrawHeap(stateAutomaton.Array, graphics);

            visualizationHeap.DeselectNodes(stateAutomaton.SelectedElements.ToArray());
        }

        public void DrawCompare(StateAutomaton stateAutomaton)
        {

            visualizationHeap.SelectNodes(stateAutomaton.SelectedElements.ToArray());
            visualizationArray.SelectElements(stateAutomaton.SelectedElements.ToArray());

            visualizationArray.DrawArray(stateAutomaton.Array, graphics);
            visualizationHeap.DrawHeap(stateAutomaton.Array, graphics);

            visualizationHeap.DeselectNodes(stateAutomaton.SelectedElements.ToArray());
            visualizationArray.DeselectElements(stateAutomaton.SelectedElements.ToArray());
        }

        public override void ToStart(object sender, EventArgs e)
        {
            visualizationArray = new VisualizationArray(inputArray.Length);
            visualizationHeap = new VisualizationHeap(inputArray.Length);

            automatonSort.ToStart();
            
            this.visualizationArray.DrawArray(inputArray, this.graphics);
            this.visualizationHeap.DrawHeap(inputArray, this.graphics);
        }
    }
}
