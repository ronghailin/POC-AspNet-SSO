using System.Web;
using System.Web.Mvc;
using Thinktecture.IdentityModel.Mvc;

namespace MvcWebApp1.Controllers
{
    public class HomeController : Controller
    {
        [ResourceAuthorize("Read", "About")]
        public ActionResult About()
        {
            return View();
        }

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult SignOut()
        {
            Request.GetOwinContext().Authentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}