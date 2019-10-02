using CalendarThematicPlan.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
