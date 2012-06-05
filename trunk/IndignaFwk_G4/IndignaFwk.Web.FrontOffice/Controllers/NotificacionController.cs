using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IndignaFwk.Web.FrontOffice.MultiTenant;
using IndignaFwk.UI.Process;
using IndignaFwk.Web.FrontOffice.Util;
using IndignaFwk.Common.Entities;

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

            if (User.Identity.IsAuthenticated)
            {
                CustomIdentity ci = (CustomIdentity)ControllerContext.HttpContext.User.Identity;

                ViewBag.ListadoNotificacionesUsuario = usuarioUserProcess.ObtenerListadoNotificacionesPorUsuario(ci.Id);
            }

            ViewBag.OpcionMenu = "Notificacion";
        }

        public ActionResult Listado()
        {
            PopulateViewBag();

            return View();
        }

        [HttpPost]
        public ActionResult MarcarLeida()
        {
            string seleccionadas = Request["notificacionesSel"];

            if (!String.IsNullOrEmpty(seleccionadas))
            {
                string[] arrSelec = seleccionadas.Split(',');

                foreach (string idNotif in arrSelec)
                {
                    Notificacion notificacion = usuarioUserProcess.ObtenerNotificacionPorId(Int32.Parse(idNotif));

                    notificacion.Visto = true;

                    usuarioUserProcess.EditarNotificacion(notificacion);
                }
            }

            PopulateViewBag();

            return View("Listado");
        }

        [HttpPost]
        public ActionResult MarcarNoLeida()
        {
            string seleccionadas = Request["notificacionesSel"];

            if (!String.IsNullOrEmpty(seleccionadas))
            {
                string[] arrSelec = seleccionadas.Split(',');

                foreach (string idNotif in arrSelec)
                {
                    Notificacion notificacion = usuarioUserProcess.ObtenerNotificacionPorId(Int32.Parse(idNotif));

                    notificacion.Visto = false;

                    usuarioUserProcess.EditarNotificacion(notificacion);
                }
            }

            PopulateViewBag();

            return View("Listado");
        }

        [HttpPost]
        public ActionResult Eliminar()
        {
            string seleccionadas = Request["notificacionesSel"];

            if (!String.IsNullOrEmpty(seleccionadas))
            {
                string[] arrSelec = seleccionadas.Split(',');

                foreach (string idNotif in arrSelec)
                {
                    usuarioUserProcess.EliminarNotificacion(Int32.Parse(idNotif));
                }
            }

            PopulateViewBag();

            return View("Listado");
        }
    }
}
