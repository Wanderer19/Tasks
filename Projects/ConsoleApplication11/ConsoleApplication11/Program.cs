using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication11
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[5];

            foreach (var i in a)
            {
                Console.WriteLine(i);
            }

            HashSet<int> aa = new HashSet<int>();
        }
    }
}
