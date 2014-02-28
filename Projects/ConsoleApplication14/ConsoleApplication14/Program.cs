using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication14
{
    class Program
    {
        static void HeapSort(ref int[] a)
        {
            int i;
            int temp;

            for (i = (a.Length / 2) - 1; i >= 0; i--)
            {
                siftDown(ref a, i, a.Length);
            }

            for (i = a.Length; i > 0; i--)
            {
                temp = a[0];
                a[0] = a[i - 1];
                a[i - 1] = temp;
                siftDown(ref a, 0, i - 1);
            }
        }

        static void siftDown(ref int[] a, int i, int j)
        {
            bool done = false;
            int maxChild;
            int temp;

            while ((i * 2 + 1 < j) && (!done))
            {
                maxChild = i*2 + 1;
                if (i * 2 + 2 < j && a[i * 2 + 2] > a[maxChild])
                    maxChild = i * 2 + 2;

                if (a[i] < a[maxChild])
                {
                    temp = a[i];
                    a[i] = a[maxChild];
                    a[maxChild] = temp;
                    i = maxChild;
                }
                else
                {
                    done = true;
                }
            }
        }
        static void Main(string[] args)
        {
            int[] a = new[] {-1, 0, 2, -99, 4};
            HeapSort(ref a);

            foreach (var i in a)
            {
                Console.WriteLine(i);
            }
        }
    }
}
