using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using IndignaFwk.Core.MultiTenant;
using System.Runtime.Caching;
using StructureMap;

namespace IndignaFwk.Web.FrontOffice
{    
    public class WebFrontOffice : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Default            
            RegisterRoutes(RouteTable.Routes);

            // Multi tenant support            
            ControllerBuilder.Current.SetControllerFactory(new ContainerControllerFactory(new TenantContainerResolver()));
        }
        
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );
        }
    }
}