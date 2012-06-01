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

        private void PopulateViewBag()
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
        public ActionResult MarcarContenidoMeGusta()
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
                marcaContenido.UsuarioMarca = new Usuario { Id = idUsuario };

                marcaContenido.Contenido = new Contenido { Id = idContenidoMarcar };

                marcaContenido.TipoMarca = TipoMarcaContenidoEnum.ME_GUSTA.Valor;

                convocatoriaUserProcess.CrearNuevaMarcaContenido(marcaContenido);
            }

            AddControllerMessage("Gracias por su opinión.");

            PopulateViewBag();
                
            return RedirectToAction("Home", "Index");
        }

        [HttpGet]
        public ActionResult MarcarContenidoInadecuado()
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
                marcaContenido.UsuarioMarca = new Usuario { Id = idUsuario };

                marcaContenido.Contenido = new Contenido { Id = idContenidoMarcar };

                marcaContenido.TipoMarca = TipoMarcaContenidoEnum.INADECUADO.Valor;

                convocatoriaUserProcess.CrearNuevaMarcaContenido(marcaContenido);
            }

            AddControllerMessage("Gracias por su opinión.");

            PopulateViewBag();

            return RedirectToAction("Home", "Index");
        }
    }
}
