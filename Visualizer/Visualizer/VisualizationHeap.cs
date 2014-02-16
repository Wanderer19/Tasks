using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Visualizer
{
    public class VisualizationHeap
    {
        private Dictionary<int, Rectangle> coordinatesNodesPyramid;
        private Dictionary<int, Tuple<Point, Point>> coordinatesEdges;
        private Dictionary<int, PointF> coordinatesValues; 
        private const int OffsetBetweenNeighbors = 300;
        private const int DistanceBetweenLevels = 150;
        private const int NodesDiameter  = 75;
        private int arrayLength;
        private bool [] selectedNodes = new bool[]{};
        
        private readonly Font nodesFontDigits = new System.Drawing.Font("Arial Black", 12.2F,
                System.Drawing.FontStyle.Bold,
                System.Drawing.GraphicsUnit.Point, ((byte)(204)));

        private readonly Pen edgesPen = new Pen(Color.Blue, 2);
        private readonly Rectangle rootsCoordinates = new Rectangle(1290, 400, NodesDiameter, NodesDiameter);
        private readonly PointF coordinatesRootsValue = new PointF(1295, 420);
        private readonly System.Drawing.Font digitsFont = new System.Drawing.Font("Arial", 20);
        private readonly System.Drawing.StringFormat formatDrawing = new System.Drawing.StringFormat();
        private readonly System.Drawing.SolidBrush digitsBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
        private readonly System.Drawing.SolidBrush elementsBrush = new System.Drawing.SolidBrush(System.Drawing.Color.LightCyan);
        private readonly Pen elementsPen = new Pen(Color.Blue, 7);
        private readonly Color colorSortedPart = Color.DeepSkyBlue;
        private readonly System.Drawing.SolidBrush brushSortedPartArray = new SolidBrush(Color.DeepSkyBlue);
        private readonly Color selectedNodeColor = Color.MediumPurple;
        private readonly Color nodeColor = Color.LightCyan;
        private readonly PointF offsetTextNode = new PointF(5, 20);
        private readonly Pen penInvisibleEdges = new Pen(Color.LightCyan, 4);

        private  Rectangle GetCoordinatesNode(int index)
        {
            return coordinatesNodesPyramid[index];
        }

        private Tuple<Point, Point> GetCoordinatesEdge(int index)
        {
            return coordinatesEdges[index];
        }

        private PointF GetCoordinatesValue(int index)
        {
            return coordinatesValues[index];
        }

        private Color GetColorElement(int index, int borderSortedPart)
        {
            if (borderSortedPart >= 0 && index >= borderSortedPart)
                return colorSortedPart;
            
            return this.IsSelected(index)
                    ? selectedNodeColor
                    : nodeColor;
        }

        private void DefineCoordinates()
        {
            coordinatesNodesPyramid = new Dictionary<int, Rectangle>();
            coordinatesEdges = new Dictionary<int, Tuple<Point, Point>>();
            coordinatesValues = new Dictionary<int, PointF>();

            coordinatesNodesPyramid.Add(0, rootsCoordinates);
            coordinatesValues.Add(0, coordinatesRootsValue);

            var depthsNodes = new Dictionary<int, int> { { 0, 0 } };

            for (var i = 0; i <= arrayLength / 2 - 1; ++i)
            {
                if (coordinatesNodesPyramid.ContainsKey(i))
                {
                    depthsNodes.Add(i * 2 + 1, depthsNodes[i] + 1);
                    depthsNodes.Add(i * 2 + 2, depthsNodes[i] + 1);
                   
                    if (i * 2 + 1 < arrayLength)
                    {
                        
                        coordinatesNodesPyramid.Add(i * 2 + 1, new Rectangle(coordinatesNodesPyramid[i].X - OffsetBetweenNeighbors / (depthsNodes[i * 2 + 1]), coordinatesNodesPyramid[i].Y + DistanceBetweenLevels, NodesDiameter, NodesDiameter));
                        coordinatesEdges.Add(i*2+1, Tuple.Create(new Point(coordinatesNodesPyramid[i].X + NodesDiameter / 2, coordinatesNodesPyramid[i].Y + NodesDiameter),
                                        new Point(coordinatesNodesPyramid[i * 2 + 1].X + NodesDiameter / 2, coordinatesNodesPyramid[i*2+1].Y)));
                        coordinatesValues.Add(i*2+1, new PointF(coordinatesNodesPyramid[i*2+1].X + offsetTextNode.X, coordinatesNodesPyramid[i*2+1].Y + offsetTextNode.Y));
                    }
                    
                    if (i * 2 + 2 < arrayLength)
                    {
                        coordinatesNodesPyramid.Add(i * 2 + 2, new Rectangle(coordinatesNodesPyramid[i].X + OffsetBetweenNeighbors / (depthsNodes[i * 2 + 2]), coordinatesNodesPyramid[i].Y + DistanceBetweenLevels, NodesDiameter, NodesDiameter));
                        coordinatesEdges.Add(i * 2 + 2, Tuple.Create(new Point(coordinatesNodesPyramid[i].X + NodesDiameter / 2, coordinatesNodesPyramid[i].Y + NodesDiameter),
                                        new Point(coordinatesNodesPyramid[i * 2 + 2].X + NodesDiameter / 2, coordinatesNodesPyramid[i * 2 + 2].Y)));
                        coordinatesValues.Add(i * 2 + 2, new PointF(coordinatesNodesPyramid[i * 2 + 2].X + offsetTextNode.X, coordinatesNodesPyramid[i * 2 + 2].Y + offsetTextNode.Y));
                    }
                }
            }

        }

        private bool IsSelected(int index)
        {
            return selectedNodes[index];
        }

        private void SelectNodes(params int[] nodes)
        {

            selectedNodes = Enumerable.Range(0, arrayLength).Select(i => false).ToArray();

            foreach (var node in nodes.Where(node => node < arrayLength && node >= 0 ))
            {
                selectedNodes[node] = true;
            }
        }

        private void SelectNode(int index)
        {
            if (index >=0 && index < arrayLength)
                selectedNodes[index] = true;
        }

        public void DrawHeap(StateAutomaton state, Graphics graphics)
        {
            arrayLength = state.Array.Length;
            DefineCoordinates();

            SelectNodes(state.SelectedElements.ToArray());
            SelectNode(state.SiftingElement);
            DrawNode(0, state, graphics);
            for (var i = 0; i <= arrayLength / 2 - 1; ++i)
            {
                
                
                if (i * 2 + 1 < arrayLength)
                    DrawNode(i * 2 + 1, state, graphics);
                
                if (i * 2 + 2 < arrayLength)
                    DrawNode(i * 2 + 2, state, graphics);
            }
        }

        private void DrawNode(int index, StateAutomaton state,  Graphics graphics)
        {
            if (state.BorderSortedPart >= 0 && index >= state.BorderSortedPart)
                DrawDetachedNode(index, state, graphics);
            else
                DrawEdge(index, true, graphics);

            
            graphics.FillEllipse(new SolidBrush(GetColorElement(index, state.BorderSortedPart)), GetCoordinatesNode(index));
            graphics.DrawEllipse(elementsPen, GetCoordinatesNode(index));

            graphics.DrawString(state.Array[index].ToString(), nodesFontDigits, digitsBrush, GetCoordinatesValue(index),
                    formatDrawing);
        }

        private void DrawEdge(int index, bool isVisible, Graphics graphics)
        {
            if (index != 0)
            {
                var coordinatesEdge = GetCoordinatesEdge(index);

                var pen = isVisible ? edgesPen : penInvisibleEdges;
                graphics.DrawLine(pen, coordinatesEdge.Item1, coordinatesEdge.Item2);
            }
        }

        private void DrawDetachedNode(int index, StateAutomaton state, Graphics graphics)
        {
            DrawEdge(index, false, graphics);
            var parent = GetParent(index);
            
            DrawNode(parent, state, graphics);
        }

        private static int GetParent(int i)
        {
            if ((i - 1)%2 == 0)
            {
                return (i - 1)/2;
            }
            
             return (i - 2)/2;
            
        }

    }
}
