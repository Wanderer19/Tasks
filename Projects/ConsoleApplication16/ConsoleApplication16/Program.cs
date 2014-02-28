using System;
using System.Collections.Generic;
using System.Text;

namespace Factorization
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.Write("n=");
            int n = int.Parse(Console.ReadLine());
            if (n == 0)
            {
                Console.WriteLine(10);
            }
            else
            {
            Factorization f = new Factorization();
            List<int> div = f.GetFactors(n);
            string res = "";
            bool flag = true;
            int tmp = 1;
                bool fl = false;
            for (int i = 0; i < div.Count - 1; i++)
            {
               
                if (div[i] < 10)
                {
           
                    tmp *= div[i + 1]*div[i];
                    if (tmp < 10)
                    {
                        if (i + 1 == div.Count - 1)
                            fl = true;
                        res += tmp.ToString();
                    }
                    else
                    {
                        tmp = 1;
                        res += div[i].ToString();
                    }
                }
                else
                {
                    flag = false;
                    break;
                }
            }

                if (flag )
                {
                    if (fl)
                        Console.WriteLine(res);
                    else 
                        Console.WriteLine(res + div[div.Count - 1].ToString());
                }
                
          
            else
            {
                Console.WriteLine(-1);
            }
        }

        }
    }

    public class Factorization
    {
        List<int> Dividers;//делители

        public List<int> GetFactors(int n)
        {
            Dividers = new List<int>();
            Factorize(n);
            Dividers.Sort();
            return Dividers;
        }

        private void Factorize(int k)
        {
            int mult = 1;//произвеление делителей, полученных на текущем шаге
            List<int> div = new List<int>();//делители, полученные на текущем шаге
            for (int i = 2; i <= Math.Floor(Math.Sqrt(k)); i++)//проходим по числам от 2 до корня из k
            {
                if (k % i == 0) //если делит...
                {
                    bool IsPrime = true;
                    foreach (int j in div)//проверяем делитель на простоту
                        if (i % j == 0) { IsPrime = false; break; }
                    if (IsPrime)//если делитель прост, то сохраняем
                    {
                        div.Add(i);
                        mult *= i;
                    }
                }
            }
            if (mult == 1) { Dividers.Add(k); return; } //если k не имело собственных делителей, то разложение завершено
            else
            {
                Dividers.AddRange(div);//в противном случае сохраняем все полученные делители
                int next = k / mult;
                if (next == 1) return;//если осталась 1, то разложение закончено
                Factorize(next);//иначе рекурсивно вызываем метод для разложения числа после вычеркивания всех делителей, полученных на этом шаге
                //в mult находится свободный от квадратов делитель k
            }
        }
    }
}