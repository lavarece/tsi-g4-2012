using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IndignaFwk.Web.FrontOffice.MultiTenant;
using IndignaFwk.Web.FrontOffice.Models;
using IndignaFwk.Common.Entities;
using IndignaFwk.Web.FrontOffice.Util;
using IndignaFwk.UI.Process;

namespace IndignaFwk.Web.FrontOffice.Controllers
{
    public class ConvocatoriaController : BaseController
    {
        private ConvocatoriaUserProcess convocatoriaUserProcess = UserProcessFactory.Instance.ConvocatoriaUserProcess;

        public ConvocatoriaController(IApplicationTenant site)
        {
            this.site = site;
        }

        private void PopulateViewBag()
        {
            base.PopulateViewBag();

            if (HttpContext.User.Identity.IsAuthenticated)
            {
                ViewBag.ListadoConvocatoriasGrupo = convocatoriaUserProcess.ObtenerListadoConvocatoriasPorGrupo(site.Grupo.Id);
            }
        }

        public ActionResult Crear()
        {
            PopulateViewBag();

            return View();
        }

        [HttpPost]
        public ActionResult Crear(ConvocatoriaModel model)
        {
            if(ModelState.IsValid)
            {
                Convocatoria convocatoria = new Convocatoria();

                convocatoria.Titulo = model.Titulo;

                convocatoria.Descripcion = model.Descripcion;

                convocatoria.Quorum = model.Quorum;

                convocatoria.Coordenadas = model.Coordenadas;

                convocatoria.LogoUrl = model.LogoUrl;

                convocatoria.FechaInicio = model.FechaInicio;

                convocatoria.FechaFin = model.FechaFin;

                convocatoria.Grupo = site.Grupo;

                CustomIdentity ci = (CustomIdentity)ControllerContext.HttpContext.User.Identity;

                convocatoria.UsuarioCreacion = new Usuario { Id = ci.Id };

                convocatoriaUserProcess.CrearNuevaConvocatoria(convocatoria);

                AddControllerMessage("Convocatoria creada correctamente");
            }

            PopulateViewBag();

            return View();
        }

        public ActionResult Listado()
        {
            PopulateViewBag();

            return View();
        }

        [HttpGet]
        public ActionResult UbicarConvocatoria()
        {
            int idConvocatoriaSeleccionar = Int32.Parse(Request["idConvocatoriaSeleccionar"]);

            Convocatoria convocatoriaSeleccionada = convocatoriaUserProcess.ObtenerConvocatoriaPorId(idConvocatoriaSeleccionar);

            ViewBag.ConvocatoriaSeleccionada = convocatoriaSeleccionada;

            return View();
        }

        [HttpGet]
        public ActionResult AsistirConvocatoria()
        {
            return View();
        }

        [HttpGet]
        public ActionResult NoAsistirConvocatoria()
        {
            return View();
        }

    }
}
