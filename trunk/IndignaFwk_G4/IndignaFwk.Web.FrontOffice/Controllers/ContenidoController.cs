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

        private SistemaUserProcess sistemaUserProcess = UserProcessFactory.Instance.SistemaUserProcess;

        public ContenidoController(IApplicationTenant site)
        {
            this.site = site;
        }

        protected override void PopulateViewBag()
        {
            base.PopulateViewBag();

            ViewBag.OpcionMenu = "Inicio";

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
                if (IsUrlContenidoValida(model.Url))
                {
                    TipoContenidoEnum tipoContenido = ObtenerTipoContenidoUrl(model.Url);

                    string embedUrl = ObtenerEmbedUrlPorTipoContenido(model.Url, tipoContenido);

                    Contenido contenido = new Contenido();

                    contenido.Titulo = model.Titulo;

                    contenido.Comentario = model.Comentario;

                    contenido.Url = embedUrl;

                    contenido.TipoContenido = tipoContenido.Valor;

                    contenido.NivelVisibilidad = model.Visibilidad;

                    contenido.FechaCreacion = DateTime.Now;

                    CustomIdentity ci = (CustomIdentity)ControllerContext.HttpContext.User.Identity;

                    contenido.UsuarioCreacion = new Usuario { Id = ci.Id };

                    contenido.Grupo = site.Grupo;

                    convocatoriaUserProcess.CrearNuevoContenido(contenido);

                    // Limpio el model         
                    AddControllerMessage("Contenido compartido correctamente.");
                }
                else
                {
                    ModelState.AddModelError("", "La url ingresada no es válida.");
                }
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
            // Obtengo la variable de sitema que indica cuantos recursos compartidos se visualizaran
            VariableSistema variableN = sistemaUserProcess.ObtenerVariablePorId(VariableSistema.N);

            List<Contenido> listadoContenidos = convocatoriaUserProcess.ObtenerXContenidosMasRankeadosPorGrupoYVisibilidad(idGrupo, nivelVisibilidad, Int32.Parse(variableN.Valor));

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

        /*
         * Invocado por la vista mediante ajax para chequear si la url es valida de que tipo de 
         * contenido es y mostrar un preview de la misma  
         */
        [HttpGet]
        public ActionResult CheckUrlContenido()
        {
            string urlContenido = Request["urlContenido"];

            if(IsUrlContenidoValida(urlContenido))
            {
                TipoContenidoEnum tipoContenido = ObtenerTipoContenidoUrl(urlContenido);

                string embedUrl = ObtenerEmbedUrlPorTipoContenido(urlContenido, tipoContenido);

                string htmlPreview = "";

                if (tipoContenido.Valor.Equals(TipoContenidoEnum.VIDEO_YOU_TUBE.Valor))
                {
                    htmlPreview = "<iframe src=\"" + embedUrl + "\" wmode=\"transparent\" width=\"305px\" height=\"210px\" onLoad=\"autoResizeIframe(this)\"/>";
                }
                else if (tipoContenido.Valor.Equals(TipoContenidoEnum.IMAGEN.Valor))
                {
                    htmlPreview = "<img src=\"" + embedUrl + "\" width=\"305px\" height=\"210px\"/>";
                }
                else
                {
                    htmlPreview = "<iframe src=\"" + embedUrl + "\" width=\"305px\" height=\"210px\" onLoad=\"autoResizeIframe(this)\"/>"; ;
                }

                return Content("<div>Tipo de contenido: " + tipoContenido.Etiqueta + "</div>" + htmlPreview);                               
            }
            
            return Content("<div style=\"font-weight:bold; color: #FF0000;\">Url no válida para compartir</div>", "text/html");
        }

        /*
         * Verifica si la url del contenido es valida, basicamente si comienza con 'http://'
         */
        private bool IsUrlContenidoValida(string urlContenido)
        {
            if(!urlContenido.StartsWith("http://"))
            {
                return false;
            }

            return true;
        }

        /*
         * Devuelve el tipo de contenido segun la url del contenido
         */
        private TipoContenidoEnum ObtenerTipoContenidoUrl(string urlContenido)
        {
            // Si es un video de youtube
            if(urlContenido.StartsWith("http://www.youtube.com"))
            {
                return TipoContenidoEnum.VIDEO_YOU_TUBE;
            }
            else if(urlContenido.EndsWith(".gif") ||
                    urlContenido.EndsWith(".png") ||
                    urlContenido.EndsWith(".bmp") ||
                    urlContenido.EndsWith(".jpg") ||
                    urlContenido.EndsWith(".jpeg"))
            {
                return TipoContenidoEnum.IMAGEN;
            }
            else
            {
                return TipoContenidoEnum.LINK;
            }
        }

        /*
         * La url de algunos contenidos debe modificarse para embeberse en el sitio, este metodo
         * realiza dicha tarea y devuelve la Url para embeber
         */
        private string ObtenerEmbedUrlPorTipoContenido(string urlContenido, TipoContenidoEnum tipoContenido)
        {
            if (TipoContenidoEnum.VIDEO_YOU_TUBE.Equals(tipoContenido))
            {
                Uri uri = new Uri(urlContenido);

                string[] paramsUri = uri.Query.Replace("?", "").Split('&');
                
                foreach(string param in paramsUri)
                {
                    if(param.StartsWith("v="))
                    {
                        return "http://www.youtube.com/embed/" + param.Substring(2);
                    }
                }

                return "";
            }

            return urlContenido;
        }
    }
}
