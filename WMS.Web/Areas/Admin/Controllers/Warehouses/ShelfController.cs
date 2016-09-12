using System;
using System.Web.Mvc;
using WMS.Application.Services;
using WMS.DataTransferObject.Dtos;
using DotPlatform.Dependency;

namespace WMS.Web.Areas.Admin.Controllers
{
    public class ShelfController : BaseController
    {
        public ActionResult Index(Guid id)
        {
            using (var service = IocManager.Instance.Resolve<IWarehouseAppService>())
            {
                var shelfs = service.GetShelfs(id);
                return PartialView(shelfs);
            }
        }

        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ShelfDto model)
        {
            return Json(true);
        }
    }
}
