using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IndignaFwk.Web.FrontOffice.Util;
using IndignaFwk.Web.FrontOffice.MultiTenant;
using IndignaFwk.Web.FrontOffice.Models;
using IndignaFwk.Common.Enumeration;
using IndignaFwk.UI.Process;
using IndignaFwk.Common.Entities;


namespace IndignaFwk.Web.FrontOffice.Controllers
{
    public class ContenidoController : Controller
    {
        private IApplicationTenant site;

        private ConvocatoriaUserProcess convocatoriaUserProcess = UserProcessFactory.Instance.ConvocatoriaUserProcess;

        public ContenidoController(IApplicationTenant site)
        {
            this.site = site;
        }

        private void PopulateViewBag()
        {
            ViewBag.GrupoSite = site.Grupo;

            ViewBag.ListaTiposContenido = TipoContenidoEnum.ObtenerListado();

            ViewBag.ListaNivelesVisibilidad = VisibilidadContenidoEnum.ObtenerListado();
        }

        public ActionResult Compartir()
        {
            PopulateViewBag();

            return View();
        }

        [HttpPost]
        public ActionResult Compartir(ContenidoModel model)
        {
            if (ModelState.IsValid)
            {
                Contenido contenido = new Contenido();

                contenido.Titulo = model.Titulo;

                contenido.Comentario = model.Comentario;

                contenido.Url = model.Url;

                contenido.NivelVisibilidad = model.Visibilidad;

                contenido.TipoContenido = model.Tipo;

                contenido.FechaCreacion = DateTime.Now;

                CustomIdentity ci = (CustomIdentity)ControllerContext.HttpContext.User.Identity;

                contenido.UsuarioCreacion = new Usuario { Id = ci.Id };

                convocatoriaUserProcess.CrearNuevoContenido(contenido);
            }

            PopulateViewBag();

            return View(model);
        }
    }
}
