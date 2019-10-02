using CalendarThematicPlan.BLL.Interface;
using CalendarThematicPlan.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarThematicPlan.BLL.Logic
{
    public class UserLogic : IUserLogic
    {
        public int? AddUser(string firstName, string lastName, string patronymic, string email, string password, string role, string position, byte[] userPhoto)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(string id)
        {
            throw new NotImplementedException();
        }

        public User GetUserById(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetUsers()
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(string id, string firstName, string lastName, string patronymic, string email, string password, string role, string position, byte[] userPhoto)
        {
            throw new NotImplementedException();
        }
    }
}
