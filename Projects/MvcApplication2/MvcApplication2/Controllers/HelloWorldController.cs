using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication2.Controllers
{
    public class HelloWorldController : Controller
    {
        //
        // GET: /HelloWorld/

        public ActionResult Index()
        {
            return View();
        }

        public string Welcome(string name, int numTimes = 1)
        {
            string message = String.Format("Привет, {0}, time is {1}", name, numTimes);
            return "<html><body>" + message + "</body></html>";

        }
    }
}
