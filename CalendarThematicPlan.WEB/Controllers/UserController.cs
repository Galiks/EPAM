using CalendarThematicPlan.BLL.Interface;
using CalendarThematicPlan.Container;
using Ninject;
using System;
using System.Web.Mvc;

namespace CalendarThematicPlan.WEB.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserLogic userLogic;

        public UserController()
        {
            this.userLogic = NinjectCommon.Kernel.Get<IUserLogic>();
        }

        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Update(int? id)
        {
            try
            {
                var user = userLogic.GetUserById(id.ToString());
                return View(user);
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", "Home", new { errorMessage = e.Message });
            }
        }

        public ActionResult UpdatePassword(int? id)
        {
            try
            {
                var user = userLogic.GetUserById(id.ToString());
                return View(user);
            }
            catch(Exception e)
            {
                return RedirectToAction("Error", "Home", new { errorMessage = e.Message });
            }
        }

        public ActionResult Delete(int? id)
        {
            try
            {
                var user = userLogic.GetUserById(id.ToString());
                return View(user);
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", "Home", new { errorMessage = e.Message });
            }
        }

        public ActionResult Details(int? id)
        {
            try
            {
                var user = userLogic.GetUserById(id.ToString());
                return View(user);
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", "Home", new { errorMessage = e.Message });
            }
        }
    }
}