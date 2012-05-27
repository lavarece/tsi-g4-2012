using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IndignaFwk.Web.FrontOffice.MultiTenant;

namespace IndignaFwk.Web.FrontOffice.Controllers
{
    public class AccountController : Controller
    {
        private IApplicationTenant site;

        public AccountController(IApplicationTenant site)
        {
            this.site = site;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Registro()
        {
            return View();
        }
    }
}
