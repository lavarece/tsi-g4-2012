using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IndignaFwk.Web.FrontOffice.MultiTenant;
using IndignaFwk.Web.FrontOffice.Util;
using IndignaFwk.UI.Process;
using IndignaFwk.Common.Entities;

namespace IndignaFwk.Web.FrontOffice.Controllers
{
    public class BaseController : Controller
    {
        private UsuarioUserProcess usuarioUserProcess = UserProcessFactory.Instance.UsuarioUserProcess;

        protected IApplicationTenant site;

        private IList<string> controllerMessages = new List<string>();

        protected virtual void PopulateViewBag()
        {
            if (User.Identity.IsAuthenticated)
            {
                CustomIdentity ci = (CustomIdentity)ControllerContext.HttpContext.User.Identity;

                List<Notificacion> listadoNotificaciones = usuarioUserProcess.ObtenerListadoNotificacionesPorUsuario(ci.Id);

                int notificacionesNoLeidas = 0;

                foreach (Notificacion n in listadoNotificaciones)
                {
                    if (!n.Visto)
                    {
                        notificacionesNoLeidas++;
                    }
                }

                ViewBag.NotificacionesNoLeidas = notificacionesNoLeidas;
            }

            ViewBag.ControllerMessages = controllerMessages;

            ViewBag.GrupoSite = site.Grupo;
        }

        protected void AddControllerMessage(string message)
        {
            controllerMessages.Add(message);
        }
    }
}
