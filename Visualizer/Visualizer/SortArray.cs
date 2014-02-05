using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Visualizer
{
    public class SortArray
    {
        private int[] array;
        private bool[] selectedIndexes = new bool[]{};
        private List<Point> coordinatesElements;

        public int Length { get { return array.Length; } }
        public SortArray(int[] array)
        {
            this.array = array;
           
            selectedIndexes = Enumerable.Range(0, array.Length).Select(i => false).ToArray();
            coordinatesElements = new List<Point>();
            for (var i = 0; i < array.Length; ++i)
            {
                coordinatesElements.Add(new Point(BubbleSortVisualizerSettings.PositionFirstElement.X + i * BubbleSortVisualizerSettings.WidthElemet,
                    BubbleSortVisualizerSettings.PositionFirstElement.Y));
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

        public Color GetColorElement(int index)
        {
            return this.IsSelected(index)
                    ? BubbleSortVisualizerSettings.SelectedElementColor
                    : BubbleSortVisualizerSettings.ElementColor;


        }

        public void SelectElement(int index)
        {
            selectedIndexes[index] = true;

        }

        public void DeselectElement(int index)
        {
            selectedIndexes[index] = false;
        }
       
        public void SelectElements(Tuple<int, int> indexes)
        {
           this.SelectElement(indexes.Item1);
           this.SelectElement(indexes.Item2);
        }

        public void DeselectElements(Tuple<int, int> indexes)
        {
           DeselectElement(indexes.Item1);
            DeselectElement(indexes.Item2);
        }

        public void DeselectAllElements()
        {
            for (var i = 0; i < array.Length; ++i)
                selectedIndexes[i] = false;
        }
    }
}
