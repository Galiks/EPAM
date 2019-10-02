using CalendarThematicPlan.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarThematicPlan.BLL.Interface
{
    public interface IUserLogic
    {
        int? AddUser(string firstName, string lastName, string patronymic, string email, string password, string role, string position, byte[] userPhoto);
        User GetUserById(string id);
        IEnumerable<User> GetUsers();
        void UpdateUser(string id, string firstName, string lastName, string patronymic, string email, string password, string role, string position, byte[] userPhoto);
        void DeleteUser(string id);
    }
}
