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
        public SelectionSortVisualizer(SortingForm mainForm, int [] array)
        {
            this.mainForm = mainForm;

            this.sortArray = new SortArray(array);

            drawingTools = new DrawingTools(BubbleSortVisualizerSettings.FontDigits, BubbleSortVisualizerSettings.FormatDrawing,
                                             BubbleSortVisualizerSettings.BrushDigit, BubbleSortVisualizerSettings.BrushElement,
                                             BubbleSortVisualizerSettings.PenElement);
            InitializeComponent();
            this.Paint += new PaintEventHandler(DrawInitialState);
        }

        public override void ToStart(object sender, EventArgs e)
        {

        }

        public override void EnableAutomaticMode(object sender, EventArgs e)
        {

        }

        public override void DoStepForward(object sender, EventArgs e)
        {

        }

        public override void DoStepBackward(object sender, EventArgs e)
        {

        }

        public override void DoPause(object sender, EventArgs e)
        {

        }

        public override void Proceed(object sender, EventArgs e)
        {

        }
    }
}
