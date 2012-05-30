using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IndignaFwk.Web.FrontOffice.MultiTenant;
using IndignaFwk.Web.FrontOffice.Models;
using IndignaFwk.UI.Process;
using IndignaFwk.Common.Entities;
using IndignaFwk.Common.Enumeration;

namespace IndignaFwk.Web.FrontOffice.Controllers
{
    public class HomeController : Controller
    {
        private IApplicationTenant site;

        private GrupoUserProcess grupoUserProcess = UserProcessFactory.Instance.GrupoUserProcess;

        private ConvocatoriaUserProcess convocatoriaUserProcess = UserProcessFactory.Instance.ConvocatoriaUserProcess;

        public HomeController(IApplicationTenant site)
        { 
            this.site = site;
        }

        private void PopulateViewBag()
        {
            ViewBag.GrupoSite = site.Grupo;

            // Cargo los contenidos, si el usuario esta autenticado cargo todos (Privados y Publicos) si no solo los privados
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                ViewBag.ListadoContenidos = convocatoriaUserProcess.ObtenerListadoContenidosPorGrupoYVisibilidad(site.Grupo.Id, null);
            }
            else
            {
                ViewBag.ListadoContenidos = convocatoriaUserProcess.ObtenerListadoContenidosPorGrupoYVisibilidad(site.Grupo.Id, VisibilidadContenidoEnum.PUBLICO.Valor);
            }
        }

        public ActionResult Index()
        {
            PopulateViewBag();

            return View();
        }

    }
}
