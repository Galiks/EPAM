using Ninject;
using UserAward.BLL.Interface;
using UserAward.BLL.Logic;
using UserAward.DAL_Database.DAO;
using UserAward.DAL_Interface.Interface;

namespace UserAward.Container
{
    public static class NinjectCommon
    {
        private static readonly IKernel _kernel = new StandardKernel();

        public static IKernel Kernel => _kernel;

        public static void Registration()
        {
            _kernel.Bind<IUserDao>().To<UserDaoDatabase>();
            _kernel.Bind<IUserLogic>().To<UserLogic>();

            _kernel.Bind<IAwardDao>().To<AwardDaoDatabase>();
            _kernel.Bind<IAwardLogic>().To<AwardLogic>();
        }
    }
}
