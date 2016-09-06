using System.Web.Mvc;
using WMS.Web.Models;

namespace WMS.Web.Controllers
{
    public class AccountController : BaseController
    {
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Please input the user name and password.");
                ViewBag.ReturnUrl = returnUrl;
                return View();
            }

            //return Url.IsLocalUrl(returnUrl) ? Redirect(returnUrl) : this.RedirectToHome();
            ModelState.AddModelError("", "The user name and password is not matched.");
            ViewBag.ReturnUrl = returnUrl;

            return View();
        }

        [HttpPost]
        public ActionResult Logout()
        {
            return RedirectToAction("Login");
        }
    }
}
