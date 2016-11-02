using System;
using System.Web.Mvc;
using WMS.Application.Services;
using WMS.DataTransferObject.Dtos;

namespace WMS.Web.Areas.Admin.Controllers
{
    public class ZoneController : BaseController
    {
        public ActionResult GetAll(Guid whId)
        {
            using (var service = IocResolver.Resolve<IWarehouseAppService>())
            {
                var zones = service.GetZones(whId);
                return JsonEx(zones);
            }
        }

        public ActionResult Create(Guid whId)
        {
            return PartialView(new ZoneDto { WarehouseId = whId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ZoneDto model)
        {
            if (!ModelState.IsValid)
                return Json(false, "Input data is invalid.");

            try
            {
                using (var service = IocResolver.Resolve<IWarehouseAppService>())
                {
                    service.CreateZone(model);
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
