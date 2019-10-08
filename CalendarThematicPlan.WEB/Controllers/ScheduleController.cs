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
    public class ScheduleController : Controller
    {
        private readonly IScheduleLogic scheduleLogic;

        public IScheduleLogic ScheduleLogic => scheduleLogic;

        public ScheduleController()
        {
            scheduleLogic = NinjectCommon.Kernel.Get<IScheduleLogic>();
        }

        // GET: Schedule
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
                var schedule = scheduleLogic.GetReadableScheduleById(id.ToString());
                return View(schedule);
            }
            catch
            {
                return Redirect("~/Schedule/Index");
            }
        }

        public ActionResult Delete(int? id)
        {
            try
            {
                var schedule = scheduleLogic.GetReadableScheduleById(id.ToString());
                return View(schedule);
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", "Home", new { errorMessage = e.Message });
                //return Redirect("~/Home/Error");
            }
        }
    }
}