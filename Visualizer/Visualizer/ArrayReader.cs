using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Visualizer
{
    public static class ArrayReader
    {
        public static bool IsValidInputString(string inputData)
        {
            return inputData.Any(i => Char.IsWhiteSpace(i) || Char.IsNumber(i) || i == '-');
        }

        public static bool IsValidValuesElementsInArray(ICollection<int> array, int sizeLimitArray, int limitArrayElementValue)
        {
            if (array.Count == 0 || array.Count > sizeLimitArray)
                return false;

            return !array.Any(i => Math.Abs(i) > limitArrayElementValue);
        }

        public static int[] ReadData(string inputData)
        {
            int[] array;
            try
            {
                inputData = Regex.Replace(inputData, @"\s+", ",");

                array = inputData.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

            }
            catch (Exception ex)
            {
                array = new int[] {};
            }

            return array;
        }
    }
}
