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
        //private int[] array;
        private bool[] selectedIndexes = new bool[]{};
        private List<Point> coordinatesElements;

        public int Length { get; private set; }
        public SortArray(int arrayLength)
        {
            this.Length = arrayLength;
            selectedIndexes = Enumerable.Range(0, arrayLength).Select(i => false).ToArray();
            coordinatesElements = new List<Point>();
            for (var i = 0; i < arrayLength; ++i)
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

        public Color GetColorElement(int index)
        {
            return this.IsSelected(index)
                    ? BubbleSortVisualizerSettings.SelectedElementColor
                    : BubbleSortVisualizerSettings.ElementColor;


        }

        private void SelectElement(int index)
        {
            selectedIndexes[index] = true;

        }

        private void DeselectElement(int index)
        {
            selectedIndexes[index] = false;
        }
       
        public void SelectElements(params int [] indexes)
        {
            foreach (var index in indexes)
            {
                this.SelectElement(index);
            }
        }

        public void DeselectElements(params int [] indexes)
        {
            foreach (var index in indexes)
            {
                this.DeselectElement(index);
            }
        }

        public void DeselectAllElements()
        {
            for (var i = 0; i < Length; ++i)
                selectedIndexes[i] = false;
        }
    }
}
