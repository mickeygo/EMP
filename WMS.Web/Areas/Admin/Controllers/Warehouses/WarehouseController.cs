using System.Web.Mvc;
using WMS.DataTransferObject.Dtos;
using WMS.Application.Services;
using DotPlatform.Dependency;

namespace WMS.Web.Areas.Admin.Controllers
{
    public class WarehouseController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAll()
        {
            using (var service = IocManager.Instance.Resolve<IWarehouseAppService>())
            {
                var warehouses = service.GetAllWarehouses();
                return JsonEx(warehouses);
            }
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

                    var whs = service.GetAllWarehouses();
                    return Json(true, whs);
                }
            }
            catch
            {
                return Json(false);
            }
        }
    }
}
