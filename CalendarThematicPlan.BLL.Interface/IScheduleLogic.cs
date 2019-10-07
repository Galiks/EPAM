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
        int? AddSchedule(string date, string actualDate, string room, string idSubject, string idGrade, string idUser, string lessonTopic, string comment);
        Schedule GetScheduleById(string id);
        IEnumerable<Schedule> GetSchedules();
        void UpdateSchedule(string id, string date, string actualDate, string room, string idSubject, string idGrade, string idUser, string lessonTopic, string comment);
        void DeleteSchedule(string id);
        IEnumerable<ReadableSchedule> GetSchedulesByParametres(string firstName, string lastName, string patronymic, string subjectName, string gradeNumber, string gradeLetter);
        IEnumerable<ReadableSchedule> GetReadableSchedules();
        ReadableSchedule GetReadableScheduleById(string id);
    }
}
