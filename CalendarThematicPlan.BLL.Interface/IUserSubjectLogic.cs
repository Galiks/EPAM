using CalendarThematicPlan.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarThematicPlan.BLL.Interface
{
    public interface IUserSubjectLogic
    {
        int? AddUserSubject(string idSubject, string idUser);
        UserSubject GetUserSubjectByid(string id);
        IEnumerable<UserSubject> GetUserSubjects();
        void UpdateUserSubjects(string id, string idSubject, string idUser);
        void DeleteUserSubject(string id);
    }
}
