using CalendarThematicPlan.BLL.Interface;
using CalendarThematicPlan.BLL.Logic;
using CalendarThematicPlan.DAL.DAO;
using CalendarThematicPlan.DAL.Interface;
using Ninject;

namespace CalendarThematicPlan.Container
{
    public static class NinjectCommon
    {
        private static readonly IKernel kernel = new StandardKernel();

        public static IKernel Kernel => kernel;

        public static void Registration()
        {
            kernel.Bind<IGradeDao>().To<GradeDao>();
            kernel.Bind<IScheduleDao>().To<ScheduleDao>();
            kernel.Bind<ISubjectDao>().To<SubjectDao>();
            kernel.Bind<IUserDao>().To<UserDao>();
            kernel.Bind<IUserSubjectDao>().To<UserSubjectDao>();

            kernel.Bind<IGradeLogic>().To<GradeLogic>();
            kernel.Bind<IScheduleLogic>().To<ScheduleLogic>();
            kernel.Bind<ISubjectLogic>().To<SubjectLogic>();
            kernel.Bind<IUserLogic>().To<UserLogic>();
            kernel.Bind<IUserSubjectLogic>().To<UserSubjectLogic>();
        }
    }
}
