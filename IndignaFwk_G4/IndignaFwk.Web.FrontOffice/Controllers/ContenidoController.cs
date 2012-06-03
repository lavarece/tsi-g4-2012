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
    public class ContenidoController : BaseController
    {
        private ConvocatoriaUserProcess convocatoriaUserProcess = UserProcessFactory.Instance.ConvocatoriaUserProcess;

        public ContenidoController(IApplicationTenant site)
        {
            this.site = site;
        }

        protected override void PopulateViewBag()
        {
            base.PopulateViewBag();

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

                CustomIdentity ci = (CustomIdentity) ControllerContext.HttpContext.User.Identity;

                contenido.UsuarioCreacion = new Usuario { Id = ci.Id };

                contenido.Grupo = site.Grupo;

                convocatoriaUserProcess.CrearNuevoContenido(contenido);

                AddControllerMessage("Operación exitosa.");
            }

            PopulateViewBag();

            return View(model);
        }

        [HttpGet]
        public ActionResult MeGustaContenido()
        {
            CustomIdentity ci = (CustomIdentity) ControllerContext.HttpContext.User.Identity;

            int idUsuario = ci.Id;

            int idContenidoMarcar = Int32.Parse(Request["idContenidoMarcar"]);

            // Verifico si existe una marcar entre el contenido y el usuario, si existe la edito si no la creo
            MarcaContenido marcaContenido = convocatoriaUserProcess.ObtenerMarcaContenidoPorUsuarioYContenido(idUsuario, idContenidoMarcar);

            if (marcaContenido != null)
            {
                marcaContenido.TipoMarca = TipoMarcaContenidoEnum.ME_GUSTA.Valor;

                convocatoriaUserProcess.EditarMarcaContenido(marcaContenido);
            }
            else
            {
                marcaContenido = new MarcaContenido();

                marcaContenido.Contenido = new Contenido { Id = idContenidoMarcar };

                marcaContenido.UsuarioMarca = new Usuario { Id = idUsuario };

                marcaContenido.TipoMarca = TipoMarcaContenidoEnum.ME_GUSTA.Valor;

                convocatoriaUserProcess.CrearNuevaMarcaContenido(marcaContenido);
            }

            AddControllerMessage("Gracias por su opinión.");

            // Cargo los contenidos, si el usuario esta autenticado cargo todos (Privados y Publicos) si no solo los privados
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                ViewBag.ListadoContenidos = ObtenerListadoContenidosPorGrupoYVisibilidad(site.Grupo.Id, null, true);
            }
            else
            {
                ViewBag.ListadoContenidos = ObtenerListadoContenidosPorGrupoYVisibilidad(site.Grupo.Id, VisibilidadContenidoEnum.PUBLICO.Valor, false);
            }

            PopulateViewBag();

            return View(Url.Content("~/Views/Home/Index.cshtml"));
        }

        [HttpGet]
        public ActionResult ContenidoInadecuado()
        {
            CustomIdentity ci = (CustomIdentity)ControllerContext.HttpContext.User.Identity;

            int idUsuario = ci.Id;

            int idContenidoMarcar = Int32.Parse(Request["idContenidoMarcar"]);

            // Verifico si existe una marcar entre el contenido y el usuario, si existe la edito si no la creo
            MarcaContenido marcaContenido = convocatoriaUserProcess.ObtenerMarcaContenidoPorUsuarioYContenido(idUsuario, idContenidoMarcar);

            if (marcaContenido != null)
            {
                marcaContenido.TipoMarca = TipoMarcaContenidoEnum.INADECUADO.Valor;

                convocatoriaUserProcess.EditarMarcaContenido(marcaContenido);
            }
            else
            {
                marcaContenido = new MarcaContenido();

                marcaContenido.UsuarioMarca = new Usuario { Id = idUsuario };

                marcaContenido.Contenido = new Contenido { Id = idContenidoMarcar };

                marcaContenido.TipoMarca = TipoMarcaContenidoEnum.INADECUADO.Valor;

                convocatoriaUserProcess.CrearNuevaMarcaContenido(marcaContenido);
            }

            AddControllerMessage("Gracias por su opinión.");

            // Cargo los contenidos, si el usuario esta autenticado cargo todos (Privados y Publicos) si no solo los privados
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                ViewBag.ListadoContenidos = ObtenerListadoContenidosPorGrupoYVisibilidad(site.Grupo.Id, null, true);
            }
            else
            {
                ViewBag.ListadoContenidos = ObtenerListadoContenidosPorGrupoYVisibilidad(site.Grupo.Id, VisibilidadContenidoEnum.PUBLICO.Valor, false);
            }

            PopulateViewBag();

            return View(Url.Content("~/Views/Home/Index.cshtml"));
        }

        private List<Contenido> ObtenerListadoContenidosPorGrupoYVisibilidad(int idGrupo, string nivelVisibilidad, Boolean isAutenticated)
        {
            List<Contenido> listadoContenidos = convocatoriaUserProcess.ObtenerListadoContenidosPorGrupoYVisibilidad(idGrupo, nivelVisibilidad);

            if (isAutenticated)
            {
                CustomIdentity ci = (CustomIdentity)ControllerContext.HttpContext.User.Identity;

                foreach (Contenido c in listadoContenidos)
                {
                    c.MarcaContenidoUsuario = convocatoriaUserProcess.ObtenerMarcaContenidoPorUsuarioYContenido(ci.Id, c.Id);
                }
            }

            return listadoContenidos;
        }
    }
}
