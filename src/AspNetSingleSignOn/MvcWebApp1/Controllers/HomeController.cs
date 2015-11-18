using System.Web;
using System.Web.Mvc;

namespace MvcWebApp1.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SignOut()
        {
            Request.GetOwinContext().Authentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}