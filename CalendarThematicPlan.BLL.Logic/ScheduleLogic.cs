using CalendarThematicPlan.BLL.Interface;
using CalendarThematicPlan.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarThematicPlan.BLL.Logic
{
    public class ScheduleLogic : IScheduleLogic
    {
        public int? AddSchedule(string date, string actualDate, string room, string idSubject, string idGrade, string idUser, string lessonTopic, string comment)
        {
            throw new NotImplementedException();
        }

        public void DeleteSchedule(string id)
        {
            throw new NotImplementedException();
        }

        public Schedule GetScheduleById(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Schedule> GetSchedules()
        {
            throw new NotImplementedException();
        }

        public void UpdateSchedule(string id, string date, string actualDate, string room, string idSubject, string idGrade, string idUser, string lessonTopic, string comment)
        {
            throw new NotImplementedException();
        }
    }
}
