using CalendarThematicPlan.BLL.Interface;
using CalendarThematicPlan.DAL.Interface;
using CalendarThematicPlan.Entity;
using CalendarThematicPlan.Validation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CalendarThematicPlan.BLL.Logic
{
    public class GradeLogic : IGradeLogic
    {
        private readonly IGradeDao gradeDao;

        public GradeLogic(IGradeDao gradeDao)
        {
            this.gradeDao = gradeDao;
        }

        public int? AddGrade(string number, string letter, string kidsInClass)
        {
            if (Validator.IsStringsNull(number, letter, kidsInClass))
            {
                throw new ArgumentException("Обязательные поля должны быть заполнены");
            }

            if (!int.TryParse(number, out int realNumber) & realNumber <= 0)
            {
                throw new ArgumentException("Неправильный номер класса");
            }

            if (!int.TryParse(kidsInClass, out int realKidsInClass) & realKidsInClass <= 0)
            {
                throw new ArgumentException("Неправильное количество детей в классе");
            }

            Grade grade = new Grade { Number = realNumber, Letter = letter, KidsInClass = realKidsInClass };

            return gradeDao.AddGrade(grade);
        }

        public void DeleteGrade(string id)
        {
            if (!int.TryParse(id, out int idGrade))
            {
                throw new ArgumentException("Идентификатор класса должен быть числом");
            }

            Grade grade = gradeDao.GetGradeById(idGrade);

            if (grade == null)
            {
                throw new Exception("Класса с таким идентификатором не существует");
            }

            gradeDao.DeleteGrade(idGrade);
        }

        public Grade GetGradeById(string id)
        {
            if (!int.TryParse(id, out int idGrade))
            {
                throw new ArgumentException("Идентификатор класса должен быть числом");
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
                throw new ArgumentException("Идентификатор класса должен быть числом");
            }

            if (!string.IsNullOrWhiteSpace(number) & !int.TryParse(number, out int realNumber) & realNumber <= 0)
            {
                throw new ArgumentException("Неправильный номер класса");
            }

            if (!string.IsNullOrWhiteSpace(kidsInClass) & !int.TryParse(kidsInClass, out int realKidsInClass) & realKidsInClass <= 0)
            {
                throw new ArgumentException("Неправильное количество детей в классе");
            }

            Grade grade;
            if (idGrade == default)
            {
                throw new Exception("Идентификатор класса неправильный");
            }
            else
            {
                grade = gradeDao.GetGradeById(idGrade);
            }

            grade.Number = realNumber == default ? grade.Number : realNumber;
            grade.KidsInClass = realKidsInClass == default ? grade.KidsInClass : realKidsInClass;

            gradeDao.UpdateGrade(grade);
        }
    }
}
