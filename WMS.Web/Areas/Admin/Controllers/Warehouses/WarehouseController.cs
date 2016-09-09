using System.Web.Mvc;
using DotPlatform.Dependency;
using WMS.DataTransferObject.Dtos;
using WMS.Application.Services;

namespace WMS.Web.Areas.Admin.Controllers
{
    public class WarehouseController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WarehouseDto model)
        {
            try
            {
                using (var service = IocManager.Instance.Resolve<IWarehouseAppService>())
                {
                    service.CreateWarehouse(model);
                }

                return Json(true);
            }
            catch (System.Exception)
            {
                return Json(false);
            }
        }
    }
}
