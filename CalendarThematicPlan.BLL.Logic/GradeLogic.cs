using CalendarThematicPlan.BLL.Interface;
using CalendarThematicPlan.DAL.Interface;
using CalendarThematicPlan.Entity;
using CalendarThematicPlan.Validation;
using NLog;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;

namespace CalendarThematicPlan.BLL.Logic
{
    public class GradeLogic : IGradeLogic
    {
        private static readonly Logger loggerException = LogManager.GetLogger("exception");
        private static readonly Logger loggerUser = LogManager.GetLogger("user");

        private readonly string patternForGradeId = @"\d+";
        private readonly IGradeDao gradeDao;

        public event EventHandler LogException;
        public event EventHandler LogUser;

        public GradeLogic(IGradeDao gradeDao)
        {
            this.gradeDao = gradeDao;
            LogException += LoggerException;
            LogUser += LoggerUser;
        }

        public int? AddGrade(string number, string letter, string kidsInClass)
        {
            if (Validator.IsStringsNull(number, letter, kidsInClass))
            {
                var exception = new ArgumentException($"Обязательные поля должны быть заполнены{ Environment.NewLine}");
                LogException(exception, new EventArgs());
                throw exception;
            }

            if (!int.TryParse(number, out int realNumber) & realNumber <= 0)
            {
                var exception = new ArgumentException($"Неправильный номер класса{Environment.NewLine}");
                LogException(exception, new EventArgs());
                throw exception;
            }

            if (!int.TryParse(kidsInClass, out int realKidsInClass) & realKidsInClass <= 0)
            {
                var exception = new ArgumentException($"Неправильное количество детей в классе{Environment.NewLine}");
                LogException(exception, new EventArgs());
                throw exception;
            }

            Grade grade = new Grade { Number = realNumber, Letter = letter, KidsInClass = realKidsInClass };

            try
            {
                var result = gradeDao.AddGrade(grade);
                LogUser($"Доабвлен новый класс {grade}", new EventArgs());
                return result;
            }
            catch (Exception e)
            {
                var exception = new Exception($"{e.Message}{Environment.NewLine}Inner Message: {e.InnerException?.Message}{Environment.NewLine}");
                LogException(exception, new EventArgs());
                throw exception;
            }
        }

        public void DeleteGrade(string id)
        {
            var matches = Regex.Matches(id, patternForGradeId);

            if (!int.TryParse(matches[0].ToString(), out int idGrade))
            {
                var exception = new ArgumentException($"Идентификатор класса должен быть числом{Environment.NewLine}");
                LogException(exception, new EventArgs());
                throw exception;
            }

            Grade grade = gradeDao.GetGradeById(idGrade);

            if (grade == null)
            {
                var exception = new ArgumentException($"Класса с таким идентификатором не существует{Environment.NewLine}");
                LogException(exception, new EventArgs());
                throw exception;
            }

            try
            {
                gradeDao.DeleteGrade(idGrade);
                LogUser($"Удалён класс {grade}", new EventArgs());
            }
            catch (SqlException e)
            {
                var exception = new Exception($"Попытка удалить класс, который является элементом расписания");
                LogException(exception, new EventArgs());
                throw e;
            }
            catch (Exception e)
            {
                var exception = new Exception($"{e.Message}{Environment.NewLine}Inner Message: {e.InnerException?.Message}{Environment.NewLine}");
                LogException(exception, new EventArgs());
                throw exception;
            }
        }

        public Grade GetGradeById(string id)
        {
            var matches = Regex.Matches(id, patternForGradeId);

            if (!int.TryParse(matches[0].ToString(), out int idGrade))
            {
                var exception = new ArgumentException($"Идентификатор класса должен быть числом{Environment.NewLine}");
                loggerException.Error(exception);
                throw exception;
            }

            return gradeDao.GetGradeById(idGrade);
        }

        public IEnumerable<Grade> GetGrades()
        {
            return gradeDao.GetGrades().ToList();
        }

        public void UpdateGrade(string id, string number, string letter, string kidsInClass)
        {
            if (!int.TryParse(id, out int idGrade))
            {
                var exception = new ArgumentException($"Идентификатор класса должен быть числом{Environment.NewLine}");
                loggerException.Error(exception);
                throw exception;
            }

            if (!string.IsNullOrWhiteSpace(number) & !int.TryParse(number, out int realNumber) & realNumber <= 0)
            {
                var exception = new ArgumentException($"Неправильный номер класса{Environment.NewLine}");
                loggerException.Error(exception);
                throw exception;
            }

            if (!string.IsNullOrWhiteSpace(kidsInClass) & !int.TryParse(kidsInClass, out int realKidsInClass) & realKidsInClass <= 0)
            {
                var exception = new ArgumentException($"Неправильное количество детей в классе{Environment.NewLine}");
                loggerException.Error(exception);
                throw exception;
            }

            Grade grade;
            if (idGrade == default)
            {
                var exception = new ArgumentException($"Идентификатор класса неправильный{Environment.NewLine}");
                loggerException.Error(exception);
                throw exception;
            }
            else
            {
                grade = gradeDao.GetGradeById(idGrade);
                if (grade == null)
                {
                    var exception = new ArgumentException($"Класса с таким идентификатором не существует{Environment.NewLine}");
                    loggerException.Error(exception);
                    throw exception;
                }
            }

            grade.Number = realNumber == default ? grade.Number : realNumber;
            grade.Letter = string.IsNullOrWhiteSpace(letter) ? grade.Letter : letter;
            grade.KidsInClass = realKidsInClass == default ? grade.KidsInClass : realKidsInClass;

            try
            {
                gradeDao.UpdateGrade(grade);
                LogUser($"Обновлён класс {grade}", new EventArgs());
            }
            catch (Exception e)
            {
                var exception = new Exception($"{e.Message}{Environment.NewLine}Inner Message: {e.InnerException?.Message}{Environment.NewLine}");
                loggerException.Error(exception);
                throw exception;
            }
        }

        public void LoggerException(object sender, EventArgs e)
        {
            loggerException.Error(sender.ToString());
        }

        public void LoggerUser(object sender, EventArgs e)
        {
            loggerUser.Info(sender.ToString()); ;
        }
    }
}
