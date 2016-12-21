using System.Threading.Tasks;
using System.Web.Mvc;

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
               var notification = new DotPlatform.Notifications.UserNotification
            {
                Notification = new DotPlatform.Notifications.Notification {
                    Data = new DotPlatform.Notifications.NotificationData { Properties = new System.Collections.Generic.Dictionary<string, object> { { "msg", message } } }
                }
            };

            await RealTimeNotifier.SendNotificationsAsync(new DotPlatform.Notifications.UserNotification[] { notification });

            return Json(message);
        }

        public ActionResult Metronic()
        {
            return View();
        }
    }
}
