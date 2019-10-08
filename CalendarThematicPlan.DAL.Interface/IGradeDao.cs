using CalendarThematicPlan.Entity;
using System.Collections.Generic;

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
