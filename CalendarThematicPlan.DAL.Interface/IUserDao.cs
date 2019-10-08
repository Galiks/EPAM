using CalendarThematicPlan.Entity;
using System.Collections.Generic;

namespace CalendarThematicPlan.DAL.Interface
{
    public interface IUserDao
    {
        int? AddUser(User user);
        User GetUserById(int id);
        IEnumerable<User> GetUsers();
        void UpdateUser(User user);
        void DeleteUser(int id);
        User GetUserByEmail(string email);
        IEnumerable<User> GetUsersByWord(string word);
        IEnumerable<User> GetUsersBySubject(int id);
    }
}
