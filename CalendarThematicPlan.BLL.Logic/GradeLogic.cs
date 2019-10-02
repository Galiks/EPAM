using CalendarThematicPlan.BLL.Interface;
using CalendarThematicPlan.DAL.Interface;
using CalendarThematicPlan.Entity;
using CalendarThematicPlan.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            if (!int.TryParse(number, out int realNumber))
            {
                throw new ArgumentException("Номер класса должен быть числом");
            }

            if (!int.TryParse(kidsInClass, out int realKidsInClass))
            {
                throw new ArgumentException("Количество детей в классе должно быть числом");
            }

            //if (!char.TryParse(letter, out char realLetter) & !char.IsLetter(realLetter))
            //{
            //    throw new ArgumentException("Буква класса должна быть символом");
            //}

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
                throw new Exception("Класса с таким номером не существует");
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
            return gradeDao.GetGrades();
        }

        public void UpdateGrade(string id, string number, string letter, string kidsInClass)
        {
            if (Validator.IsStringsNull(id))
            {
                throw new ArgumentException("Обязательные поля должны быть заполнены");
            }

            if (!int.TryParse(id, out int idGrade))
            {
                throw new ArgumentException("Идентификатор класса должен быть числом");
            }

            if (!string.IsNullOrWhiteSpace(number) & !int.TryParse(number, out int realNumber))
            {
                throw new ArgumentException("Номер класса должен быть числом");
            }

            if (!string.IsNullOrWhiteSpace(kidsInClass) & !int.TryParse(kidsInClass, out int realKidsInClass))
            {
                throw new ArgumentException("Количество детей в классе должно быть числом");
            }

            Grade grade = gradeDao.GetGradeById(idGrade);

            grade.Number = realNumber is default(int) ? grade.Number : realNumber;
            grade.KidsInClass = realKidsInClass is default(int) ? grade.KidsInClass : realKidsInClass;

            gradeDao.UpdateGrade(grade);
        }
    }
}
