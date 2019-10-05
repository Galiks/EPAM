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

        public ActionResult GetGrades()
        {
            var grades = gradeLogic.GetGrades();
            return PartialView(grades);
        }

        public ActionResult Update()
        {
            return View();
        }

        public ActionResult Delete()
        {
            return View();
        }
    }
}