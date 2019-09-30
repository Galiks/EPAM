using CalendarThematicPlan.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarThematicPlan.DAL.Interface
{
    public interface IUserDao
    {
        int? AddUser(User grade);
        User GetUserById(int id);
        void UpdateUser(User grade);
        void DeleteUser(int id);
    }
}
