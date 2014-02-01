using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visualizer
{
    class Array
    {
        private int[] array;

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
            var y = 100;

            var x1 = 28;
            var y1 = 125;
           
          
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
    }
}
