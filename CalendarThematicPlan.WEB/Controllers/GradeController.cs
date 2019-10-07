using CalendarThematicPlan.BLL.Interface;
using Ninject;
using System.Web.Mvc;
using CalendarThematicPlan.Container;

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
            var grade = gradeLogic.GetGradeById(id.ToString());
            return View(grade);
        }

        public ActionResult Delete(int? id)
        {
            var grade = gradeLogic.GetGradeById(id.ToString());
            return View(grade);
        }

        public ActionResult PartialGetGrades()
        {
            return PartialView();
        }
    }
}