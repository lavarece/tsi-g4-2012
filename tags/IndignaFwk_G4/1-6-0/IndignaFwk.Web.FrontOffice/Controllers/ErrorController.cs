using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IndignaFwk.UI.Process;
using IndignaFwk.Common.Entities;
using IndignaFwk.Web.FrontOffice.MultiTenant;

namespace IndignaFwk.Web.FrontOffice.Controllers
{
    public class ErrorController : Controller
    {
        private Exception exception;

        private GrupoUserProcess grupoUserProcess = UserProcessFactory.Instance.GrupoUserProcess;

        public ErrorController(Exception exception)
        {
            this.exception = exception;
        }
        
        public ActionResult Index()
        {
            ViewBag.TipoError = this.exception.GetType().ToString();

            ViewBag.MensajeError = this.exception.Message;

            if(this.exception.GetType().ToString().Equals(new TenantNotFoundException().GetType().ToString()))
            {
                List<Grupo> listadoGrupos = grupoUserProcess.ObtenerListadoGrupos();

                ViewBag.ListadoGrupos = listadoGrupos;
            }

            this.exception = null;

            return View("~/Views/Shared/Error.cshtml");
        }

    }
}
