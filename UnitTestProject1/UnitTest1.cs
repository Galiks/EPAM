using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using UserAward.BLL.Interface;
using UserAward.BLL.Logic;
using UserAward.Container;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Reawrding()
        {
            NinjectCommon.Registration();

            IUserLogic userLogic = NinjectCommon.Kernel.Get<IUserLogic>();
            IAwardLogic awardLogic = NinjectCommon.Kernel.Get<IAwardLogic>();

            //var result = userLogic.Rewarding("1", 1);

            var result = userLogic.GetUserById(1);

            Console.WriteLine(result);

            Assert.AreEqual(1, 1, 0, "ERROR");
        }
    }
}
