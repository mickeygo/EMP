using System.Web.Mvc;
using WMS.DataTransferObject.Dtos;

namespace WMS.Web.Areas.Admin.Controllers
{
    public class LocationController : BaseController
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
        public ActionResult Create(LocationDto model)
        {
            return Json(true);
        }
    }
}
