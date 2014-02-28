using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication4
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class Car
    {
        private readonly int _parser;

        public Car()
        {
            _parser = 100;
        }

        public void Display()
        {
            Console.WriteLine(_parser);
        }

    }
}
