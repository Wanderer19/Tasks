using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Visualizer
{
    public partial class BubbleSortVisualizer : Visualizer
    {
        private readonly System.Drawing.Font digitsFont = new System.Drawing.Font("Arial", 20);
        private readonly System.Drawing.StringFormat formatDrawing = new System.Drawing.StringFormat();
        private readonly System.Drawing.SolidBrush digitsBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
        private readonly System.Drawing.SolidBrush elementsBrush = new System.Drawing.SolidBrush(System.Drawing.Color.LightCyan);
        private readonly Pen elementsPen = new Pen(Color.Blue, 7);
        private readonly System.Drawing.SolidBrush brushSortedPartArray = new SolidBrush(Color.DeepSkyBlue);
        public readonly Point[] FirstPointerCoordinates = new Point[] { new Point(53, 180), new Point(100, 155), new Point(153, 180) };
        public readonly string SymbolComparison = "VS";

        public BubbleSortVisualizer(SortingForm parentWindow, int[] array)
        {
            this.parentWindow = parentWindow;
            this.inputArray = array;
            this.sortId = Application.IdentifiersSorts.BubbleSort;
            this.visualizationArray = new VisualizationArray();
            this.automatonSort = new AutomatonBubbleSort(array);
            elementsPen.StartCap = LineCap.ArrowAnchor;
            elementsPen.EndCap = LineCap.ArrowAnchor;
         }

        public override void DrawState(StateAutomaton stateAutomaton)
        {
            this.ClearOldComments();

            switch (stateAutomaton.StateId)
            {
                case (int) AutomatonBubbleSort.States.Condition:
                {
                    this.DrawCompare(stateAutomaton);
                    
                    break;
                }
                case (int) AutomatonBubbleSort.States.SwappingAdjacentElements:
                {
                    this.DrawSwap(stateAutomaton);
                    
                    break;
                }
                default:
                {
                    this.visualizationArray.DrawArray(stateAutomaton, graphics);

                    break;
                }
            }
            
           base.DrawComment(stateAutomaton.Comment);
        }

        public override void ClearOldComments()
        {
            base.ClearOldComments();
            graphics.FillRectangle(elementsBrush, UpperCommentField);
        }


        private void DrawCompare(StateAutomaton state)
        {
            this.visualizationArray.DrawArray(state, this.graphics);
            
            this.DrawCursor(state.SelectedElements[0]);
            this.DrawSymbolComparison(state.SelectedElements[0]);
        }

        private void DrawCursor(int index)
        {
            var points = new Point[]
            {
                new Point(FirstPointerCoordinates[0].X + index * VisualizationArray.WidthElemet, FirstPointerCoordinates[0].Y), 
                new Point(FirstPointerCoordinates[1].X + index * VisualizationArray.WidthElemet, FirstPointerCoordinates[1].Y),
                new Point(FirstPointerCoordinates[2].X + index * VisualizationArray.WidthElemet, FirstPointerCoordinates[2].Y)
            };

           
            graphics.DrawCurve(elementsPen, points);
        }

        private void DrawSymbolComparison(int index)
        {
            graphics.DrawString(SymbolComparison, digitsFont, digitsBrush, 80 + 100 * index, 100, formatDrawing);
        }
    }
}
