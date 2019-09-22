using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAward.DAL.Interface
{
    public interface IAccountDao
    {
        int? AddAccount(Account account);
        void DeleteAccount(int idUser);
        void UpdateAccount(Account account);
        void UpdateLoggerIntoAccount(int idUser, DateTime loggedInto);
        void UpdatePasswordLifetimeAccount(int idUser, DateTime passwordLifetime);
        Account GetAccountByEmail(string email);
        Account GetAccountByIdUser(int idUser);
    }
}
