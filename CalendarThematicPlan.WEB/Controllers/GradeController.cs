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
            var grades = gradeLogic.GetGrades();
            return View(grades);
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}