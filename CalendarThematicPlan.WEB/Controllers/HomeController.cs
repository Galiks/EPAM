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
            return View();
        }

        public ActionResult Calendar()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult SignOut()
        {
            return View();
        }

        public ActionResult Error(string errorMessage)
        {
            string message = errorMessage;
            return View(model: message);
        }
    }
}