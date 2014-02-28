using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace MgicBall
{
    public class MgicBall : IBall
    {
        public MgicBall()
        {
            Console.WriteLine("The 8 ball alwaits your quetion....");

        }

        public string ObtainAnswrToQuetion(string userOption)
        {
            string[] answers = {"Future Uncertain", "Yes", "No", "Hazy", "Ask Again later", "Difinitely"};
            Random r = new Random();
            return answers[r.Next(answers.Length)];
        }
    }


    [ServiceContract]
    public interface IBall
    {
        [OperationContract]
        string ObtainAnswrToQuetion(string userOption);
    }
}
