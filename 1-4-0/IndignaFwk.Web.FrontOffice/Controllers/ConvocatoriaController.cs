using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IndignaFwk.Web.FrontOffice.MultiTenant;

namespace IndignaFwk.Web.FrontOffice.Controllers
{
    public class ConvocatoriaController : Controller
    {
        private IApplicationTenant site;

        public ConvocatoriaController(IApplicationTenant site)
        {
            this.site = site;
        }

        public ActionResult Crear()
        {
            return View();
        }

        public ActionResult Listado()
        {
            return View();
        }

    }
}
