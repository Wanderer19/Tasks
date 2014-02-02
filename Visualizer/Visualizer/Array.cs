using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Visualizer
{
    class Array
    {
        public int[] array;

        public List<System.Drawing.Point> RectangleCoordinates { get; set; }
        public List<System.Drawing.Point> ValuesCoordinates { get; set; }
        public List<Color> Colors { get; set; } 
       
        public Array(int[] array)
        {
            this.array = array;
            
            RectangleCoordinates = new List<Point>();
            ValuesCoordinates = new List<Point>();
            Colors = new List<Color>();
            
            var x = 3;
            var y = 200;

            var x1 = 28;
            var y1 = 225;
           
          
            foreach (var value in array)
            {
                Colors.Add(Color.LightCyan);

                RectangleCoordinates.Add(new System.Drawing.Point(x, y));
                
                if (Math.Abs(value) >= 100 || (value <= -10))
                    ValuesCoordinates.Add(new System.Drawing.Point(x1 - 10, y1));
                else
                    ValuesCoordinates.Add(new System.Drawing.Point(x1, y1));
               
                x += 100;
                x1 += 100;
            }

        }

        public int GetValue(int i)
        {
            return array[i];

        }
        public void Swap(int i1, int j)
        {
            var x = 3;
            var y = 200;

            var x1 = 28;
            var y1 = 225;


            for (var i = 0; i < array.Length; ++i)
            {
                Colors.Add(Color.LightCyan);

                RectangleCoordinates.Add(new System.Drawing.Point(x, y));

                if (Math.Abs(array[i]) >= 100 || (array[i] <= -10))
                    ValuesCoordinates[i] = new System.Drawing.Point(x1 - 10, y1);
                else
                    ValuesCoordinates[i] = new System.Drawing.Point(x1, y1);

                x += 100;
                x1 += 100;
            }
        }
    }
}
