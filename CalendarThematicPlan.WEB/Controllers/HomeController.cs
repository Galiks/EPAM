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

            if (errorMessage != null)
            {
                return View(model: errorMessage);
            }
            else
            {
                return View(model: "Ошибка");
            }
        }
    }
}