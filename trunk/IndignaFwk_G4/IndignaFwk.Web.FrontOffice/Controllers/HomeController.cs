using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IndignaFwk.Web.FrontOffice.Models;
using IndignaFwk.Web.FrontOffice.MultiTenant;

namespace IndignadoFramework.Controllers
{
    public class HomeController : Controller
    {
        private IApplicationTenant _site;

        public HomeController(IApplicationTenant site)
        {
            this._site = site;
        }

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.NombreGrupo = _site.Nombre;

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
