using CalendarThematicPlan.Entity;
using System;
using System.Collections.Generic;

namespace CalendarThematicPlan.BLL.Interface
{
    public interface IGradeLogic
    {
        event EventHandler LogException;
        event EventHandler LogUser;
        int? AddGrade(string number, string letter, string kidsInClass);
        Grade GetGradeById(string id);
        IEnumerable<Grade> GetGrades();
        void UpdateGrade(string id, string number, string letter, string kidsInClass);
        void DeleteGrade(string id);
        void LoggerException(object sender, EventArgs e);
        void LoggerUser(object sender, EventArgs e);
    }
}
