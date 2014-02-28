using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new Dictionary<string, int>
            {
                {"Masha", 19},
                {"Dasha", 19},
                {"Denis", 23},
                {"Nastya", 18},
                {"Kirill", 5}
            };

            var x = from i in a where i.Value >= 19 orderby i.Key select i.Key;
            var  ii = (from i in a where i.Value >= 19 select i.Key).Count<string>();

            Console.WriteLine(ii);
            foreach (var variable in x)
            {
                Console.WriteLine(variable);
            }

            Console.ReadKey();
        }
    }
}
