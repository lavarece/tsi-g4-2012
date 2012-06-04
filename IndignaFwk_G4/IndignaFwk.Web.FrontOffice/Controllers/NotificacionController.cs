using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IndignaFwk.Web.FrontOffice.MultiTenant;
using IndignaFwk.UI.Process;
using IndignaFwk.Web.FrontOffice.Util;

namespace IndignaFwk.Web.FrontOffice.Controllers
{
    public class NotificacionController : BaseController
    {
        private UsuarioUserProcess usuarioUserProcess = UserProcessFactory.Instance.UsuarioUserProcess;

        public NotificacionController(IApplicationTenant site)
        {
            this.site = site;
        }

        protected override void PopulateViewBag()
        {
            base.PopulateViewBag();

            ViewBag.OpcionMenu = "Notificacion";
        }

        public ActionResult Listado()
        {
            if (User.Identity.IsAuthenticated)
            {
                CustomIdentity ci = (CustomIdentity) ControllerContext.HttpContext.User.Identity;

                ViewBag.ListadoNotificacionesUsuario = usuarioUserProcess.ObtenerListadoNotificacionesPorUsuario(ci.Id);
            }

            PopulateViewBag();

            return View();
        }

    }
}
