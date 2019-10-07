using CalendarThematicPlan.BLL.Interface;
using CalendarThematicPlan.DAL.Interface;
using CalendarThematicPlan.Entity;
using CalendarThematicPlan.Validation;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CalendarThematicPlan.BLL.Logic
{
    public class ScheduleLogic : IScheduleLogic
    {
        private static readonly Logger loggerException = LogManager.GetLogger("exception");

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
                var exception = new ArgumentException($"Обязательные поля должны быть заполнены{Environment.NewLine}");
                loggerException.Error(exception);
                throw exception;
            }

            if (!DateTime.TryParse(date, out DateTime realDate))
            {
                var exception = new ArgumentException($"Неправильная дата урока{Environment.NewLine}");
                loggerException.Error(exception);
                throw exception;
            }

            if (!DateTime.TryParse(actualDate, out DateTime realActualDate))
            {
                var exception = new ArgumentException($"Неправильная актуальная дата урока{Environment.NewLine}");
                loggerException.Error(exception);
                throw exception;
            }

            if (!int.TryParse(idSubject, out int realIdSubject))
            {
                var exception = new ArgumentException($"Неправильный идентификатор урока{Environment.NewLine}");
                loggerException.Error(exception);
                throw exception;
            }

            if (!int.TryParse(idGrade, out int realIdGrade))
            {
                var exception = new ArgumentException($"Неправильный идентификатор класса{Environment.NewLine}");
                loggerException.Error(exception);
                throw exception;
            }

            if (!int.TryParse(idUser, out int realIdUser))
            {
                var exception = new ArgumentException($"Неправильный идентификатор учителя{Environment.NewLine}");
                loggerException.Error(exception);
                throw exception;
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

            try
            {
                return scheduleDao.AddSchedule(schedule);
            }
            catch (Exception e)
            {
                var exception = new Exception($"{e.Message}{Environment.NewLine}Inner Message: {e.InnerException.Message}{Environment.NewLine}");
                loggerException.Error(exception);
                throw exception;
            }
        }

        public void DeleteSchedule(string id)
        {
            if (!int.TryParse(id, out int idSchedule))
            {
                var exception = new ArgumentException($"Неправильный идентификатор расписания{Environment.NewLine}");
                loggerException.Error(exception);
                throw exception;
            }

            Schedule schedule = scheduleDao.GetScheduleById(idSchedule);

            //А вот с EF можно было сделать проще context.Schedules.Where(id => id = idSchedule).Any();
            if (schedule == null)
            {
                var exception = new ArgumentException($"Расписания с таким номером не существует{Environment.NewLine}");
                loggerException.Error(exception);
                throw exception;
            }

            try
            {
                scheduleDao.DeleteSchedule(idSchedule);
            }
            catch (Exception e)
            {
                var exception = new Exception($"{e.Message}{Environment.NewLine}Inner Message: {e.InnerException.Message}{Environment.NewLine}");
                loggerException.Error(exception);
                throw exception;
            }
        }

        public ReadableSchedule GetReadableScheduleById(string id)
        {
            if (!int.TryParse(id, out int idSchedule))
            {
                throw new ArgumentException("Неправильный идентификатор расписания");
            }

            return scheduleDao.GetReadableScheduleById(idSchedule);
        }

        public IEnumerable<ReadableSchedule> GetReadableSchedules()
        {
            return scheduleDao.GetReadableSchedules();
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

        public IEnumerable<ReadableSchedule> GetSchedulesByParametres(string firstName, string lastName, string patronymic, string subjectName, string gradeNumber, string gradeLetter)
        {
            if (!string.IsNullOrWhiteSpace(gradeNumber) & !int.TryParse(gradeNumber, out int realGradeNumber))
            {
                var exception = new ArgumentException($"Неправильный номер класса{Environment.NewLine}");
                loggerException.Error(exception);
                throw exception;
            }

            return scheduleDao.GetSchedulesByParameters(firstName, lastName, patronymic, subjectName, realGradeNumber, gradeLetter);
        }

        public void UpdateSchedule(string id, string date, string actualDate, string room, string idSubject, string idGrade, string idUser, string lessonTopic, string comment)
        {
            #region Validation
            if (!int.TryParse(id, out int IdSchedule))
            {
                var exception = new ArgumentException($"Неправильный идентификатор расписания{Environment.NewLine}");
                loggerException.Error(exception);
                throw exception;
            }

            if (!string.IsNullOrWhiteSpace(date) & !DateTime.TryParse(date, out DateTime realDate))
            {
                var exception = new ArgumentException($"Неправильная дата урока{Environment.NewLine}");
                loggerException.Error(exception);
                throw exception;
            }

            if (!string.IsNullOrWhiteSpace(actualDate) & !DateTime.TryParse(actualDate, out DateTime realActualDate))
            {
                var exception = new ArgumentException($"Неправильная актуальная дата урока{Environment.NewLine}");
                loggerException.Error(exception);
                throw exception;
            }

            if (!string.IsNullOrWhiteSpace(idSubject) & !int.TryParse(idSubject, out int realIdSubject))
            {
                var exception = new ArgumentException($"Неправильный идентификатор урока{Environment.NewLine}");
                loggerException.Error(exception);
                throw exception;
            }

            if (!string.IsNullOrWhiteSpace(idGrade) & !int.TryParse(idGrade, out int realIdGrade))
            {
                var exception = new ArgumentException($"Неправильный идентификатор класса{Environment.NewLine}");
                loggerException.Error(exception);
                throw exception;
            }

            if (!string.IsNullOrWhiteSpace(idUser) & !int.TryParse(idUser, out int realIdUser))
            {
                var exception = new ArgumentException($"Неправильный идентификатор учителя{Environment.NewLine}");
                loggerException.Error(exception);
                throw exception;
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

            try
            {
                scheduleDao.UpdateSchedule(schedule);
            }
            catch (Exception e)
            {
                var exception = new Exception($"{e.Message}{Environment.NewLine}Inner Message: {e.InnerException.Message}{Environment.NewLine}");
                loggerException.Error(exception);
                throw exception;
            }
        }
    }
}
