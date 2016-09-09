using System.Web.Mvc;
using WMS.DataTransferObject.Dtos;

namespace WMS.Web.Areas.Admin.Controllers
{
    public class ZoneController : BaseController
    {
        public ActionResult Index()
        {
            return PartialView();
        }

        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ZoneDto model)
        {
            if (!ModelState.IsValid)
            {
                return Json(false, "Input data is invalid.");
            }

            return Json(true);
        }
    }
}
