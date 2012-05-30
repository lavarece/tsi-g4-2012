using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using IndignaFwk.Web.FrontOffice.MultiTenant;
using IndignaFwk.Web.FrontOffice.Models;
using System.Web.Security;
using IndignaFwk.Common.Entities;
using IndignaFwk.UI.Process;

namespace IndignaFwk.Web.FrontOffice.Controllers
{
    public class AccountController : Controller
    {
        private IApplicationTenant site;

        private UsuarioUserProcess usuarioUserProcess = UserProcessFactory.Instance.UsuarioUserProcess;

        public AccountController(IApplicationTenant site)
        {
            this.site = site;
        }

        private void PopulateViewBag()
        {
            ViewBag.GrupoSite = site.Grupo;
        }

        public ActionResult Login()
        {
            PopulateViewBag();

            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                Usuario usuario = usuarioUserProcess.ObtenerUsuarioPorEmailYPass(model.Email, model.Contraseña);

                if (usuario != null && usuario.Grupo.Id.Equals(site.Grupo.Id))
                {
                    string idUsuario = usuario.Id.ToString();

                    string nombreCompleto = usuario.NombreCompleto;

                    FormsAuthentication.SetAuthCookie(nombreCompleto, true);

                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, nombreCompleto, DateTime.Now, DateTime.Now.AddMinutes(30), true, idUsuario);

                    string encTicket = FormsAuthentication.Encrypt(ticket);

                    HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);

                    HttpContext.Response.Cookies.Add(authCookie);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "");
                }
            }

            PopulateViewBag();

            return View(model);
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            PopulateViewBag();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Registro()
        {
            PopulateViewBag();

            return View();
        }

        [HttpPost]
        public ActionResult Registro(RegistroModel model)
        {
            if (ModelState.IsValid)
            {
                Usuario usuario = new Usuario();
                usuario.Nombre = model.Nombre;
                usuario.Descripcion = model.Descripcion;
                usuario.Email = model.Email;
                usuario.Password = model.Contraseña;
                usuario.Pregunta = model.PreguntaSecreta;
                usuario.Respuesta = model.RespuestaSecreta;
                usuario.Region = model.RegionGeografica;
                usuario.Grupo = this.site.Grupo;
                //controlar mail que no exista en la base para ese grupo

                //Si el usuario existe te retorna a la web
                if (usuarioUserProcess.ObtenerUsuarioPorEmail(model.Email) == null)
                {
                    usuarioUserProcess.CrearNuevoUsuario(usuario);

                    PopulateViewBag();

                    return View("DetalleRegistro", model);
                }
                else
                {
                    ModelState.AddModelError("", "El usuario ya existe en el sistema.");
                }
            }

            PopulateViewBag();

            return View(model);
        }

        public ActionResult DetalleRegistro()
        {
            PopulateViewBag();

            return View();
        }
        #region Status Codes
        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "User name already exists. Please enter a different user name.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "A user name for that e-mail address already exists. Please enter a different e-mail address.";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }
        #endregion
    }
}
