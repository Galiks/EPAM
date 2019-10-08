using CalendarThematicPlan.Entity;
using System.Collections.Generic;

namespace CalendarThematicPlan.DAL.Interface
{
    public interface IScheduleDao
    {
        int? AddSchedule(Schedule schedule);
        Schedule GetScheduleById(int id);
        IEnumerable<Schedule> GetSchedules();
        void UpdateSchedule(Schedule schedule);
        void DeleteSchedule(int id);
        IEnumerable<ReadableSchedule> GetSchedulesByParameters(string firstName, string lastName, string patronymic, string subjectName, int gradeNumber, string gradeLetter);
        IEnumerable<ReadableSchedule> GetReadableSchedules();
        ReadableSchedule GetReadableScheduleById(int id);
    }
}
