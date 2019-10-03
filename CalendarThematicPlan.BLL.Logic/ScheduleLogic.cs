using CalendarThematicPlan.BLL.Interface;
using CalendarThematicPlan.DAL.Interface;
using CalendarThematicPlan.Entity;
using CalendarThematicPlan.Validation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CalendarThematicPlan.BLL.Logic
{
    public class ScheduleLogic : IScheduleLogic
    {
        private readonly IScheduleDao scheduleDao;

        public ScheduleLogic(IScheduleDao scheduleDao)
        {
            this.scheduleDao = scheduleDao;
        }

        public int? AddSchedule(string date, string actualDate, string room, string idSubject, string idGrade, string idUser, string lessonTopic, string comment)
        {
            #region Validation
            if (Validator.IsStringsNull(date, actualDate, room, idSubject, idGrade, idUser))
            {
                throw new ArgumentException("Обязательные поля должны быть заполнены");
            }

            if (!DateTime.TryParse(date, out DateTime realDate))
            {
                throw new ArgumentException("Неправильная дата урока");
            }

            if (!DateTime.TryParse(actualDate, out DateTime realActualDate))
            {
                throw new ArgumentException("Неправильная актуальная дата урока");
            }

            if (!int.TryParse(idSubject, out int realIdSubject))
            {
                throw new ArgumentException("Неправильный идентификатор урока");
            }

            if (!int.TryParse(idGrade, out int realIdGrade))
            {
                throw new ArgumentException("Неправильный идентификатор класса");
            }

            if (!int.TryParse(idUser, out int realIdUser))
            {
                throw new ArgumentException("Неправильный идентификатор учителя");
            }
            #endregion

            Schedule schedule = new Schedule
            {
                Date = realDate,
                ActualDate = realActualDate,
                Room = room,
                IdSubject = realIdSubject,
                IdGrade = realIdGrade,
                IdUser = realIdUser,
                LessonTopic = lessonTopic,
                Comment = comment
            };

            return scheduleDao.AddSchedule(schedule);
        }

        public void DeleteSchedule(string id)
        {
            if (!int.TryParse(id, out int idSchedule))
            {
                throw new ArgumentException("Неправильный идентификатор расписания");
            }

            Schedule schedule = scheduleDao.GetScheduleById(idSchedule);

            //А вот с EF можно было сделать проще context.Schedules.Where(id => id = idSchedule).Any();
            if (schedule == null)
            {
                throw new Exception("Расписания с таким номером не существует");
            }

            scheduleDao.DeleteSchedule(idSchedule);
        }

        public Schedule GetScheduleById(string id)
        {
            if (!int.TryParse(id, out int idSchedule))
            {
                throw new ArgumentException("Неправильный идентификатор расписания");
            }

            return scheduleDao.GetScheduleById(idSchedule);
        }

        public IEnumerable<Schedule> GetSchedules()
        {
            return scheduleDao.GetSchedules().ToList();
        }

        public void UpdateSchedule(string id, string date, string actualDate, string room, string idSubject, string idGrade, string idUser, string lessonTopic, string comment)
        {
            #region Validation
            if (!int.TryParse(id, out int IdSchedule))
            {
                throw new ArgumentException("Неправильный идентификатор расписания");
            }

            if (!string.IsNullOrWhiteSpace(date) & !DateTime.TryParse(date, out DateTime realDate))
            {
                throw new ArgumentException("Неправильная дата урока");
            }

            if (!string.IsNullOrWhiteSpace(actualDate) & !DateTime.TryParse(actualDate, out DateTime realActualDate))
            {
                throw new ArgumentException("Неправильная актуальная дата урока");
            }

            if (!string.IsNullOrWhiteSpace(idSubject) & !int.TryParse(idSubject, out int realIdSubject))
            {
                throw new ArgumentException("Неправильный идентификатор урока");
            }

            if (!string.IsNullOrWhiteSpace(idGrade) & !int.TryParse(idGrade, out int realIdGrade))
            {
                throw new ArgumentException("Неправильный идентификатор класса");
            }

            if (!string.IsNullOrWhiteSpace(idUser) & !int.TryParse(idUser, out int realIdUser))
            {
                throw new ArgumentException("Неправильный идентификатор учителя");
            }
            #endregion

            Schedule schedule;
            if (IdSchedule == default)
            {
                throw new ArgumentException("Неправильный идентификатор расписания");
            }
            else
            {
                schedule = scheduleDao.GetScheduleById(IdSchedule);
            }

            //Вот, вроде, надо эту проверку поставить второй, так как, если нет таких данных, то все остальные проверки теряют смысл. С другой стороны есть чёткий порядок проверок
            if (schedule == null)
            {
                throw new Exception("Расписания с таким номером не существует");
            }

            schedule.Date = realDate == default ? schedule.Date : realDate;
            schedule.ActualDate = realActualDate == default ? schedule.ActualDate : realActualDate;
            schedule.Room = string.IsNullOrWhiteSpace(room) ? schedule.Room : room;
            schedule.IdSubject = realIdSubject == default ? schedule.IdSubject : realIdSubject;
            schedule.IdGrade = realIdGrade == default ? schedule.IdGrade : realIdGrade;
            schedule.IdUser = realIdUser == default ? schedule.IdUser : realIdUser;
            schedule.LessonTopic = string.IsNullOrWhiteSpace(lessonTopic) ? schedule.LessonTopic : lessonTopic;
            schedule.Comment = string.IsNullOrWhiteSpace(comment) ? schedule.Comment : comment;

            scheduleDao.UpdateSchedule(schedule);
        }
    }
}
