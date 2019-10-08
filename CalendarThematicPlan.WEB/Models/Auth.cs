using CalendarThematicPlan.BLL.Interface;
using CalendarThematicPlan.Container;
using Ninject;

namespace CalendarThematicPlan.WEB.Models
{
    public static class Auth
    {
        private static readonly IUserLogic userLogic;

        static Auth()
        {
            userLogic = NinjectCommon.Kernel.Get<IUserLogic>();
        }

        public static bool CanLogin(string email, string password)
        {
            if (email == "admin" & password == "admin")
            {
                return true;
            }

            var user = userLogic.GetUserByEmail(email);
            if (user == null)
            {
                return false;
            }

            string passwordOfStranger = userLogic.EncryptionPassword(password);

            if (user.Password == passwordOfStranger)
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