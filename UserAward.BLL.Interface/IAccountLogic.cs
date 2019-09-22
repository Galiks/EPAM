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
        int? AddAccount(string email, string password, string role, string createdAt, string idUser);
        void DeleteAccount(string idAccount);
        void UpdateAccount(string email, string password, string role, string createdAt, string loggedInto, string passwordLifetime, bool isBlocked, string idUser);
        void UpdateLoggerIntoAccount(string idUser, string loggerInto);
        void UpdatePasswordLifetimeAccount(string idUser, string passwordLifetime);
        Account GetAccountByEmail(string email);
        Guid EncryptionPassword(string password);
    }
}
