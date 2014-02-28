using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Visualizer
{
    class Array
    {
        private int[] array;
        private bool[] selectedIndexes = new bool[]{};
        private List<Point> coordinatesElements;

        public int Length { get { return array.Length; } }
        public Array(int[] array)
        {
            this.array = array;
           
            selectedIndexes = Enumerable.Range(0, array.Length).Select(i => false).ToArray();

            for (var i = 0; i < array.Length; ++i)
            {
                coordinatesElements.Add(new Point(BubbleSortVisualizerSettings.positionFirstElement.X + i * BubbleSortVisualizerSettings.widthElemet,
                    BubbleSortVisualizerSettings.positionFirstElement.Y + i  *  BubbleSortVisualizerSettings.widthElemet));
            }
        }

        public bool IsSelected(int index)
        {
            return selectedIndexes[index];
        }

        public Point GetCoordinates(int index)
        {
            return coordinatesElements[index];
        }

        public string GetValue(int index)
        {
            return array[index].ToString();
        }
    }
}
