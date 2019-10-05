using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CalendarThematicPlan.WEB.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7 };
            return View(numbers);
        }

        public ActionResult Calendar()
        {
            return View();
        }

        public ActionResult LogIn()
        {
            return View();
        }

        public ActionResult SignOut()
        {
            return View();
        }
    }
}