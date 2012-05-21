using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IndignaFwk.Web.FrontOffice.Models;
using IndignaFwk.Web.FrontOffice.MultiTenant;
using IndignaFwk.UI.Process;
using IndignaFwk.Common.Entities;

namespace IndignadoFramework.Controllers
{
    public class HomeController : Controller
    {
        private IApplicationTenant site;

        private GrupoUserProcess grupoUserProcess = UserProcessFactory.Instance.GrupoUserProcess;

        public HomeController(IApplicationTenant site)
        {
            this.site = site;
        }

        [HttpGet]
        public ActionResult Index()
        {
            Grupo grupo = grupoUserProcess.ObtenerGrupoPorId(site.Id);

            ViewBag.Grupo = grupo;

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
