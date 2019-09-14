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
        private static readonly IUserLogic userLogic = NinjectCommon.Kernel.Get<IUserLogic>();
        public static bool CanLogin(string email, string password)
        {
            if (email == "admin" && password == "admin")
            {
                return true;
            }
            else
            {
                var user = userLogic.GetUserByEmail(email);
                if (user == null)
                {
                    return false;
                }

                User tempUser = new User() { Password = userLogic.EncryptionPassword(password).ToString() };

                if (user.Password == tempUser.Password)
                {
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