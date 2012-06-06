using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IndignaFwk.Web.FrontOffice.MultiTenant;
using IndignaFwk.UI.Process;
using IndignaFwk.Common.Entities;
using IndignaFwk.Web.FrontOffice.Util;

namespace IndignaFwk.Web.FrontOffice.Controllers
{
    public class ChatController : BaseController
    {
        private UsuarioUserProcess usuarioUserProcess = UserProcessFactory.Instance.UsuarioUserProcess;

        public ChatController(IApplicationTenant site)
        {
            this.site = site;
        }

        protected override void PopulateViewBag()
        {
            base.PopulateViewBag();
                
            ViewBag.OpcionMenu = "Chat";
        }

        public ActionResult SalaChat()
        {
            PopulateViewBag();

            return View();
        }

        [HttpGet]
        public ActionResult CargarListaUsuarios()
        {
            CustomIdentity ci = (CustomIdentity)ControllerContext.HttpContext.User.Identity;

            List<Usuario> listadoUsuarios = usuarioUserProcess.ObtenerUsuariosPorIdGrupo(site.Grupo.Id);

            StringBuilder sbContent = new StringBuilder();

            if (listadoUsuarios != null && listadoUsuarios.Count > 0)
            {
                foreach (Usuario usuario in listadoUsuarios)
                {
                    if (usuario.Id != ci.Id)
                    {
                        string claseDiv = "nombreUsuarioChat " + (usuario.Conectado ? "usuarioOnline" : "usuarioOffline");
                        sbContent.Append("<ul>")
                                 .Append("<li>")
                                 .Append("<div class=\"" + claseDiv + "\">")
                                 .Append("<a href=\"#\" onclick=\"iniciarChat(" + usuario.Id + ")\">" + usuario.NombreCompleto + "</a>")
                                 .Append("</div>")
                                 .Append("</li>")
                                 .Append("</ul>");
                    }
                }
            }
            
            // Si no se agrego ningun usuario muestro un msje
            if(sbContent.Length == 0)
            {
                sbContent.Append("<div class=\"mensajeCargandoChat\">")
                         .Append("No existen usuarios")
                         .Append("</div>");
            }

            return Content(sbContent.ToString(), "text/html");
        }

        [HttpGet]
        public ActionResult IniciarChat()
        {            
            string idUsuario = Request["idUsuario"];

            StringBuilder sbContent = new StringBuilder();

            if (!String.IsNullOrEmpty(idUsuario))
            {
                int idUsuarioB = Int32.Parse(idUsuario);

                // Obtengo la conversacion
                CustomIdentity ci = (CustomIdentity)ControllerContext.HttpContext.User.Identity;

                Conversacion conversacion = ObtenerConversacion(ci.Id, idUsuarioB); 

                // Obtengo el usuario
                Usuario usuario = usuarioUserProcess.ObtenerUsuarioPorId(idUsuarioB);

                sbContent.Append("<div class=\"wrapperConversacionChat\">")
                         .Append("<div class=\"datosUsuarioConversacion\">Conversando con: ")
                         .Append(usuario.NombreCompleto)
                         .Append("</div>")
                         .Append("<div class=\"conversacionPanel\" id=\"txt_conversacion\">");

                // Agrego los mensajes existentes
                foreach(Mensaje mensaje in conversacion.ListaMensajes)
                {
                    sbContent.Append((mensaje.IdRemitente == ci.Id ? "<b>Yo: </b>" : "<b>El: </b>"))
                             .Append("<span>").Append(mensaje.Contenido).Append("</span><br/>");
                }

                sbContent.Append("</div>")
                         .Append("</div>")
                         .Append("<div class=\"wrapperMensajeChat\">")
                         .Append("<textarea cols=\"30\" rows=\"30\" id=\"txt_msj\"></textarea>")
                         .Append("<div class=\"boton\">")
                         .Append("<a href=\"#\" onclick=\"enviarMensaje(" + usuario.Id + ")\">Enviar</a>")
                         .Append("</div>")
                         .Append("</div>");

            }

            return Content(sbContent.ToString(), "text/html");
        }

        [HttpGet]
        public ActionResult EnviarMensaje()
        {
            string idUsuario = Request["idUsuario"];

            string msj = Request["msj"];

            StringBuilder sbContent = new StringBuilder();

            if (!String.IsNullOrEmpty(idUsuario))
            {
                int idUsuarioB = Int32.Parse(idUsuario);

                // Obtengo la conversacion
                CustomIdentity ci = (CustomIdentity)ControllerContext.HttpContext.User.Identity;

                Conversacion conversacion = ObtenerConversacion(ci.Id, idUsuarioB);

                Mensaje mensaje = new Mensaje();

                mensaje.Id = ObtenerSiguienteIdMensaje(conversacion);

                mensaje.IdRemitente = ci.Id;

                mensaje.Contenido = msj;

                conversacion.ListaMensajes.Add(mensaje);

                sbContent.Append((mensaje.IdRemitente == ci.Id ? "<b>Yo: </b>" : "<b>El: </b>"))
                         .Append("<span>").Append(mensaje.Contenido).Append("</span>").Append("<br/>");
            }

            return Content(sbContent.ToString(), "text/html");
        }

        [HttpGet]
        public ActionResult RefrescarConversacion()
        {
            string idUsuario = Request["idUsuario"];

            StringBuilder sbContent = new StringBuilder();

            if (!String.IsNullOrEmpty(idUsuario))
            {
                int idUsuarioB = Int32.Parse(idUsuario);

                // Obtengo la conversacion
                CustomIdentity ci = (CustomIdentity)ControllerContext.HttpContext.User.Identity;

                Conversacion conversacion = ObtenerConversacion(ci.Id, idUsuarioB);

                // Agrego los mensajes existentes
                foreach (Mensaje mensaje in conversacion.ListaMensajes)
                {
                    sbContent.Append((mensaje.IdRemitente == ci.Id ? "<b>Yo: </b>" : "<b>El: </b>"))
                             .Append("<span>").Append(mensaje.Contenido).Append("</span><br/>");
                }
            }

            return Content(sbContent.ToString(), "text/html");
        }

        private Conversacion ObtenerConversacion(int idUsuarioA, int idUsuarioB)
        {
            List<Conversacion> listaConversaciones = null;

            if (HttpContext.Application["ListaConversacionesChat"] == null)
            {
                listaConversaciones = new List<Conversacion>();

                HttpContext.Application["ListaConversacionesChat"] = listaConversaciones;
            }
            else
            {
                listaConversaciones = (List<Conversacion>) HttpContext.Application["ListaConversacionesChat"];

                foreach(Conversacion iterConv in listaConversaciones)
                {
                    if (iterConv.IdGrupo == site.Grupo.Id)
                    {
                        if ((iterConv.IdUsuarioA == idUsuarioA && iterConv.IdUsuarioB == idUsuarioB) ||
                           (iterConv.IdUsuarioA == idUsuarioB && iterConv.IdUsuarioB == idUsuarioA))
                        {
                            return iterConv;
                        }
                    }
                }
            }

            Conversacion nuevaConv = new Conversacion();

            nuevaConv.IdGrupo = site.Grupo.Id;

            nuevaConv.IdUsuarioA = idUsuarioA;

            nuevaConv.IdUsuarioB = idUsuarioB;

            listaConversaciones.Add(nuevaConv);

            return nuevaConv;            
        }

        private int ObtenerSiguienteIdMensaje(Conversacion conversacion)
        {
            int nextId = 0;

            if (conversacion.ListaMensajes != null && conversacion.ListaMensajes.Count > 0)
            {
                foreach (Mensaje mensaje in conversacion.ListaMensajes)
                {
                    if (mensaje.Id > nextId)
                    {
                        nextId = mensaje.Id;
                    }
                }
            }

            return nextId + 1;
        }
    }
}
