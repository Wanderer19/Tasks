using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Visualizer
{
    public static class ArrayReader
    {
        public static bool IsValidValuesElementsInArray(ICollection<int> array, int sizeLimitArray, int limitArrayElementValue)
        {
            if (array.Count == 0 || array.Count > sizeLimitArray)
                return false;

            return !array.Any(i => Math.Abs(i) > limitArrayElementValue);
        }

        public static int[] ReadData(string inputData)
        {
                var array = new List<int>();
                inputData = Regex.Replace(inputData, @"\s+", ",");

                foreach (var i in inputData.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    int value;

                    if (Int32.TryParse(i, out value))
                        array.Add(value);
                    else
                    {
                        array = new List<int>();
                        break;
                    }
                    
                }

            return array.ToArray();
        }
    }
}
