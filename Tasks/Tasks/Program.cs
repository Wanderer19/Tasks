
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Server
{
    internal class Program
    {
        private static Dictionary<string, string> requests = new Dictionary<string, string>();
        private static List<Task> tasks = new List<Task>();
        protected const string ServerUrl = "http://172.20.14.60:10000";
        protected const string MyUrl = "http://+:31337/";

        public static void SendResponse(HttpListenerResponse response, string str)
        {
            var result = Encoding.UTF8.GetBytes(str);

            response.ContentLength64 = result.Length;
            response.OutputStream.Write(result, 0, result.Count());
            response.Close();
        }

        public static void ProcessRequest(HttpListenerResponse response, string query)
        {
            WebRequest webRequest = WebRequest.Create(ServerUrl + query);
            var resp = webRequest.GetResponse();
            var str = resp.GetResponseStream();
            var reader = new StreamReader(str);
            var outp = reader.ReadToEnd();

            requests.Add(query, outp);
            SendResponse(response, outp);
        }

        public static void AddTask(HttpListener listener)
        {
            var context = listener.GetContext();

            tasks.Add(Task.Factory.StartNew(
                () =>
                {
                    var request = context.Request;
                    var stream = request.InputStream;
                    var query = request.Url.Query;
                    var response = context.Response;

                    if (requests.ContainsKey(query))
                        SendResponse(response, requests[query]);
                    else
                    {
                        var regex = new Regex(@".query=.");
                        lock (requests)
                        {
                            if (regex.IsMatch(query))
                                ProcessRequest(response, query);
                        }
                    }
                }
                ));
        }

        private static void Main(string[] args)
        {
            var listener = new HttpListener();
            listener.Prefixes.Add(string.Format(MyUrl));
            listener.Start();

            while (true)
            {
                AddTask(listener);
                Task.WaitAll(tasks.ToArray());
            }

        }
    }
}