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

        public ErrorController(Exception e)
        {
            this.exception = e;
        }

        public ActionResult Index()
        {
            ViewBag.MensajeError = exception.Message;

            return View();
        }

    }
}
