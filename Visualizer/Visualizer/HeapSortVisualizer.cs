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
    public partial class HeapSortVisualizer : Visualizer
    {
        private HeapSortArray heapSortArray;
        private DrawingToolsHeapSort drawingToolsHeapSort;

        public HeapSortVisualizer(SortingForm parentWindow, int [] array)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.parentWindow = parentWindow;
            this.inputArray = array;
            this.sortId = 1;
            selfTimer.Interval = 650;
            this.sortArray = new HeapSortArray(array.Length);
            this.heapSortArray = new HeapSortArray(array.Length);
            this.automatonSort = new AutomatonBubbleSort(array);
            this.drawingToolsHeapSort = new DrawingToolsHeapSort();

            drawingTools = new DrawingTools(BubbleSortVisualizerSettings.FontDigits, BubbleSortVisualizerSettings.FormatDrawing,
                                             BubbleSortVisualizerSettings.BrushDigit, BubbleSortVisualizerSettings.BrushElement,
                                             BubbleSortVisualizerSettings.PenElement);

            this.Paint += new PaintEventHandler(DrawInitialState);
            
        }

        public void DrawHeap(int [] array)
        {
            DrawRoot(array[0]);

            for (var i = 0; i <= array.Length / 2 - 1; ++i)
            {
                if (i * 2 + 1 < array.Length)
                {
                    DrawNode(i * 2 + 1, array);
                }
                if (i * 2 + 2 < array.Length)
                {
                    DrawNode(i * 2 + 2, array);
                }
            }
        }

        public void DrawRoot(int rootsValue)
        {
            graphics.DrawEllipse(drawingTools.PenElement, heapSortArray.GetCoordinatesNode(0));
            graphics.DrawString(rootsValue.ToString(), drawingToolsHeapSort.DigitsFont, drawingTools.BrushDigit, heapSortArray.GetCoordinatesValue(0), drawingTools.FormatDrawing);
        }

        public void DrawNode(int index, int[] array)
        {
            graphics.DrawEllipse(drawingTools.PenElement, heapSortArray.GetCoordinatesNode(index));
           
            var coordinatesEdge = heapSortArray.GetCoordinatesEdge(index);
            graphics.DrawLine(drawingToolsHeapSort.EdgesPen, coordinatesEdge.Item1, coordinatesEdge.Item2);
            
            graphics.DrawString(array[index].ToString(), drawingToolsHeapSort.DigitsFont, drawingTools.BrushDigit, heapSortArray.GetCoordinatesValue(index), drawingTools.FormatDrawing);
        }

        public override void DrawInitialState(object sender, PaintEventArgs e)
        {
            base.DrawInitialState(sender, e);
            DrawHeap(inputArray);
        }
    }
}
