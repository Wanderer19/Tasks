﻿using System;
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
        public const string StateCompare = "compare";
        public const string StateSwap = "swap";
        
        private readonly System.Drawing.Font digitsFont = new System.Drawing.Font("Arial", 20);
        private readonly System.Drawing.StringFormat formatDrawing = new System.Drawing.StringFormat();
        private readonly System.Drawing.SolidBrush digitsBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
        private readonly System.Drawing.SolidBrush elementsBrush = new System.Drawing.SolidBrush(System.Drawing.Color.LightCyan);
        private readonly Pen elementsPen = new Pen(Color.Blue, 7);
        private readonly System.Drawing.SolidBrush brushSortedPartArray = new SolidBrush(Color.DeepSkyBlue);
        
        public BubbleSortVisualizer(SortingForm parentWindow, int[] array)
        {
            this.parentWindow = parentWindow;
            this.inputArray = array;
            this.sortId = 1;
            selfTimer.Interval = 650;
            this.visualizationArray = new VisualizationArray(array.Length);
            this.automatonSort = new AutomatonBubbleSort(array);
            elementsPen.StartCap = LineCap.ArrowAnchor;
            elementsPen.EndCap = LineCap.ArrowAnchor;
           
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
            }
            
           base.DrawComment(stateAutomaton.DescriptionState);
        }

        public override void ClearOldComments()
        {
            base.ClearOldComments();
            graphics.FillRectangle(elementsBrush, BubbleSortVisualizerSettings.UpperCommentField);
        }


        private void DrawCompare(StateAutomaton state)
        {
            this.visualizationArray.DrawArray(state.Array, this.graphics);
            
            this.DrawCursor(state.SelectedElements[0]);
            this.DrawSymbolComparison(state.SelectedElements[0]);
        }

        private void DrawCursor(int index)
        {
            var points = new Point[]
            {
                new Point(BubbleSortVisualizerSettings.FirstPointerCoordinates[0].X + index * BubbleSortVisualizerSettings.WidthElemet, BubbleSortVisualizerSettings.FirstPointerCoordinates[0].Y), 
                new Point(BubbleSortVisualizerSettings.FirstPointerCoordinates[1].X + index * BubbleSortVisualizerSettings.WidthElemet, BubbleSortVisualizerSettings.FirstPointerCoordinates[1].Y),
                new Point(BubbleSortVisualizerSettings.FirstPointerCoordinates[2].X + index * BubbleSortVisualizerSettings.WidthElemet, BubbleSortVisualizerSettings.FirstPointerCoordinates[2].Y)
            };

           
            graphics.DrawCurve(elementsPen, points);
        }

        private void DrawSymbolComparison(int index)
        {
            graphics.DrawString(BubbleSortVisualizerSettings.SymbolComparison, digitsFont, digitsBrush, 80 + 100 * index, 100, formatDrawing);
        }
    }
}
