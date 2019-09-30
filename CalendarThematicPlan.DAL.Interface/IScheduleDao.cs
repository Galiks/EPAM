using CalendarThematicPlan.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarThematicPlan.DAL.Interface
{
    public interface IScheduleDao
    {
        int? AddSchedule(Schedule grade);
        Schedule GetScheduleById(int id);
        void UpdateSchedule(Schedule grade);
        void DeleteSchedule(int id);
    }
}
