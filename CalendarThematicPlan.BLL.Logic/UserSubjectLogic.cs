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
    public class UserSubjectLogic : IUserSubjectLogic
    {
        private static readonly Logger loggerException = LogManager.GetLogger("exception");
        private static readonly Logger loggerUser = LogManager.GetLogger("user");

        private readonly IUserSubjectDao userSubjectDao;

        public UserSubjectLogic(IUserSubjectDao userSubjectDao)
        {
            this.userSubjectDao = userSubjectDao;
        }

        public int? AddUserSubject(string idSubject, string idUser)
        {
            if (Validator.IsStringsNull(idSubject, idUser))
            {
                var exception = new ArgumentException($"Обязательные поля должны быть заполнены{Environment.NewLine}");
                loggerException.Error(exception);
                throw exception;
            }

            if (!int.TryParse(idSubject, out int realIdSubject))
            {
                var exception = new ArgumentException($"Идентификатор урока должен быть числом{Environment.NewLine}");
                loggerException.Error(exception);
                throw exception;
            }

            if (!int.TryParse(idUser, out int realIdUser))
            {
                var exception = new ArgumentException($"Идентификатор пользователя должен быть числом{Environment.NewLine}");
                loggerException.Error(exception);
                throw exception;
            }

            UserSubject userSubject = new UserSubject { IdSubject = realIdSubject, IdUser = realIdUser };

            try
            {
                var result = userSubjectDao.AddUserSubject(userSubject);
                loggerUser.Info($"Добавлена новая связь Пользователь-Предмет {userSubject}");
                return result;
            }
            catch (Exception e)
            {
                var exception = new Exception($"{e.Message}{Environment.NewLine}Inner Message: {e.InnerException?.Message}{Environment.NewLine}");
                loggerException.Error(exception);
                throw exception;
            }
        }

        public void DeleteUserSubject(string id)
        {
            if (!int.TryParse(id, out int idUserSubject))
            {
                var exception = new ArgumentException($"Идентификатор таблицы Пользователь-Урок должен быть числом{Environment.NewLine}");
                loggerException.Error(exception);
                throw exception;
            }

            UserSubject userSubject = userSubjectDao.GetUserSubjectById(idUserSubject);

            if (userSubject == null)
            {
                var exception = new Exception($"Такой объект не найден{Environment.NewLine}");
                loggerException.Error(exception);
                throw exception;
            }

            try
            {
                userSubjectDao.DeleteUserSubject(idUserSubject);
                loggerUser.Info($"Удалена связь Пользователь-Предмет {userSubject}");
            }
            catch (Exception e)
            {
                var exception = new Exception($"{e.Message}{Environment.NewLine}Inner Message: {e.InnerException?.Message}{Environment.NewLine}");
                loggerException.Error(exception);
                throw exception;
            }
        }

        public UserSubject GetUserSubjectByid(string id)
        {
            if (!int.TryParse(id, out int idUserSubject))
            {
                var exception = new ArgumentException($"Идентификатор таблицы Пользователь-Урок должен быть числом{Environment.NewLine}");
                loggerException.Error(exception);
                throw exception;
            }

            return userSubjectDao.GetUserSubjectById(idUserSubject);
        }

        public IEnumerable<UserSubject> GetUserSubjects()
        {
            return userSubjectDao.GetUserSubjects().ToList();
        }

        public void UpdateUserSubjects(string id, string idSubject, string idUser)
        {
            if (!int.TryParse(id, out int idUserSubject))
            {
                var exception = new ArgumentException($"Идентификатор таблицы Пользователь-Урок должен быть числом{Environment.NewLine}");
                loggerException.Error(exception);
                throw exception;
            }

            if (!string.IsNullOrWhiteSpace(idSubject) & !int.TryParse(idSubject, out int realIdSubject))
            {
                var exception = new ArgumentException($"Идентификатор урока должен быть числом{Environment.NewLine}");
                loggerException.Error(exception);
                throw exception;
            }

            if (!string.IsNullOrWhiteSpace(idUser) & !int.TryParse(idUser, out int realIdUser))
            {
                var exception = new ArgumentException($"Идентификатор пользователя должен быть числом{Environment.NewLine}");
                loggerException.Error(exception);
                throw exception;
            }

            try
            {
                UserSubject userSubject = userSubjectDao.GetUserSubjectById(idUserSubject);

                userSubject.IdSubject = realIdSubject == default ? userSubject.IdSubject : realIdSubject;
                userSubject.IdUser = realIdUser == default ? userSubject.IdUser : realIdUser;

                userSubjectDao.UpdateUserSubject(userSubject);

                loggerUser.Info($"Обновлена связь Пользователь-Предмет {userSubject}");
            }
            catch (Exception e)
            {
                var exception = new Exception($"{e.Message}{Environment.NewLine}Inner Message: {e.InnerException?.Message}{Environment.NewLine}");
                loggerException.Error(exception);
                throw exception;
            }
        }
    }
}
