using CalendarThematicPlan.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarThematicPlan.DAL.Interface
{
    public interface IGradeDao
    {
        int? AddGrade(Grade grade);
        Grade GetGradeById(int id);
        IEnumerable<Grade> GetGrades();
        void UpdateGrade(Grade grade);
        void DeleteGrade(int id);
    }
}
