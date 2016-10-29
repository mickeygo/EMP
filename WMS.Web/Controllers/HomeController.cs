using System.Web.Mvc;

namespace WMS.Web.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Metronic()
        {
            return View();
        }
    }
}
