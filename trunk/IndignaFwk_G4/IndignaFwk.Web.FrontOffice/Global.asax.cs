using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Runtime.Caching;
using StructureMap;
using System.Web.Security;
using System.Security.Principal;
using IndignaFwk.Web.FrontOffice.MultiTenant;
using IndignaFwk.Web.FrontOffice.Util;
using IndignaFwk.Common.Entities;
using IndignaFwk.UI.Process;

namespace IndignaFwk.Web.FrontOffice
{    
    public class WebFrontOffice : System.Web.HttpApplication
    {
        private UsuarioUserProcess usuarioUserProcess = new UsuarioUserProcess();

        protected void Application_Start()
        {
            // Default            
            RegisterRoutes(RouteTable.Routes);

            // Multi tenant support            
            ControllerBuilder.Current.SetControllerFactory(new ContainerControllerFactory(new TenantContainerResolver()));
        }

        protected void Application_PostAuthenticateRequest()
        {            
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];

            if (authCookie != null)
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);

                CustomIdentity identity = new CustomIdentity(authTicket.Name, authTicket.UserData);

                GenericPrincipal newUser = new GenericPrincipal(identity, new string[] { });

                Context.User = newUser;
            }
        }

        protected void Session_Start()
        {
            Console.Write("Inicio session");
        }

        protected void Session_End()
        {
            object oIdUsuario =  Session["KEY_ID_USUARIO_LOGUEADO"];

            if (oIdUsuario != null)
            {
                int idUsuario = (int) oIdUsuario;

                Usuario usuario = usuarioUserProcess.ObtenerUsuarioPorId(idUsuario);

                usuario.Conectado = false;

                usuarioUserProcess.EditarUsuario(usuario);
            }
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