using CalendarThematicPlan.BLL.Interface;
using Ninject;
using System.Web.Mvc;
using CalendarThematicPlan.Container;
using System;

namespace CalendarThematicPlan.WEB.Controllers
{
    public class GradeController : Controller
    {
        private readonly IGradeLogic gradeLogic = NinjectCommon.Kernel.Get<IGradeLogic>();
        // GET: Grade
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
                var grade = gradeLogic.GetGradeById(id.ToString());
                return View(grade);
            }
            catch
            {
                return Redirect("~/Grade/Index");
            }
        }

        public ActionResult Delete(int? id)
        {
            try
            {
                var grade = gradeLogic.GetGradeById(id.ToString());
                return View(grade);
            }
            catch
            {
                return Redirect("~/Grade/Index");
            }
        }

        public ActionResult PartialGetGrades()
        {
            return PartialView();
        }
    }
}