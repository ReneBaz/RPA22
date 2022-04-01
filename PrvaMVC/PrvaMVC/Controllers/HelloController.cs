using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PrvaMVC.Controllers
{
    public class HelloController : Controller
    {
        // GET: Hello
        public string Index()
        {
            return "Pozdravljen MVC";
        }

        public string Pozdravljen(string ime, int st=1)
        {
            return "To je druga metoda "+ime+" "+st;
        }
       
    }
}