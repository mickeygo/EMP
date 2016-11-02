using System;
using System.Web.Mvc;
using WMS.Application.Services;
using WMS.DataTransferObject.Dtos;

namespace WMS.Web.Areas.Admin.Controllers
{
    public class ShelfController : BaseController
    {
        public ActionResult GetAll(Guid zoneId)
        {
            using (var service = IocResolver.Resolve<IWarehouseAppService>())
            {
                var shelfs = service.GetShelfs(zoneId);
                return JsonEx(shelfs);
            }
        }

        public ActionResult Get(Guid id)
        {
            using (var service = IocResolver.Resolve<IWarehouseAppService>())
            {
                var shelf = service.GetShelf(id);
                return JsonEx(shelf);
            }
        }

        public ActionResult Create(Guid zoneId)
        {
            return PartialView(new ShelfDto { ZoneId = zoneId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ShelfDto model)
        {
            if (!ModelState.IsValid)
                return Json(false, "Input data is invalid.");

            try
            {
                using (var service = IocResolver.Resolve<IWarehouseAppService>())
                {
                    service.CreateShelf(model);
                }

                return Json(true);
            }
            catch
            {
                return Json(false);
            }
        }
    }
}
