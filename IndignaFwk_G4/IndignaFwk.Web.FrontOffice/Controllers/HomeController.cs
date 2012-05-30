using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IndignaFwk.Web.FrontOffice.MultiTenant;
using IndignaFwk.Web.FrontOffice.Models;
using IndignaFwk.UI.Process;
using IndignaFwk.Common.Entities;

namespace IndignaFwk.Web.FrontOffice.Controllers
{
    public class HomeController : Controller
    {
        private IApplicationTenant site;

        private GrupoUserProcess grupoUserProcess = UserProcessFactory.Instance.GrupoUserProcess;

        public HomeController(IApplicationTenant site)
        { 
            this.site = site;
        }

        private void PopulateViewBag()
        {
            ViewBag.GrupoSite = site.Grupo;
        }

        public ActionResult Index()
        {
            PopulateViewBag();

            return View();
        }

    }
}
