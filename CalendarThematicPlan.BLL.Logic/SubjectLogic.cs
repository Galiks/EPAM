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
    public class SubjectLogic : ISubjectLogic
    {
        private readonly ISubjectDao subjectDao;

        public SubjectLogic(ISubjectDao subjectDao)
        {
            this.subjectDao = subjectDao;
        }

        public int? AddSubject(string name, string hours)
        {
            if (Validator.IsStringsNull(name, hours))
            {
                throw new ArgumentException("Обязательные поля должны быть заполнены");
            }

            if (!int.TryParse(hours, out int realHours))
            {
                throw new ArgumentException("Неправильное количество часов");
            }

            Subject subject = new Subject { Name = name, Hours = realHours };

            return subjectDao.AddSubject(subject);
        }

        public void DeleteSubject(string id)
        {
            if (!int.TryParse(id, out int idSubject))
            {
                throw new ArgumentException("Идентификатор предмета должен быть числом");
            }

            Subject subject = subjectDao.GetSubjectById(idSubject);

            if (subject == null)
            {
                throw new Exception("Предмета с таким идентификатором не существует");
            }

            subjectDao.DeleteSubject(idSubject);
        }

        public Subject GetSubjectById(string id)
        {
            if (!int.TryParse(id, out int idSubject))
            {
                throw new ArgumentException("Идентификатор предмета должен быть числом");
            }

            return subjectDao.GetSubjectById(idSubject);
        }

        public IEnumerable<Subject> GetSubjects()
        {
            return subjectDao.GetSubjects().ToList();
        }

        public void UpdateSubject(string id, string name, string hours)
        {
            if (!int.TryParse(id, out int idSubject))
            {
                throw new ArgumentException("Идентификатор урока должен быть числом");
            }

            if (!string.IsNullOrWhiteSpace(hours) & !int.TryParse(hours, out int realHours))
            {
                throw new ArgumentException("Неправильное количество часов");
            }

            Subject subject;
            if (idSubject == default)
            {
                throw new Exception("Идентификатор урока неправильный");
            }
            else
            {
                subject = subjectDao.GetSubjectById(idSubject);
            }

            subject.Name = string.IsNullOrWhiteSpace(name) ? subject.Name : name;
            subject.Hours = hours == default ? subject.Hours : realHours;

            subjectDao.UpdateSubject(subject);
        }
    }
}
