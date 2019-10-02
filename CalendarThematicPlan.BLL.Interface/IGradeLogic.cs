using CalendarThematicPlan.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarThematicPlan.BLL.Interface
{
    public interface IGradeLogic
    {
        int? AddGrade(string number, string letter, string kidsInClass);
        Grade GetGradeById(string id);
        IEnumerable<Grade> GetGrades();
        void UpdateGrade(string id, string number, string letter, string kidsInClass);
        void DeleteGrade(string id);
    }
}
