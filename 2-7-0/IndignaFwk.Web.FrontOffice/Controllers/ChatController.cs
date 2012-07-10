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
            StringBuilder sbContent = new StringBuilder();

            if (ControllerContext.HttpContext.User.Identity.IsAuthenticated)
            {
                CustomIdentity ci = (CustomIdentity)ControllerContext.HttpContext.User.Identity;

                List<Usuario> listadoUsuarios = usuarioUserProcess.ObtenerUsuariosPorIdGrupo(site.Grupo.Id);

                if (listadoUsuarios != null && listadoUsuarios.Count > 0)
                {
                    foreach (Usuario usuario in listadoUsuarios)
                    {
                        if (usuario.Id != ci.Id)
                        {                            
                            string claseDiv = "nombreUsuarioChat " + (usuario.Conectado ? "usuarioOnline" : "usuarioOffline");
                            sbContent.Append("<ul>")
                                     .Append("<li>")
                                     .Append("<div class=\"" + claseDiv + "\">");

                            int msjsNoLeidos = CantidadMsjsNoLeidosUsuario(ci.Id, usuario.Id);
                            if (msjsNoLeidos > 0)
                            {
                                sbContent.Append("<span id=\"notifNoLeidos_" + usuario.Id + "\" class=\"msjsNoLeidos\">" + msjsNoLeidos + "</span>");
                            }

                            sbContent.Append("<a href=\"#\" onclick=\"iniciarConversacion(" + usuario.Id + ")\">" + usuario.NombreCompleto + "</a>")                                     
                                     .Append("</div>")
                                     .Append("</li>")
                                     .Append("</ul>");
                        }
                    }
                }

                // Si no se agrego ningun usuario muestro un msje
                if (sbContent.Length == 0)
                {
                    sbContent.Append("<div class=\"mensajeCargandoChat\">")
                             .Append("No existen usuarios")
                             .Append("</div>");
                }
            }
            else
            {
                sbContent.Append("<div class=\"mensajeCargandoChat\">")
                             .Append("No existen usuarios")
                             .Append("</div>");
            }

            return Content(sbContent.ToString(), "text/html");
        }

        [HttpGet]
        public ActionResult IniciarConversacion()
        {
            return Content(GetConversacionContent(false), "text/html");
        }

        [HttpGet]
        public ActionResult IniciarConversacionEmbed()
        {
            return Content(GetConversacionContent(true), "text/html");
        }

        private string GetConversacionContent(bool isEmbed)
        {
            string idUsuario = Request["idUsuario"];

            StringBuilder sbContent = new StringBuilder();

            if (!String.IsNullOrEmpty(idUsuario))
            {
                int idUsuarioB = Int32.Parse(idUsuario);

                // Obtengo la conversacion
                CustomIdentity ci = (CustomIdentity)ControllerContext.HttpContext.User.Identity;

                Conversacion conversacion = ObtenerConversacion(ci.Id, idUsuarioB, true);

                // Obtengo el usuario
                Usuario usuario = usuarioUserProcess.ObtenerUsuarioPorId(idUsuarioB);

                // Si es embed agrego un div para el jQuery ui.dialog
                if (isEmbed)
                {
                    sbContent.Append("<div id='dialogConversacion_" + idUsuario + "' title='" + usuario.NombreCompleto + "' style='display:none; padding: 0px; overflow: hidden;'>");
                }

                sbContent.Append("<div class=\"wrapperConversacionChat\">");

                // Si no es embed agrego la ventana de conversacion unica
                if (!isEmbed)
                {
                    sbContent.Append("<div class=\"datosUsuarioConversacion\">Conversando con: ")
                             .Append(usuario.NombreCompleto)
                             .Append("</div>");
                }
                         
                sbContent.Append("<div class=\"conversacionPanel\" id=\"txt_conversacion_" + idUsuario + "\">");

                // Agrego los mensajes existentes
                foreach (Mensaje mensaje in conversacion.ListaMensajes)
                {
                    // Al igual que en refrescar conversacion los marco como leidos 
                    // si el remitente fue el otro. Se hace aqui y en referscar para que en ningun 
                    // momento se muestre la notificacion nuevamente
                    if (mensaje.IdRemitente == idUsuarioB)
                    {
                        mensaje.Leido = true;
                    }

                    sbContent.Append((mensaje.IdRemitente == ci.Id ? "<b>Yo: </b>" : "<b>El: </b>"))
                             .Append("<span>").Append(mensaje.Contenido).Append("</span><br/>");
                }

                sbContent.Append("</div>")
                         .Append("</div>")
                         .Append("<div class=\"wrapperMensajeChat\">")
                         .Append("<textarea cols=\"30\" rows=\"30\" id=\"txt_ingresoMsj_" + idUsuario + "\"></textarea>")
                         .Append("<div class=\"boton\">")
                         .Append("<a href=\"#\" onclick=\"enviarMensaje(" + usuario.Id + ")\">Enviar</a>")
                         .Append("</div>")
                         .Append("</div>");

                if (isEmbed)
                {
                    sbContent.Append("</div>");
                }

            }

            return sbContent.ToString();
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

                Conversacion conversacion = ObtenerConversacion(ci.Id, idUsuarioB, true);

                Mensaje mensaje = new Mensaje();

                mensaje.Id = ObtenerSiguienteIdMensaje(conversacion);

                mensaje.IdRemitente = ci.Id;

                mensaje.Contenido = msj;

                mensaje.Leido = false;

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

                Conversacion conversacion = ObtenerConversacion(ci.Id, idUsuarioB, true);

                // Agrego los mensajes existentes
                foreach (Mensaje mensaje in conversacion.ListaMensajes)
                {
                    // Si el remitente fue el otro se marca como leido el mensaje,  
                    // se hace aqui tambien ya que si estoy en la conversacion no quiero
                    // se muestre la notificacion nuevamente
                    if (mensaje.IdRemitente == idUsuarioB)
                    {
                        mensaje.Leido = true; 
                    }
                    
                    sbContent.Append((mensaje.IdRemitente == ci.Id ? "<b>Yo: </b>" : "<b>El: </b>"))
                             .Append("<span>").Append(mensaje.Contenido).Append("</span><br/>");
                }
            }

            return Content(sbContent.ToString(), "text/html");
        }

        // Recupera los mensajes no leidos para la conversacion idUsuarioA:idUsuarioB
        // donde el remitente sea el usuario B
        private int CantidadMsjsNoLeidosUsuario(int idUsuarioA, int idUsuarioB)
        {
            int count = 0;

            Conversacion conversacion = ObtenerConversacion(idUsuarioA, idUsuarioB, false);

            if (conversacion != null)
            {
                foreach (Mensaje msj in conversacion.ListaMensajes)
                {
                    if (msj.IdRemitente == idUsuarioB && msj.Leido == false)
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        private Conversacion ObtenerConversacion(int idUsuarioA, int idUsuarioB, bool autoCrear)
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

            if (autoCrear)
            {
                // Si la conversacion no existe la creo
                Conversacion nuevaConv = new Conversacion();

                nuevaConv.IdGrupo = site.Grupo.Id;

                nuevaConv.IdUsuarioA = idUsuarioA;

                nuevaConv.IdUsuarioB = idUsuarioB;

                listaConversaciones.Add(nuevaConv);

                return nuevaConv;
            }
            else
            {
                return null;
            }
            
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
