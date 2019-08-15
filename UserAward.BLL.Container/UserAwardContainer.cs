using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAward.BLL.Interface;
using UserAward.BLL.Logic;
using UserAward.DAL.DAO;
using UserAward.DAL.Interface;

namespace UserAward.BLL.Container
{
    public static class UserAwardContainer
    {
        public static IUserDao UserDao { get; set; } = new UserDao();
        public static IUserLogic UserLogic { get; set; } = new UserLogic(UserDao);

        public static IAwardDao AwardDao { get; set; } = new AwardDao();
        public static IAwardLogic AwardLogic { get; set; } = new AwardLogic(AwardDao);
    }
}
