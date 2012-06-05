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

        public ActionResult SalaGrupo()
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
            return Content("", "text/html");
        }
    }
}
