using CalendarThematicPlan.BLL.Interface;
using CalendarThematicPlan.Container;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            var user = userLogic.GetUserById(id.ToString());
            return View(user);
        }

        public ActionResult Delete(int? id)
        {
            var user = userLogic.GetUserById(id.ToString());
            return View(user);
        }

        public ActionResult Details(int? id)
        {
            var user = userLogic.GetUserById(id.ToString());
            return View(user);
        }
    }
}