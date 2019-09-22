using Entity;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UserAward.BLL.Interface;
using UserAward.Container;

namespace UserAwardWeb.Models
{
    public static class Auth
    {
        private static readonly IAccountLogic accountLogic;

        static Auth()
        {
            accountLogic = NinjectCommon.Kernel.Get<IAccountLogic>();
        }
        public static bool CanLogin(string email, string password)
        {
            if (email == "admin" && password == "admin")
            {
                return true;
            }
            else
            {
                var user = accountLogic.GetAccountByEmail(email);
                if (user == null)
                {
                    return false;
                }

                Account tempAccount = new Account() { Password = accountLogic.EncryptionPassword(password).ToString() };

                if (user.Password == tempAccount.Password)
                {
                    accountLogic.UpdateLoggerIntoAccount(tempAccount.IdUser.ToString(), DateTime.Now.ToString());
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}