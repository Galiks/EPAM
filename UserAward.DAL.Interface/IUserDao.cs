using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAward.DAL.Interface
{
    public interface IUserDao
    {
        int AddUser(User user);
        int DeleteUser(int id);
        IEnumerable<User> GetUsers();
        User GetUserById(int id);
        IEnumerable<User> GetUserByLetter(char letter);
        IEnumerable<User> GetUserByWord(string word);
        IEnumerable<User> GetUserByName(string name);
        int UpdateUser(int id, User user);
        int Reawrding(User user, int idAward);
        IDictionary<int, string> GetAwardFromUserAward(int idUser);
    }
}
