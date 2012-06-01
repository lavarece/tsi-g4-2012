using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IndignaFwk.Web.FrontOffice.MultiTenant;

namespace IndignaFwk.Web.FrontOffice.Controllers
{
    public class BaseController : Controller
    {
        protected IApplicationTenant site;

        private IList<string> controllerMessages = new List<string>();

        protected virtual void PopulateViewBag()
        {
            ViewBag.ControllerMessages = controllerMessages;

            ViewBag.GrupoSite = site.Grupo;
        }

        protected void AddControllerMessage(string message)
        {
            controllerMessages.Add(message);
        }
    }
}
