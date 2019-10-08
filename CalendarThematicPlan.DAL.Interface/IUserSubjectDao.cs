using CalendarThematicPlan.Entity;
using System.Collections.Generic;

namespace CalendarThematicPlan.DAL.Interface
{
    public interface IUserSubjectDao
    {
        int? AddUserSubject(UserSubject userSubject);
        UserSubject GetUserSubjectById(int id);
        IEnumerable<UserSubject> GetUserSubjects();
        void UpdateUserSubject(UserSubject userSubject);
        void DeleteUserSubject(int id);
    }
}
