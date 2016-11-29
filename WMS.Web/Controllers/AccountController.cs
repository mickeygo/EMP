using System.Web.Mvc;
using WMS.Web.Client.Account;
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

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Please input the user name and password.");
                ViewBag.ReturnUrl = returnUrl;
                return View();
            }

            var manager = new AccountManager();
            if (manager.Login(model.UserName, model.Password, model.RememberMe))
                return Url.IsLocalUrl(returnUrl) ? Redirect(returnUrl) : RedirectToHome();

            ModelState.AddModelError("", "The user name and password is not matched.");
            ViewBag.ReturnUrl = returnUrl;

            return View();
        }

        public ActionResult Logout()
        {
            var manager = new AccountManager();
            manager.Logout();

            return RedirectToAction("Login");
        }
    }
}
