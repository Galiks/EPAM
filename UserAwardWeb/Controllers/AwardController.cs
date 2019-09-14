using Ninject;
using System.Web;
using System.Web.Mvc;
using UserAward.BLL.Interface;
using UserAward.Container;

namespace UserAwardWeb.Controllers
{
    public class AwardController : Controller
    {
        private readonly IAwardLogic awardLogic;

        public AwardController()
        {
            this.awardLogic = NinjectCommon.Kernel.Get<IAwardLogic>();
        }


        public ActionResult Index()
        {
            var awards = awardLogic.GetAwards();
            return View(awards);
        }


        public ActionResult Create(string title, string description, HttpPostedFileBase awardImage)
        {
            //byte[] image = null;
            //if (awardImage != null)
            //{
            //    image = new byte[awardImage.ContentLength];
            //    awardImage.InputStream.Read(image, 0, awardImage.ContentLength);
            //}

            //awardLogic.AddAward(title, description, image);
            //return RedirectToAction("Index");

            return View();
        }
    }
}