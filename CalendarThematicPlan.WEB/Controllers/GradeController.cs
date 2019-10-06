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
        public ActionResult Index(string action)
        {
            ViewBag.Message = "Это частичное представление.";
            if (action == "create")
            {
                return Redirect("~/Grade/Create");
            }
            if (action == "update")
            {
                return Redirect("~/Grade/Update");
            }
            if (action == "delete")
            {
                return Redirect("~/Grade/Delete");
            }

            return View();
        }

        public ActionResult Create()
        {
            return View();
        }       

        public ActionResult Update()
        {
            return View();
        }

        public ActionResult Delete()
        {
            return View();
        }

        public ActionResult PartialGetGrades()
        {
            
            //var grades = gradeLogic.GetGrades();
            return PartialView();
        }
    }
}