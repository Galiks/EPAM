using CalendarThematicPlan.Entity;
using System;
using System.Collections.Generic;

namespace CalendarThematicPlan.BLL.Interface
{
    public interface IUserSubjectLogic
    {
        event EventHandler LogException;
        event EventHandler LogUser;
        int? AddUserSubject(string idSubject, string idUser);
        UserSubject GetUserSubjectByid(string id);
        IEnumerable<UserSubject> GetUserSubjects();
        void UpdateUserSubjects(string id, string idSubject, string idUser);
        void DeleteUserSubject(string id);
        void LoggerException(object sender, EventArgs e);
        void LoggerUser(object sender, EventArgs e);
    }
}
