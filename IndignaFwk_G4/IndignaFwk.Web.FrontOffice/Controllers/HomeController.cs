﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IndignaFwk.Web.FrontOffice.MultiTenant;
using IndignaFwk.Web.FrontOffice.Models;
using IndignaFwk.UI.Process;
using IndignaFwk.Common.Entities;
using IndignaFwk.Common.Enumeration;
using IndignaFwk.Web.FrontOffice.Util;

namespace IndignaFwk.Web.FrontOffice.Controllers
{
    public class HomeController : BaseController
    {
        private GrupoUserProcess grupoUserProcess = UserProcessFactory.Instance.GrupoUserProcess;

        private ContenidoUserProcess contenidoUserProcess = UserProcessFactory.Instance.ContenidoUserProcess;

        private SistemaUserProcess sistemaUserProcess = UserProcessFactory.Instance.SistemaUserProcess;

        public HomeController(IApplicationTenant site)
        { 
            this.site = site;
        }

        protected override void PopulateViewBag()
        {
            base.PopulateViewBag();

            ViewBag.OpcionMenu = "Inicio";

            // Cargo los contenidos, si el usuario esta autenticado cargo todos (Privados y Publicos) si no solo los privados
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                ViewBag.ListadoContenidos = ObtenerListadoContenidosPorGrupoYVisibilidad(site.Grupo.Id, null, true);
            }
            else
            {
                ViewBag.ListadoContenidos = ObtenerListadoContenidosPorGrupoYVisibilidad(site.Grupo.Id, VisibilidadContenidoEnum.PUBLICO.Valor, false);
            }
        }

        private List<Contenido> ObtenerListadoContenidosPorGrupoYVisibilidad(int idGrupo, string nivelVisibilidad, Boolean isAutenticated)
        {
            // Obtengo la variable de sitema que indica cuantos recursos compartidos se visualizaran
            VariableSistema variableN = sistemaUserProcess.ObtenerVariablePorId(VariableSistema.N);

            List<Contenido> listadoContenidos = new List<Contenido>();

            if (variableN != null)
            {
                listadoContenidos = contenidoUserProcess.ObtenerXContenidosMasRankeadosPorGrupoYVisibilidad(idGrupo, nivelVisibilidad, Int32.Parse(variableN.Valor));

                if (isAutenticated)
                {
                    CustomIdentity ci = (CustomIdentity)ControllerContext.HttpContext.User.Identity;

                    foreach (Contenido c in listadoContenidos)
                    {
                        c.MarcaContenidoUsuario = contenidoUserProcess.ObtenerMarcaContenidoPorUsuarioYContenido(ci.Id, c.Id);
                    }
                }
            }

            return listadoContenidos;
        }

        public ActionResult Index()
        {
            PopulateViewBag();

            return View();
        }

    }
}
