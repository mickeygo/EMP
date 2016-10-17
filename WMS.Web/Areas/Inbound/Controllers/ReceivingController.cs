using System.Web.Mvc;

namespace WMS.Web.Areas.Inbound.Controllers
{
    // 收货
    public class ReceivingController : BaseController
    {
        // GET: Inbound/Receiving
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetMaterials(string order)
        {
            return JsonEx(null);
        }
    }
}