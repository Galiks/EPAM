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
        int? AddAccount(string email, string password, string role, string idUser);
        bool DeleteAccount(string idAccount);
        bool UpdateAccount(string email, string password, string role, string createdAt, string loggedInto, string passwordLifetime, bool isBlocked, string idUser);
        bool UpdateLoggerIntoAccount(string idUser, string loggerInto);
        bool UpdatePasswordLifetimeAccount(string idUser, string passwordLifetime);
        Account GetAccountByEmail(string email);
        Guid EncryptionPassword(string password);
    }
}
