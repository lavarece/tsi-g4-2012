using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IndignaFwk.Web.FrontOffice.MultiTenant;
using IndignaFwk.Web.FrontOffice.Util;
using IndignaFwk.UI.Process;
using IndignaFwk.Common.Entities;
using System.Text;

namespace IndignaFwk.Web.FrontOffice.Controllers
{
    public class BaseController : Controller
    {
        private UsuarioUserProcess usuarioUserProcess = UserProcessFactory.Instance.UsuarioUserProcess;

        private ConvocatoriaUserProcess convocatoriaUserProcess = UserProcessFactory.Instance.ConvocatoriaUserProcess;

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

                // Listado de convocatorias
                List<Convocatoria> listaConvocatorias = convocatoriaUserProcess.ObtenerListadoConvocatoriasPorGrupo(site.Grupo.Id);
                StringBuilder sbDataConvocatorias = new StringBuilder();

                foreach(Convocatoria conv in listaConvocatorias)
                {
                    if(sbDataConvocatorias.Length > 0)
                    {
                        sbDataConvocatorias.Append(";");
                    }

                    sbDataConvocatorias.Append(conv.Id).Append(",")
                                       .Append(conv.Titulo).Append(",")
                                       .Append(conv.Descripcion).Append(",")
                                       .Append(conv.GetLatitud()).Append(",")
                                       .Append(conv.GetLongitud()).Append(",")
                                       .Append(conv.Quorum).Append(",")
                                       .Append(conv.CantidadAsistencias);
                }

                ViewBag.DataConvocatoriasMapaFull = sbDataConvocatorias.ToString();
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
