using System.Web.Mvc;
using WMS.DataTransferObject.Dtos;

namespace WMS.Web.Areas.Admin.Controllers
{
    public class WarehouseController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateWarehouse()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateWarehouse(WarehouseDto model)
        {
            return Json(true);
        }

        public ActionResult CreateZone()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateZone(ZoneDto model)
        {
            return Json(true);
        }

        public ActionResult CreateShelf()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateShelf(ShelfDto model)
        {
            return Json(true);
        }

        public ActionResult CreateLocation()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateLocation(LocationDto model)
        {
            return Json(true);
        }
    }
}
