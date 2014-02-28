using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Visualizer
{
    public class VisualizationHeap : IVisualizationHeap
    {
        private Dictionary<int, Rectangle> coordinatesNodesPyramid;
        private Dictionary<int, Tuple<Point, Point>> coordinatesEdges;
        private Dictionary<int, PointF> coordinatesValues; 
        public static readonly int OffsetBetweenNeighbors = 200;
        public static readonly int DistanceBetweenLevels = 85;
        public static readonly int NodesDiameter = 55;
        private int arrayLength;
        private bool [] selectedNodes = new bool[]{};
        
        private readonly Font nodesFontDigits = new System.Drawing.Font("Arial Black", 12.2F,
                System.Drawing.FontStyle.Bold,
                System.Drawing.GraphicsUnit.Point, ((byte)(204)));

       public static readonly Pen edgesPen = new Pen(Color.Blue, 2);
       public static readonly Rectangle rootsCoordinates = new Rectangle(940, 250, NodesDiameter, NodesDiameter);
       public static readonly PointF coordinatesRootsValue = new PointF(945, 270);
       public static readonly System.Drawing.Font digitsFont = new System.Drawing.Font("Arial", 20);
       public static readonly System.Drawing.StringFormat formatDrawing = new System.Drawing.StringFormat();
       public static readonly System.Drawing.SolidBrush digitsBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
       public static readonly System.Drawing.SolidBrush elementsBrush = new System.Drawing.SolidBrush(System.Drawing.Color.LightCyan);
       public static readonly Pen elementsPen = new Pen(Color.Blue, 5);
       public static readonly Color colorSortedPart = Color.DeepSkyBlue;
       public static readonly System.Drawing.SolidBrush brushSortedPartArray = new SolidBrush(Color.DeepSkyBlue);
       public static readonly Color selectedNodeColor = Color.MediumPurple;
       public static readonly Color nodeColor = Color.LightCyan;
       public static readonly PointF offsetTextNode = new PointF(5, 20);
       public static readonly Pen penInvisibleEdges = new Pen(Color.LightCyan, 4);

        public VisualizationHeap() { }

        public VisualizationHeap(int arrayLength)
        {
            this.arrayLength = arrayLength;
        }

        public  Rectangle GetCoordinatesNode(int index)
        {
            return coordinatesNodesPyramid[index];
        }

        public Tuple<Point, Point> GetCoordinatesEdge(int index)
        {
            return coordinatesEdges[index];
        }

        public PointF GetCoordinatesValue(int index)
        {
            return coordinatesValues[index];
        }

        public Color GetColorElement(int index, int borderSortedPart)
        {
            if (borderSortedPart >= 0 && index >= borderSortedPart)
                return colorSortedPart;
            
            return this.IsSelected(index)
                    ? selectedNodeColor
                    : nodeColor;
        }

        public void DefineCoordinates()
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

        public bool IsSelected(int index)
        {
            return selectedNodes[index];
        }

        public void SelectNodes(params int[] nodes)
        {

            selectedNodes = Enumerable.Range(0, arrayLength).Select(i => false).ToArray();

            foreach (var node in nodes.Where(node => node < arrayLength && node >= 0 ))
            {
                selectedNodes[node] = true;
            }
        }

        public void SelectNode(int index)
        {
            if (index >=0 && index < arrayLength)
                selectedNodes[index] = true;
        }

        public void DrawRoot(StateAutomaton state, Graphics graphics)
        {
            graphics.FillEllipse(new SolidBrush(GetColorElement(0, state.BorderSortedPart)), GetCoordinatesNode(0));
            graphics.DrawEllipse(elementsPen, GetCoordinatesNode(0));
            graphics.DrawString(state.Array[0].ToString(), nodesFontDigits, digitsBrush, GetCoordinatesValue(0),
                   formatDrawing);

        }
        public void DrawHeap(StateAutomaton state, Graphics graphics)
        {
            arrayLength = state.Array.Length;
            DefineCoordinates();

            SelectNodes(state.SelectedElements.ToArray());
            SelectNode(state.SiftingElement);
            DrawRoot(state, graphics);
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
            if (index != 0)
            {
                DrawEdge(index, false, graphics);
                var parent = GetParent(index);
                DrawNode(parent, state, graphics);
            }

            else
            {
                DrawRoot(state, graphics);
            }
        }

        public static int GetParent(int i)
        {
            if (i == 0)
                return 0;

            if ((i - 1)%2 == 0)
            {
                return (i - 1)/2;
            }
            
             return (i - 2)/2;
            
        }

    }
}
