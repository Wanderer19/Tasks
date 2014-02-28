using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Делегаты
{
    public delegate int BinaryOp(int x, int y);

    public struct Bee
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Bee(string s, int x) : this()
        {
            Name = s;
            Age = x;
        }

        public void Print()
        {
            Console.WriteLine("Name is {0}", Name);
            Console.WriteLine("Age = {0}", Age);
        }
    }

   
    public class SimpleMath
    {
        public  int Add(int a, int b)
        {
            return a + b;
        }

        public  int Subtract(int a, int b)
        {
            return a - b;
        }
    }
    class Program
    {
        static void DisplayDelegateInfo(Delegate delObj)
        {
            foreach (var d in delObj.GetInvocationList())
            {
                Console.WriteLine("Method Name : {0}", d.Method);
                Console.WriteLine("Type Name : {0}", d.Target);
            }
        }

        static void Main(string[] args)
        {
            var s = new SimpleMath();
            var b  = new BinaryOp(s.Add);
            
            Console.WriteLine("10 + 10 = {0}", b(10, 10));
            DisplayDelegateInfo(b);

            int[]a = {10, -100, 20, 200, 70};

            var x = from i in a orderby  i descending  select i / 10;

            foreach (var i in x)
            {
                Console.WriteLine(i);
            }

            var bb = new List<Bee>
            {
                new Bee("Masha", 19),
                new Bee("Nastya", 18),
                new Bee("Dasha", 19),
                new Bee("Flux", 46),
                new Bee("DDD", 23)
            };

            var ar1 = new List<string> {"Masha", "Nastya", "Dasha", "July", "DDD"};
            var ar2 = new List<Bee>
            {
                new Bee("Masha", 19),
                new Bee("Dasha", 19),
                new Bee("Nastya", 18)
            };

            var res = from i in ar2 join p in ar1 on i.Name equals p orderby i.Age descending select i;

            foreach (var bee in res)
            {
                bee.Print();
            }

            var dd = from bee in bb group bee by bee.Age into beegroup orderby beegroup.Key descending select beegroup;

            foreach (var f in dd)
            {
                Console.WriteLine("Count {0}", f.Count());

                foreach (var bee in f)
                {
                    bee.Print();
                }
            }

            string[] ss = {"Masha", "asda", "sg"};
            var sd = from i in ss select i.ToUpper() + "   !";

            foreach (var variable in sd)
            {
                Console.WriteLine(variable);
            }

            var list = new List<int>{1, 20, 10, 205,};
            list = list.FindAll(i => (i%2 == 0));

            foreach (var i in list)
            {
                Console.WriteLine(i);
            }

            var xx = new {Name = "Masha", Age = 19, University = "UFU"};
            Console.WriteLine("Name is {0}, age = {1}, university - {2}", xx.Name, xx.Age, xx.University);
            Console.ReadKey();
        }
    }
}
