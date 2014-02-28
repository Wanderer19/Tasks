using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;

namespace Life
{
    public class Field
    {
        public List<Tuple<int, int>> AliveCells { get; set; }

        public int MinX { get; set; }
        public int MaxX { get; set; }
        public int MinY { get; set; }
        public int MaxY { get; set; }

        public Field()
        {
            
        }

        public Field(List<Tuple<int, int>> alive)
        {
            AliveCells = alive;

            MinX = AliveCells.Select(x => x.Item1).Min();
            MinY = AliveCells.Select(y => y.Item2).Min();

            MaxX = AliveCells.Select(x => x.Item1).Max();
            MaxY = AliveCells.Select(y => y.Item2).Max();
        }

        public static Field CreatStartField(params int[] cells)
        {
            var newAliveCells = new List<Tuple<int, int>>();

            for (var i = 0; i < cells.Length; i += 2)
            {
                newAliveCells.Add(Tuple.Create(cells[i], cells[i + 1]));
            }

            return new Field(newAliveCells);
        }

        public int CountAliveNeibs(int x, int y)
        {
            return (
                    from i in Enumerable.Range(x - 1, 3)
                    from j in Enumerable.Range(y - 1, 3)
                    where !(i == x && j == y) && AliveCells.Contains(Tuple.Create(i, j))
                    select i
                   ).Count();
        }

        public bool IsAlive(int x, int y)
        {
            var countNeibs = CountAliveNeibs(x, y);

            return countNeibs == 3 || (countNeibs == 2 && AliveCells.Contains(Tuple.Create(x, y)));
        }

        public void NextStep()
        {
            var newAliveCells = new List<Tuple<int, int>>();

            for (var i = MinX - 1; i <= MaxX + 1; ++i)
            {
                for (var j = MinY - 1; j <= MaxY + 1; ++j)
                {
                    if (IsAlive(i, j))
                        newAliveCells.Add(Tuple.Create(i, j));
                }
            }

            AliveCells = newAliveCells;
            this.ChangeSize();
        }

        public void ChangeSize()
        {
            var newMinX = AliveCells.Select(x => x.Item1).Min();
            var newMinY = AliveCells.Select(y => y.Item2).Min();

            var newMaxX = AliveCells.Select(x => x.Item1).Max();
            var newMaxY = AliveCells.Select(y => y.Item2).Max();

            if (newMaxX > MaxX)
                MaxX = newMaxX;

            if (newMaxY > MaxY)
                MaxY = newMaxY;

            if (newMinX < MinX)
                MinX = newMinX;

            if (newMinY < MinY)
                MinY = newMinY;
        }

        public void Show()
        {
            for (var i = MinX - 1; i <= MaxX + 1; ++i)
            {
                for (var j = MinY - 1; j <= MaxY + 1; ++j)
                {
                    Console.Write(AliveCells.Contains(Tuple.Create(i, j)) ? "." : " ");
                }
                Console.WriteLine();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowHeight = 50;
            Console.WindowWidth = 50;
            var fields = new[]
            {
                Life.Field.CreatStartField(1, 1, 2, 2, 2, 3, 3, 1, 3, 2),
                Life.Field.CreatStartField(1, 1, 1, 2, 1, 3),
                Life.Field.CreatStartField(1, 2, 2, 1, 2, 2, 2, 3),
                Life.Field.CreatStartField(1, 1, 1, 2, 1, 3, 1, 4),
                Life.Field.CreatStartField(1, 4, 1, 5, 1, 6, 2, 4, 2, 5, 2, 6, 3, 4, 3, 5, 3, 6, 4, 1, 4, 2, 4, 3, 5, 1,
                    5, 2, 5, 3, 6, 1, 6, 2, 6, 3),
                Life.Field.CreatStartField(1, 5, 1, 6, 2, 5, 2, 6, 4, 5, 4, 6, 4, 7, 4, 8, 5, 1, 5, 2, 5, 4, 5, 9, 6, 1,
                    6, 2, 6, 4, 6, 5, 6, 9, 7, 4, 7, 6, 7, 7, 7, 9, 7, 11, 7, 12, 8, 4, 8, 9, 8, 11, 8, 12, 9, 5, 9, 6,
                    9, 7, 9, 8, 11, 7, 11, 8, 12, 7, 12, 8),
                Life.Field.CreatStartField(1, 2, 1, 3, 2, 1, 2, 2, 2, 3, 2, 4, 3, 1, 3, 2, 3, 4, 3, 5, 4, 3, 4, 4, 9, 1,
                    9, 2, 10, 2, 10, 3, 11, 1, 11, 2, 12, 1, 15, 2, 15, 3, 16, 1, 16, 2, 16, 3, 16, 4, 17, 1, 17, 2, 17,
                    4, 17, 5, 18, 3, 18, 4),
                Life.Field.CreatStartField(6, 1, 6, 2, 7, 1, 7, 2, 3, 14, 4, 13, 4, 15, 5, 12, 5, 16, 5, 17, 6, 12, 6,
                    16, 6, 17, 7, 12, 7, 16, 7, 17, 8, 13, 8, 15, 9, 14, 1, 26, 2, 23, 2, 24, 2, 25, 2, 26, 3, 22, 3, 23,
                    3, 24, 3, 25, 4, 22, 4, 25, 5, 22, 5, 23, 5, 24, 5, 25, 6, 23, 6, 24, 6, 25, 6, 26, 7, 26, 10, 23,
                    10, 25, 11, 24, 11, 25, 12, 24, 2, 31, 3, 31, 4, 35, 4, 36, 5, 35, 5, 36, 17, 31, 18, 32, 18, 33, 19,
                    31, 19, 32, 24, 41, 24, 46, 25, 39, 25, 40, 25, 42, 25, 43, 25, 44, 25, 45, 25, 47, 25, 48, 26, 41,
                    26, 46),
                Life.Field.CreatStartField(6, 1, 6, 2, 7, 1, 7, 2, 3, 14, 4, 13, 4, 15, 5, 12, 5, 16, 5, 17, 6, 12, 6,
                    16, 6, 17, 7, 12, 7, 16, 7, 17, 8, 13, 8, 15, 9, 14, 1, 26, 2, 23, 2, 24, 2, 25, 2, 26, 3, 22, 3, 23,
                    3, 24, 3, 25, 4, 22, 4, 25, 5, 22, 5, 23, 5, 24, 5, 25, 6, 23, 6, 24, 6, 25, 6, 26, 7, 26, 10, 23,
                    10, 25, 11, 24, 11, 25, 12, 24, 2, 31, 3, 31, 4, 35, 4, 36, 5, 35, 5, 36, 17, 31, 18, 32, 18, 33, 19,
                    31, 19, 32, 24, 41, 24, 46),
                 Life.Field.CreatStartField(1, 3, 2, 1, 2, 4, 3, 1, 3, 4, 4, 2),
                 Life.Field.CreatStartField(1, 1, 1, 4, 2, 5, 3, 1, 3, 5, 4, 2, 4, 3, 4, 4, 4, 5),
                 Life.Field.CreatStartField(1, 2, 1, 4, 1, 5, 1, 9, 1, 10, 1, 11, 3, 1, 4, 1, 5, 1, 3, 6, 4, 6, 5, 6, 3, 8, 4, 8, 5, 8, 3, 13, 4, 13, 5, 13, 6, 3, 6, 4, 6, 5, 6, 9, 6, 10, 6, 11, 8, 3, 8, 4, 8, 5, 8, 9, 8, 10, 8, 11, 9, 1, 10, 1, 11, 1, 9, 6, 10, 6, 11, 6, 9, 8, 10, 8, 11, 8, 9, 13, 10, 13, 11, 13, 13, 3, 13, 4, 13, 5, 13, 9, 13, 10, 13, 11)
            };

            
            for (var i = 0; i < fields.Length; ++i)
            {
                Console.WriteLine("{0} :", i + 1);
                fields[i].Show();
            }

            

            var isValidKey = false;
            Field field = new Field();
            var x = 0;
            while (!isValidKey)
            {
                Console.WriteLine("Choose start field :");
                x = Int32.Parse(Console.ReadLine());
                if (x > 0 && x <= fields.Length)
                {
                    field = fields[x - 1];
                    isValidKey = true;
                }

                Console.WriteLine("Wrong!Repeat please!");
            }

            while (true)
            {
                Console.Clear();
                field.Show();
                if (x != 7 && x != 8 && x != 9 && x != 12)
                    Thread.Sleep(200);
                field.NextStep();
            }


        }
    }
}
