using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Visualizer
{
    public class HeapSortArray : SortArray
    {
        private Dictionary<int, Rectangle> coordinatesNodesPyramid;
        private Dictionary<int, Tuple<Point, Point>> coordinatesEdges;
        private Dictionary<int, PointF> coordinatesValues; 
        private const int OffsetBetweenNeighbors = 200;
        private const int DistanceBetweenLevels = 100;
        private const int NodesDiameter  = 60;

        public HeapSortArray(int arrayLength) : base(arrayLength)
        {
            coordinatesNodesPyramid = new Dictionary<int, Rectangle>();
            coordinatesEdges = new Dictionary<int, Tuple<Point, Point>>();
            coordinatesValues = new Dictionary<int, PointF>();
            
            DefineCoordinates();
        }

        public Rectangle GetCoordinatesNode(int index)
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

        public void DefineCoordinates()
        {
            coordinatesNodesPyramid.Add(0, new Rectangle(1300, 400, NodesDiameter, NodesDiameter));
            coordinatesValues.Add(0, new PointF(1310, 410));
            var depthsNodes = new Dictionary<int, int> { { 0, 0 } };

            for (var i = 0; i <= Length / 2 - 1; ++i)
            {
                if (coordinatesNodesPyramid.ContainsKey(i))
                {
                    depthsNodes.Add(i * 2 + 1, depthsNodes[i] + 1);
                    depthsNodes.Add(i * 2 + 2, depthsNodes[i] + 1);
                   
                    if (i * 2 + 1 < Length)
                    {
                        
                        coordinatesNodesPyramid.Add(i * 2 + 1, new Rectangle(coordinatesNodesPyramid[i].X - OffsetBetweenNeighbors / (depthsNodes[i * 2 + 1]), coordinatesNodesPyramid[i].Y + DistanceBetweenLevels, NodesDiameter, NodesDiameter));
                        coordinatesEdges.Add(i*2+1, Tuple.Create(new Point(coordinatesNodesPyramid[i].X + NodesDiameter / 2, coordinatesNodesPyramid[i].Y + NodesDiameter),
                                        new Point(coordinatesNodesPyramid[i * 2 + 1].X + NodesDiameter / 2, coordinatesNodesPyramid[i*2+1].Y)));
                        coordinatesValues.Add(i*2+1, new PointF(coordinatesNodesPyramid[i*2+1].X + 10, coordinatesNodesPyramid[i*2+1].Y + 10));
                    }
                    
                    if (i * 2 + 2 < Length)
                    {
                        coordinatesNodesPyramid.Add(i * 2 + 2, new Rectangle(coordinatesNodesPyramid[i].X + OffsetBetweenNeighbors / (depthsNodes[i * 2 + 2]), coordinatesNodesPyramid[i].Y + DistanceBetweenLevels, NodesDiameter, NodesDiameter));
                        coordinatesEdges.Add(i * 2 + 2, Tuple.Create(new Point(coordinatesNodesPyramid[i].X + NodesDiameter / 2, coordinatesNodesPyramid[i].Y + NodesDiameter),
                                        new Point(coordinatesNodesPyramid[i * 2 + 2].X + NodesDiameter / 2, coordinatesNodesPyramid[i * 2 + 2].Y)));
                        coordinatesValues.Add(i * 2 + 2, new PointF(coordinatesNodesPyramid[i * 2 + 2].X + 10, coordinatesNodesPyramid[i * 2 + 2].Y + 10));
                    }
                }
            }

        }
    }
}
