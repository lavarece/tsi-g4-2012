using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IndignaFwk.Web.FrontOffice.MultiTenant;

namespace IndignaFwk.Web.FrontOffice.Controllers
{
    public class HomeController : Controller
    {
        private IApplicationTenant site;

        public HomeController(IApplicationTenant site)
        {
            this.site = site;
        }

        public ActionResult Index()
        {
            return View();
        }

    }
}
