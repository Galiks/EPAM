using System;
using Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using UserAward.BLL.Logic;
using UserAward.DAL_Interface.Interface;

namespace UserAwardTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            UserAward.Container.NinjectCommon.Registration();

            var userLogic = UserAward.Container.NinjectCommon.Kernel.Get<IUserDao>();

            User user = userLogic.GetUserById(1);

            var result = userLogic.Reawrding(user, 1);

            Assert.IsNotNull(result, "ERROR");
        }
    }
}
