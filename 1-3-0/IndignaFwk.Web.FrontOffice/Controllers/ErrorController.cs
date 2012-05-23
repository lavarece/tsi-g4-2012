using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IndignaFwk.Web.FrontOffice.Controllers
{
    public class ErrorController : Controller
    {
        private Exception exception;

        public ErrorController(Exception exception)
        {
            this.exception = exception;
        }

        public ActionResult Index()
        {
            ViewBag.TipoError = exception.GetType().ToString();

            ViewBag.MensajeError = exception.Message;

            this.exception = null;

            return View("~/Views/Shared/Error.cshtml");
        }

    }
}
