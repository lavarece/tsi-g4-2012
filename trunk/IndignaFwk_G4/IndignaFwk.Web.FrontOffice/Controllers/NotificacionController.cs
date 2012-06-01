using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IndignaFwk.Web.FrontOffice.MultiTenant;

namespace IndignaFwk.Web.FrontOffice.Controllers
{
    public class NotificacionController : BaseController
    {
        public NotificacionController(IApplicationTenant site)
        {
            this.site = site;
        }

        private void PopulateViewBag()
        {
            base.PopulateViewBag();
        }

        public ActionResult Listado()
        {
            PopulateViewBag();

            return View();
        }

    }
}
