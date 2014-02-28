using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Threading.Timer;

namespace ConsoleApplication8
{
    class AddParams
    {
        public int a, b;

        public AddParams(int x, int y)
        {
            a = x;
            b = y;
        }
    }

   
    [Synchronization]
    class Printer
    {
        private static object ThreadLock = new object();
        public  void PrintNumbers()
        {
            lock (ThreadLock)
            {


                Console.WriteLine("Print {0}", Thread.CurrentThread.ManagedThreadId);
                Console.WriteLine("Your numbers");
                Random r = new Random();
                for (int i = 0; i < 10; ++i)
                {
                    Console.WriteLine("{0}", i);
                    Thread.Sleep(1000*r.Next(5));
                }
            }
        }
    }
    public delegate int BinaryOp(int x, int y);
    class Program
    {
        public static bool isDone = false;
        private static AutoResetEvent waitHandle = new AutoResetEvent(false);

        public static void PrintTime(object state)
        {
            Console.WriteLine("Time is ir {0}", DateTime.Now.ToLongTimeString());
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Delegate Review");
            Console.WriteLine("Main  ID {0}", Thread.CurrentThread.ManagedThreadId);
            /*BinaryOp b = new BinaryOp(Add);
            IAsyncResult res = b.BeginInvoke(5, 5, new AsyncCallback(AddComplete), "Please");

            while(!isDone)
            {
                Console.WriteLine("Doing more work in Main");
                Thread.Sleep(1000);
            }
            //int answer = b.EndInvoke(res);


            //Console.WriteLine("5 + 5 = {0}", answer);*/

         /* Console.WriteLine("Choise");
            int res = Int32.Parse(Console.ReadLine());
            if(res == 1)
            {
                Printer.PrintNumbers();
                Console.WriteLine("End");
            }
            else
            {
                ThreadStart ts = new ThreadStart(Printer.PrintNumbers);
                Thread myThread = new Thread(ts);
                myThread.Name = "Secondary";
                myThread.Start();
            }
            Console.WriteLine("YEEEEEES!");
            MessageBox.Show("Happy!");

            AddParams ap = new AddParams(5, 5);
            ParameterizedThreadStart ps = new ParameterizedThreadStart(Add);
            Thread th = new Thread(ps);
            //th.IsBackground = true;
            th.Start(ap);
            //Thread.Sleep(5);
            waitHandle.WaitOne();
            Console.WriteLine("Done!");
           // Console.ReadLine();*/

          /*  Printer p = new Printer();
            Thread [] threads = new Thread[10];
            for (int i = 0; i < 10; ++i)
            {
                threads[i] = new Thread(new ThreadStart(p.PrintNumbers));
            }

            foreach (var thread in threads)
            {
                thread.Start();
            }*/

            /*TimerCallback tm = new TimerCallback(PrintTime);
            Timer t = new Timer(tm, 
                null, //инфа в функцию
                0, //время ожидания перед запуском
                1000//Интервал времени между вызовами
                );
            Console.WriteLine("Hit key to Terminate.....");*/

            Printer p = new Printer();
            WaitCallback callback = new WaitCallback(PrintTheNumbers);

            for (int i = 0; i < 10; ++i)
            {
                ThreadPool.QueueUserWorkItem(callback, p);
            }
            Console.WriteLine("The end!");
            Console.ReadLine();
        }

        static void PrintTheNumbers(object state)
        {
            Printer task = (Printer) state;
            task.PrintNumbers();
        }

       /* static int Add(int x, int y)
        {
            Console.WriteLine("Add ID {0}", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(5000);//Пауза для моделирования длительной операции
            return x + y;
        }*/

        static void AddComplete(IAsyncResult res)
        {
            Console.WriteLine("Add complete {0}", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Your additional is complete");
            AsyncResult ar = (AsyncResult) res;
            BinaryOp op = (BinaryOp) ar.AsyncDelegate;
            Console.WriteLine("5 + 5 = {0}", op.EndInvoke(res));
            string msg = (string) ar.AsyncState;
            Console.WriteLine(msg);
            isDone = true;

        }

        public static void Add(object obj)
        {
            if (obj is AddParams)
            {
                Console.WriteLine("Add {0}", Thread.CurrentThread.ManagedThreadId);
                AddParams ap = (AddParams) obj;
                Console.WriteLine("{0} + {1} = {2}", ap.a, ap.b, ap.a + ap.b);
                waitHandle.Set();
            }
        }

    }
}
