using System;
using System.Web.Mvc;
using WMS.Application.Services;
using WMS.DataTransferObject.Dtos;

namespace WMS.Web.Areas.Admin.Controllers
{
    public class LocationController : BaseController
    {
        public ActionResult GetAll(Guid shelfId)
        {
            using (var service = IocResolver.Resolve<IWarehouseAppService>())
            {
                var locations = service.GetLocations(shelfId);
                return JsonEx(locations);
            }
        }

        public ActionResult Create(Guid shelfId)
        {
            return PartialView(new LocationDto { ShelfId = shelfId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LocationDto model)
        {
            if (!ModelState.IsValid)
                return Json(false, "Input data is invalid.");

            try
            {
                using (var service = IocResolver.Resolve<IWarehouseAppService>())
                {
                    service.CreateLocation(model);
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
