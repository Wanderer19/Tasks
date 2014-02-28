using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  MgicBall;
using System.ServiceModel;

namespace WCF
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(MgicBall.MagicBall),
                new  Uri [] {new Uri("http://localhost:8080/MgicBall") }))
            
            {
                host.Open();
                Console.WriteLine("ready");
                Console.WriteLine("Enter key");
                Console.ReadKey();
            }
        }
    }
}
