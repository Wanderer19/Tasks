﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Visualizer
{
    public class VisualizationArray
    {
        private bool[] selectedIndexes = new bool[]{};
        private bool [] indexesSortedPart = new bool[]{};
        private  List<Point> coordinatesElements;
        private int arrayLength;
        
        private readonly System.Drawing.Font digitsFont = new System.Drawing.Font("Arial", 20);
        private readonly System.Drawing.StringFormat formatDrawing = new System.Drawing.StringFormat();
        private readonly System.Drawing.SolidBrush digitsBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
        private readonly System.Drawing.SolidBrush elementsBrush = new System.Drawing.SolidBrush(System.Drawing.Color.LightCyan);
        private readonly Pen elementsPen = new Pen(Color.Blue, 7);
        private readonly System.Drawing.SolidBrush brushSortedPartArray = new SolidBrush(Color.DeepSkyBlue);

        private void IdentifyCoordinates()
        {
            coordinatesElements = new List<Point>();

            for (var i = 0; i < arrayLength; ++i)
            {
                coordinatesElements.Add(new Point(BubbleSortVisualizerSettings.PositionFirstElement.X + i * BubbleSortVisualizerSettings.WidthElemet,
                    BubbleSortVisualizerSettings.PositionFirstElement.Y));
            }
        }

        private bool IsSelected(int index)
        {
            return selectedIndexes[index];
        }

       
        private Point GetCoordinates(int index)
        {
            return coordinatesElements[index];
        }

        private Color GetColorElement(int index)
        {
            return this.IsSelected(index)
                    ? BubbleSortVisualizerSettings.SelectedElementColor
                    : BubbleSortVisualizerSettings.ElementColor;
        }

        private void SelectElements(params int [] indexes)
        {
            selectedIndexes = Enumerable.Range(0, arrayLength).Select(i => false).ToArray();

            foreach (var index in indexes.Where(i => i >=0 && i < arrayLength))
            {
                selectedIndexes[index] = true;
            }
        }

        public void DrawArray(StateAutomaton state, Graphics graphics)
        {
            arrayLength = state.Array.Length;
            IdentifyCoordinates();
            SelectElements(state.SelectedElements.ToArray());

            for (var i = 0; i < arrayLength; ++i)
            {
                    var rectangle = new Rectangle(GetCoordinates(i), BubbleSortVisualizerSettings.ElementSize);

                    graphics.FillRectangle(new SolidBrush(GetColorElement(i)), rectangle);
                    graphics.DrawRectangle(elementsPen, rectangle);
                    graphics.DrawString(state.Array[i].ToString(), digitsFont, digitsBrush,
                    GetCoordinates(i), formatDrawing);
            }

        }


        public  void DrawSortedPartArray(StateAutomaton state, Graphics graphics)
        {
            for (var i = 0; i <= state.BorderSortedPart; ++i)
            {
                var rectangle = new System.Drawing.Rectangle(GetCoordinates(i), BubbleSortVisualizerSettings.ElementSize);

                graphics.FillRectangle(brushSortedPartArray, rectangle);
                graphics.DrawRectangle(elementsPen, rectangle);
                graphics.DrawString(state.Array[i].ToString(), digitsFont, digitsBrush, GetCoordinates(i), formatDrawing);
            }
        }

        public void DrawSortedInvertedPartArray(StateAutomaton state, Graphics graphics)
        {
            arrayLength = state.Array.Length;
            IdentifyCoordinates();

            if (state.BorderSortedPart == -1) return;
            
            for (var i = state.BorderSortedPart; i < arrayLength; ++i)
            {
                var rectangle = new System.Drawing.Rectangle(GetCoordinates(i), BubbleSortVisualizerSettings.ElementSize);

                graphics.FillRectangle(brushSortedPartArray, rectangle);
                graphics.DrawRectangle(elementsPen, rectangle);
                graphics.DrawString(state.Array[i].ToString(), digitsFont, digitsBrush, GetCoordinates(i), formatDrawing);
            }
        }
    }
}
