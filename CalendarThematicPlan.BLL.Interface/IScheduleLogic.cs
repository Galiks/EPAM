using CalendarThematicPlan.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarThematicPlan.BLL.Interface
{
    public interface IScheduleLogic
    {
        int? AddSchedule(string date, string room, string idSubject, string idGrade, string idUser);
        Schedule GetScheduleById(string id);
        IEnumerable<Schedule> GetSchedules();
        void UpdateSchedule(string id, string date, string room, string idSubject, string idGrade, string idUser);
        void DeleteSchedule(string id);
    }
}
