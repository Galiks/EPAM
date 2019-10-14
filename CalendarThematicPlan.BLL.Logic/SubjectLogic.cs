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
    public class SubjectLogic : ISubjectLogic
    {
        private static readonly Logger loggerException = LogManager.GetLogger("exception");
        private static readonly Logger loggerUser = LogManager.GetLogger("user");

        private readonly ISubjectDao subjectDao;
        private readonly IUserDao userDao;

        public SubjectLogic(ISubjectDao subjectDao, IUserDao userDao)
        {
            this.subjectDao = subjectDao;
            this.userDao = userDao;

            LogException = LoggerException;
            LogUser = LoggerUser;
        }

        public event EventHandler LogException;
        public event EventHandler LogUser;

        public int? AddSubject(string name, string hours)
        {
            if (Validator.IsStringsNull(name, hours))
            {
                var exception = new ArgumentException($"Обязательные поля должны быть заполнены{Environment.NewLine}");
                LogException(exception, new EventArgs());
                throw exception;
            }

            if (!int.TryParse(hours, out int realHours))
            {
                var exception = new ArgumentException($"Неправильное количество часов{Environment.NewLine}");
                LogException(exception, new EventArgs());
                throw exception;
            }

            Subject subject = new Subject { Name = name, Hours = realHours };

            try
            {
                var result = subjectDao.AddSubject(subject);
                LogUser($"Добавлен новый предмет {subject}", new EventArgs());
                return result;
            }
            catch (Exception e)
            {
                var exception = new Exception($"{e.Message}{Environment.NewLine}Inner Message: {e.InnerException?.Message}{Environment.NewLine}");
                LogException(exception, new EventArgs());
                throw exception;
            }
        }

        public void DeleteSubject(string id)
        {
            if (!int.TryParse(id, out int idSubject))
            {
                var exception = new ArgumentException($"Идентификатор предмета должен быть числом{Environment.NewLine}");
                LogException(exception, new EventArgs());
                throw exception;
            }

            Subject subject = subjectDao.GetSubjectById(idSubject);

            if (subject == null)
            {
                var exception = new ArgumentException($"Предмета с таким идентификатором не существует{Environment.NewLine}");
                LogException(exception, new EventArgs());
                throw exception;
            }

            try
            {
                subjectDao.DeleteSubject(idSubject);
                LogUser($"Удалён предмет {subject}", new EventArgs());
            }
            catch (Exception e)
            {
                var exception = new Exception($"{e.Message}{Environment.NewLine}Inner Message: {e.InnerException?.Message}{Environment.NewLine}");
                loggerException.Error(exception);
                throw exception;
            }
        }

        public Subject GetSubjectById(string id)
        {
            if (!int.TryParse(id, out int idSubject))
            {
                var exception = new ArgumentException($"Идентификатор предмета должен быть числом{Environment.NewLine}");
                LogException(exception, new EventArgs());
                throw exception;
            }

            return subjectDao.GetSubjectById(idSubject);
        }

        public IEnumerable<Subject> GetSubjects()
        {
            return subjectDao.GetSubjects().ToList();
        }

        public IEnumerable<Subject> GetSubjectsByUser(string id)
        {
            if (!int.TryParse(id, out int idUser))
            {
                var exception = new ArgumentException($"Идентификатор предмета должен быть числом{Environment.NewLine}");
                LogException(exception, new EventArgs());
                throw exception;
            }

            if (userDao.GetUserById(idUser) == null)
            {
                var exception = new ArgumentException($"Предмета с таким идентификатором не существует{Environment.NewLine}");
                LogException(exception, new EventArgs());
                throw exception;
            }

            return subjectDao.GetSubjectsByUser(idUser);
        }

        public IEnumerable<Subject> GetSubjectsByWord(string word)
        {
            return subjectDao.GetSubjectsByWord(word);
        }

        public void LoggerException(object sender, EventArgs e)
        {
            loggerException.Error(sender.ToString());
        }

        public void LoggerUser(object sender, EventArgs e)
        {
            loggerUser.Info(sender.ToString());
        }

        public void UpdateSubject(string id, string name, string hours)
        {
            if (!int.TryParse(id, out int idSubject))
            {
                var exception = new ArgumentException($"Идентификатор урока должен быть числом{Environment.NewLine}");
                LogException(exception, new EventArgs());
                throw exception;
            }

            if (!string.IsNullOrWhiteSpace(hours) & !int.TryParse(hours, out int realHours))
            {
                var exception = new ArgumentException($"Неправильное количество часов{Environment.NewLine}");
                LogException(exception, new EventArgs());
                throw exception;
            }

            Subject subject;
            if (idSubject == default)
            {
                var exception = new ArgumentException($"Идентификатор урока неправильный{Environment.NewLine}");
                LogException(exception, new EventArgs());
                throw exception;
            }
            else
            {
                subject = subjectDao.GetSubjectById(idSubject);
            }

            subject.Name = string.IsNullOrWhiteSpace(name) ? subject.Name : name;
            subject.Hours = hours == default ? subject.Hours : realHours;

            try
            {
                subjectDao.UpdateSubject(subject);
                LogUser($"Обновлён предмет {subject}", new EventArgs());
            }
            catch (Exception e)
            {
                var exception = new Exception($"{e.Message}{Environment.NewLine}Inner Message: {e.InnerException?.Message}{Environment.NewLine}");
                LogException(exception, new EventArgs());
                throw exception;
            }
        }
    }
}
