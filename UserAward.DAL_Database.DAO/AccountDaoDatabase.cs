using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAward.DAL.Interface;

namespace UserAward.DAL_Database.DAO
{
    public class AccountDaoDatabase : IAccountDao
    {
        public int? AddAccount(Account account)
        {
            throw new NotImplementedException();
        }

        public void DeleteAccount(int idAccount)
        {
            throw new NotImplementedException();
        }

        public Account GetAccountByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public void UpdateAccount(Account account)
        {
            throw new NotImplementedException();
        }

        public void UpdateLoggerIntoAccount(int idUser, DateTime loggerInto)
        {
            throw new NotImplementedException();
        }

        public void UpdatePasswordLifetimeAccount(int idUser, DateTime passwordLifetime)
        {
            throw new NotImplementedException();
        }
    }
}
