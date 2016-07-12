using System.Web.Mvc;

namespace WMS.Web.Controllers
{
    public class AccoutController : Controller
    {
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Logout()
        {
            return View();
        }
    }
}
