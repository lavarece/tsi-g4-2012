﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IndignaFwk.Web.FrontOffice.MultiTenant;
using IndignaFwk.Web.FrontOffice.Models;
using IndignaFwk.Common.Entities;
using IndignaFwk.Web.FrontOffice.Util;
using IndignaFwk.UI.Process;
using IndignaFwk.Common.Filter;

namespace IndignaFwk.Web.FrontOffice.Controllers
{
    public class ConvocatoriaController : BaseController
    {
        private ConvocatoriaUserProcess convocatoriaUserProcess = UserProcessFactory.Instance.ConvocatoriaUserProcess;
        
        public ConvocatoriaController(IApplicationTenant site)
        {
            this.site = site;
        }

        protected override void PopulateViewBag()
        {
            base.PopulateViewBag();

            ViewBag.OpcionMenu = "Convocatoria";
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
                // Si la fecha inicla es menor a la fecha actual
                if (DateTime.Compare((DateTime) model.FechaInicio, DateTime.Now) < 0)
                {
                    ModelState.AddModelError("", "La fecha inicio debe ser mayor a la fecha actual");

                    PopulateViewBag();

                    return View(model);
                }

                // Si la fecha final es menor a la fecha inicial
                if (DateTime.Compare((DateTime) model.FechaFin, (DateTime) model.FechaInicio) < 0)
                {
                    ModelState.AddModelError("", "La fecha final debe ser mayor a la fecha inicial");

                    PopulateViewBag();

                    return View(model);
                }

                Convocatoria convocatoria = new Convocatoria();

                convocatoria.Titulo = model.Titulo;

                convocatoria.Descripcion = model.Descripcion;

                convocatoria.Quorum = model.Quorum;

                convocatoria.Coordenadas = model.Coordenadas;

                convocatoria.FechaInicio = model.FechaInicio;

                convocatoria.FechaFin = model.FechaFin;

                convocatoria.Grupo = site.Grupo;

                CustomIdentity ci = (CustomIdentity)ControllerContext.HttpContext.User.Identity;

                convocatoria.UsuarioCreacion = new Usuario { Id = ci.Id };

                convocatoria.Id = convocatoriaUserProcess.CrearNuevaConvocatoria(convocatoria);

                AddControllerMessage("Convocatoria creada correctamente");
            }

            PopulateViewBag();

            return View();
        }

        public ActionResult Listado()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                ViewBag.ListadoConvocatoriasGrupo = BuscarConvocatorias();
            }

            PopulateViewBag();

            return View();
        }

        [HttpGet]
        public ActionResult UbicarConvocatoria()
        {
            CustomIdentity ci = (CustomIdentity)ControllerContext.HttpContext.User.Identity;

            int idUsuario = ci.Id;

            int idConvocatoriaAUbicar = Int32.Parse(Request["idConvocatoriaAUbicar"]);

            Convocatoria convocatoriaSeleccionada = convocatoriaUserProcess.ObtenerConvocatoriaPorId(idConvocatoriaAUbicar);

            convocatoriaSeleccionada.ExisteAsistenciaUsuario = convocatoriaUserProcess.ObtenerAsistenciaConvocatoriaPorUsuarioYConvocatoria(idUsuario, idConvocatoriaAUbicar) != null;

            ViewBag.ConvocatoriaSeleccionada = convocatoriaSeleccionada;

            if (HttpContext.User.Identity.IsAuthenticated)
            {
                ViewBag.ListadoConvocatoriasGrupo = BuscarConvocatorias();
            }

            PopulateViewBag();

            return View("Listado");
        }

        [HttpGet]
        public ActionResult AsistirConvocatoria()
        {
            CustomIdentity ci = (CustomIdentity) ControllerContext.HttpContext.User.Identity;

            int idUsuario = ci.Id;

            int idConvocatoriaSeleccionada = Int32.Parse(Request["idConvocatoriaSeleccionada"]);

            AsistenciaConvocatoria asistenciaConvocatoria = new AsistenciaConvocatoria();

            asistenciaConvocatoria.Usuario = new Usuario { Id = idUsuario };

            asistenciaConvocatoria.Convocatoria = new Convocatoria { Id = idConvocatoriaSeleccionada };

            asistenciaConvocatoria.Id = convocatoriaUserProcess.CrearNuevaAsistenciaConvocatoria(asistenciaConvocatoria);

            AddControllerMessage("Asistencia guardada");

            // Recargo la convocatoria seleccionada para ponerla en el ViewBag
            Convocatoria convocatoriaSeleccionada = convocatoriaUserProcess.ObtenerConvocatoriaPorId(idConvocatoriaSeleccionada);

            convocatoriaSeleccionada.ExisteAsistenciaUsuario = true;

            ViewBag.ConvocatoriaSeleccionada = convocatoriaSeleccionada;

            if (HttpContext.User.Identity.IsAuthenticated)
            {
                ViewBag.ListadoConvocatoriasGrupo = BuscarConvocatorias();
            }

            PopulateViewBag();

            return View("Listado");
        }

        [HttpGet]
        public ActionResult NoAsistirConvocatoria()
        {
            CustomIdentity ci = (CustomIdentity)ControllerContext.HttpContext.User.Identity;

            int idUsuario = ci.Id;

            int idConvocatoriaSeleccionada = Int32.Parse(Request["idConvocatoriaSeleccionada"]);

            AsistenciaConvocatoria asistenciaConvocatoria = convocatoriaUserProcess.ObtenerAsistenciaConvocatoriaPorUsuarioYConvocatoria(idUsuario, idConvocatoriaSeleccionada);

            if (asistenciaConvocatoria != null)
            {
                convocatoriaUserProcess.EliminarAsistenciaConvocatoria(asistenciaConvocatoria.Id);
            }

            AddControllerMessage("Asistencia eliminada");

            // Recargo la convocatoria seleccionada para ponerla en el ViewBag
            Convocatoria convocatoriaSeleccionada = convocatoriaUserProcess.ObtenerConvocatoriaPorId(idConvocatoriaSeleccionada);

            convocatoriaSeleccionada.ExisteAsistenciaUsuario = false;

            ViewBag.ConvocatoriaSeleccionada = convocatoriaSeleccionada;

            if (HttpContext.User.Identity.IsAuthenticated)
            {
                ViewBag.ListadoConvocatoriasGrupo = BuscarConvocatorias();
            }

            PopulateViewBag();

            return View("Listado");
        }

        [HttpPost]
        public ActionResult Filtrar(FiltroConvocatoriaModel model)
        {
            // Armo un filtroBusquedaConvocatorias con la info del model
            FiltroBusqueda filtroBusquedaConvocatoria = new FiltroBusqueda();

            CustomIdentity ci = (CustomIdentity)ControllerContext.HttpContext.User.Identity;

            int idUsuario = ci.Id;

            filtroBusquedaConvocatoria.IdUsuario = idUsuario;
            filtroBusquedaConvocatoria.IdGrupo = site.Grupo.Id;
            filtroBusquedaConvocatoria.Titulo = model.Titulo;
            filtroBusquedaConvocatoria.Tematica = model.Tematica;

            if (model.Quorum != null)
            {
                filtroBusquedaConvocatoria.Quorum = Int32.Parse(model.Quorum);
            }
            else
            {
                filtroBusquedaConvocatoria.Quorum = -1;
            }

            if (model.FechaInicio != null)
            {
                filtroBusquedaConvocatoria.FechaInicio = Convert.ToDateTime(model.FechaInicio);
            }

            if (model.FechaFin != null)
            {
                filtroBusquedaConvocatoria.FechaFin = Convert.ToDateTime(model.FechaFin);
            }

            filtroBusquedaConvocatoria.Descripcion = model.Descripcion;
            filtroBusquedaConvocatoria.Asistire = model.Asistire;

            ViewBag.ListadoConvocatoriasGrupo = BuscarConvocatorias(filtroBusquedaConvocatoria);
            

            PopulateViewBag();

            return View("Listado");
        }

        // Operacion auxiliar para buscar las convocatorias a partir de un filtro de busqueda
        private List<Convocatoria> BuscarConvocatorias(FiltroBusqueda filtroConvocatoria)
        {
            return convocatoriaUserProcess.ObtenerConvocatoriasPorFiltro(filtroConvocatoria);
        }

        private List<Convocatoria> BuscarConvocatorias()
        {
            return convocatoriaUserProcess.ObtenerListadoConvocatoriasPorGrupo(site.Grupo.Id);
        }
    }
}
