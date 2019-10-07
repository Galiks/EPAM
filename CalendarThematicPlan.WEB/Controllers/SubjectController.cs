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
    public class SubjectController : Controller
    {
        private readonly ISubjectLogic subjectLogic;

        public SubjectController()
        {
            this.subjectLogic = NinjectCommon.Kernel.Get<ISubjectLogic>();
        }


        // GET: Subject
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
            var subject = subjectLogic.GetSubjectById(id.ToString());
            return View(subject);
        }

        public ActionResult Delete(int? id)
        {
            var subject = subjectLogic.GetSubjectById(id.ToString());
            return View(subject);
        }
    }
}