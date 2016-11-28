using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WMS.Web.Areas.Security.Controllers
{
    public class AuthorityController : Controller
    {
        // GET: Security/Authority
        public ActionResult Index()
        {
            return View();
        }
    }
}