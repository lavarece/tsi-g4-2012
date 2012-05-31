using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IndignaFwk.Web.FrontOffice.MultiTenant;

namespace IndignaFwk.Web.FrontOffice.Controllers
{
    public class NotificacionController : Controller
    {
        private IApplicationTenant site;

        public NotificacionController(IApplicationTenant site)
        {
            this.site = site;
        }

        private void PopulateViewBag()
        {
            ViewBag.GrupoSite = site.Grupo;
        }

        public ActionResult Listado()
        {
            PopulateViewBag();

            return View();
        }

    }
}
