using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using DotPlatform.Notifications;

namespace WMS.Web.Controllers
{
    [AllowAnonymous]
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> SignalRTest(string message)
        {
            var notification = new UserNotification
            {
                Id = Guid.NewGuid(),
                UserId = OwnerSession.UserId.GetValueOrDefault(),
                Notification = new Notification { Data = new NotificationData { Properties = { { "msg", message } } } }
            };

            await RealTimeNotifier.SendNotificationsAsync(new UserNotification[] { notification });

            return Json($"OK -- {OwnerSession.UserId}");
        }

        public ActionResult Metronic()
        {
            return View();
        }
    }
}
