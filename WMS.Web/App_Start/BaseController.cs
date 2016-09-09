using System.Web.Mvc;
using DotPlatform.Web.Mvc.Controllers;

namespace WMS.Web
{
    /// <summary>
    /// 控制器基类
    /// </summary>
    public class BaseController : DotPlatformController
    {
        #region

        /// <summary>
        /// 重定向到主页
        /// </summary>
        /// <returns></returns>
        protected ActionResult RedirectToHome()
        {
            return RedirectToAction("Index", "Home", new { area = "" }); 
        }

        #endregion
    }
}
