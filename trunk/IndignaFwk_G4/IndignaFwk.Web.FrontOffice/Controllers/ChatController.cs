using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IndignaFwk.Web.FrontOffice.MultiTenant;

namespace IndignaFwk.Web.FrontOffice.Controllers
{
    public class ChatController : BaseController
    {
        public ChatController(IApplicationTenant site)
        {
            this.site = site;
        }

        protected override void PopulateViewBag()
        {
            base.PopulateViewBag();

            ViewBag.OpcionMenu = "Chat";
        }

        public ActionResult SalaGrupo()
        {
            PopulateViewBag();

            return View();
        }
    }
}
