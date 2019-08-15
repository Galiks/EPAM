using Ninject;
using UserAward.BLL.Interface;
using UserAward.BLL.Logic;
using UserAward.DAL_Database.DAO;
using UserAward.DAL_File.DAO;
using UserAward.DAL_Interface.Interface;

namespace UserAward.Container
{
    public static class NinjectCommon
    {
        private static readonly IKernel _kernel = new StandardKernel();

        public static IKernel Kernel => _kernel;

        /// <summary>
        /// Registration dependencies
        /// </summary>
        /// <param name="numberOfDAL">1 - Database, 2 - File, 3 - Memory (default)</param>
        public static void Registration(int numberOfDAL = 3)
        {
            #region Database
            if (numberOfDAL == 1)
            {
                _kernel.Bind<IUserDao>().To<UserDaoDatabase>();
                _kernel.Bind<IAwardDao>().To<AwardDaoDatabase>(); 
            }

            if (numberOfDAL == 2)
            {
                _kernel.Bind<IUserDao>().To<UserDaoFile>();
                _kernel.Bind<IAwardDao>().To<AwardDaoFile>(); 
            }

            if (numberOfDAL == 3)
            {

            }
            #endregion


            #region Logic
            _kernel.Bind<IUserLogic>().To<UserLogic>();
            _kernel.Bind<IAwardLogic>().To<AwardLogic>(); 
            #endregion
        }
    }
}
