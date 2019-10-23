using CalendarThematicPlan.Entity;
using System;
using System.Collections.Generic;

namespace CalendarThematicPlan.BLL.Interface
{
    public interface IUserLogic
    {
        event EventHandler LogException;
        event EventHandler LogUser;
        int? AddUser(string firstName, string lastName, string patronymic, string email, string password, string role, string position, byte[] userPhoto);
        User GetUserById(string id);
        User GetUserByEmail(string email);
        IEnumerable<User> GetUsers();
        void UpdateUser(string id, string firstName, string lastName, string patronymic, string email, string password, string role, string position, byte[] userPhoto);
        void DeleteUser(string id);
        string EncryptionPassword(string password);
        IEnumerable<User> GetUsersByWord(string word);
        IEnumerable<User> GetUsersBySubject(string id);
        void LoggerException(object sender, EventArgs e);
        void LoggerUser(object sender, EventArgs e);
        bool Authentication(string email, string password);
    }
}
