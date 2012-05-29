using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IndignaFwk.Web.FrontOffice.MultiTenant;
using IndignaFwk.Web.FrontOffice.Models;
using IndignaFwk.Common.Enumeration;

namespace IndignaFwk.Web.FrontOffice.Controllers
{
    public class ContenidoController : Controller
    {       
        public ActionResult Compartir()
        {
            ContenidoModel contenidoModel = new ContenidoModel();
            contenidoModel.TipoContenidos = TipoContenidoEnum.ObtenerListado();

            return View(contenidoModel);
        }

    }
}
