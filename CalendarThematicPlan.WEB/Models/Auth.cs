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
            return userLogic.Authentication(email, password);
        }
    }
}