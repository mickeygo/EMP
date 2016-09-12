using System;
using System.Web.Mvc;
using WMS.Application.Services;
using WMS.DataTransferObject.Dtos;
using DotPlatform.Dependency;

namespace WMS.Web.Areas.Admin.Controllers
{
    public class LocationController : BaseController
    {
        public ActionResult Index(Guid id)
        {
            using (var service = IocManager.Instance.Resolve<IWarehouseAppService>())
            {
                var locations = service.GetLocations(id);
                return PartialView(locations);
            }
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
