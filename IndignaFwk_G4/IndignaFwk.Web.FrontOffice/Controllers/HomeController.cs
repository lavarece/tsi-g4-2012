using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IndignaFwk.Web.FrontOffice.Models;

namespace IndignadoFramework.Controllers
{
    public class HomeController : Controller
    {
        public MarkerRepository _markerRepository = new MarkerRepository();

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to Indigna FrameWork!";

            return View(_markerRepository.GetMarkers());
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
