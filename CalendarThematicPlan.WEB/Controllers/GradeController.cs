using CalendarThematicPlan.BLL.Interface;
using CalendarThematicPlan.Container;
using Ninject;
using System;
using System.Web.Mvc;

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
            catch (Exception e)
            {
                return RedirectToAction("Error", "Home", new { errorMessage = e.Message });
            }
        }

        public ActionResult Delete(int? id)
        {
            try
            {
                var grade = gradeLogic.GetGradeById(id.ToString());
                return View(grade);
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", "Home", new { errorMessage = e.Message });
            }
        }

        public ActionResult PartialGetGrades()
        {
            return PartialView();
        }
    }
}