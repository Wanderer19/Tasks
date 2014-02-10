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
        private readonly VisualizationHeap visualizationHeap;

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
            this.automatonSort = new AutomatonBubbleSort(array);

            this.Paint += new PaintEventHandler(DrawInitialState);
            
        }
       
        public override void DrawInitialState(object sender, PaintEventArgs e)
        {
            base.DrawInitialState(sender, e);
            this.visualizationHeap.DrawHeap(inputArray, graphics);
        }

        public override void DrawState(StateAutomaton stateAutomaton)
        {
            base.DrawState(stateAutomaton);
        }
    }
}
