using System;
using System.Web.Mvc;
using WMS.Application.Services;
using WMS.DataTransferObject.Dtos;
using DotPlatform.Dependency;

namespace WMS.Web.Areas.Admin.Controllers
{
    public class ZoneController : BaseController
    {
        public ActionResult Index(Guid id)
        {
            using (var service = IocManager.Instance.Resolve<IWarehouseAppService>())
            {
                var zones = service.GetZones(id);
                return PartialView(zones);
            }
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
