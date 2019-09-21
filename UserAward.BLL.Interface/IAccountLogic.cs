using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAward.BLL.Interface
{
    public interface IAccountLogic
    {
        int? AddAccount(string email, string password, string role, string createdAt, DateTime loggedInto, DateTime passwordLifetime, string idUser);
        void DeleteAccount(string idAccount);
        void UpdateAccount(string email, string password, string role, string createdAt, DateTime loggedInto, DateTime passwordLifetime, string idUser);
        void UpdateLoggerIntoAccount(int idUser, DateTime loggerInto);
        void UpdatePasswordLifetimeAccount(int idUser, DateTime passwordLifetime);
        Account GetAccountByEmail(string email);
        Guid EncryptionPassword(string password);
    }
}
