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
using IndignaFwk.Common.Util;
using IndignaFwk.UI.Process;
using IndignaFwk.Web.FrontOffice.Util;
using IndignaFwk.Common.Enumeration;
using System.Security.Principal;

namespace IndignaFwk.Web.FrontOffice.Controllers
{
    public class AccountController : BaseController
    {
        private UsuarioUserProcess usuarioUserProcess = UserProcessFactory.Instance.UsuarioUserProcess;

        public AccountController(IApplicationTenant site)
        {
            this.site = site;
        }

        protected override void PopulateViewBag()
        {
            base.PopulateViewBag();

            ViewBag.ListadoPreguntasSecretas = PreguntaSecretaEnum.ObtenerListado();
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
                //Encripto contraseña para compararla con la encriptada en la base.
                String passEncriptado = UtilesSeguridad.Encriptar(model.Contraseña);

                Usuario usuario = usuarioUserProcess.ObtenerUsuarioPorEmailYPass(model.Email, passEncriptado);

                if (usuario != null && usuario.Grupo.Id.Equals(site.Grupo.Id))
                {
                    string idUsuario = usuario.Id.ToString();

                    string nombreCompleto = usuario.NombreCompleto;

                    FormsAuthentication.SetAuthCookie(nombreCompleto, true);

                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, nombreCompleto, DateTime.Now, DateTime.Now.AddMinutes(30), true, idUsuario);

                    string encTicket = FormsAuthentication.Encrypt(ticket);

                    HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);

                    HttpContext.Response.Cookies.Add(authCookie);

                    // Seteo la propiedad conectado del usuario a true
                    usuario.Conectado = true;

                    usuarioUserProcess.EditarUsuario(usuario);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "El usuario indicado no existe en este grupo.");
                }
            }

            PopulateViewBag();

            return View(model);
        }

        public ActionResult LogOff()
        {
            if (User.Identity.IsAuthenticated)
            {
                // Seteo la propiedad conectado del usuario a false
                CustomIdentity ci = (CustomIdentity) User.Identity;

                Usuario usuario = usuarioUserProcess.ObtenerUsuarioPorId(ci.Id);

                usuario.Conectado = false;

                usuarioUserProcess.EditarUsuario(usuario);

                FormsAuthentication.SignOut();

                PopulateViewBag();
            }

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
                usuario.Apellido = model.Apellido;
                usuario.Descripcion = model.Descripcion;
                usuario.Email = model.Email;

                //Encripto contraseña para guardar en la base
                usuario.Password = UtilesSeguridad.Encriptar(model.Contrasenia);
                usuario.Pregunta = model.PreguntaSecreta;
                usuario.Respuesta = model.RespuestaSecreta;
                usuario.Coordenadas = model.Coordenadas;
                usuario.Grupo = this.site.Grupo;
                //controlar mail que no exista en la base para ese grupo

                //Si el usuario existe te retorna a la web
                if (usuarioUserProcess.ObtenerUsuarioPorEmail(model.Email) == null)
                {
                    usuarioUserProcess.CrearNuevoUsuario(usuario);

                    model.Nombre = "";
                    model.Apellido = "";

                    AddControllerMessage("Usuario registrado correctamente." + 
                                         "<div style=\"float: right; margin-top: 20px;\">" + 
                                         "<a href=\"" + Url.Action("Login", "Account") + "\">Ir a login</a></div>");
                }
                else
                {
                    ModelState.AddModelError("", "El e-mail seleccionado ya esta siendo utilizado por otro usuario.");
                }
            }

            PopulateViewBag();

            return View(model);
        }

        public ActionResult EditarPerfil()
        {
            EditarPerfilModel model = new EditarPerfilModel();

            if (User.Identity.IsAuthenticated)
            {
                CustomIdentity ci = (CustomIdentity)ControllerContext.HttpContext.User.Identity;

                Usuario usuarioLogueado = usuarioUserProcess.ObtenerUsuarioPorId(ci.Id);

                model.Nombre = usuarioLogueado.Nombre;

                model.Apellido = usuarioLogueado.Apellido;

                model.Descripcion = usuarioLogueado.Descripcion;

                model.PreguntaSecreta = usuarioLogueado.Pregunta;

                model.RespuestaSecreta = usuarioLogueado.Respuesta;
            }

            PopulateViewBag();

            return View(model);
        }

        [HttpPost]
        public ActionResult EditarPerfil(EditarPerfilModel model)
        {
            if (ModelState.IsValid)
            {
                if (User.Identity.IsAuthenticated)
                {
                    CustomIdentity ci = (CustomIdentity)ControllerContext.HttpContext.User.Identity;

                    Usuario usuarioLogueado = usuarioUserProcess.ObtenerUsuarioPorId(ci.Id);

                    usuarioLogueado.Nombre = model.Nombre;

                    usuarioLogueado.Apellido = model.Apellido;

                    usuarioLogueado.Descripcion = model.Descripcion;

                    usuarioLogueado.Pregunta = model.PreguntaSecreta;

                    usuarioLogueado.Respuesta = model.RespuestaSecreta;

                    usuarioUserProcess.EditarUsuario(usuarioLogueado);

                    AddControllerMessage("Usuario editado correctamente");

                    // Edito la cookie de login y el custom identity
                    FormsAuthentication.SetAuthCookie(usuarioLogueado.NombreCompleto, true);

                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, usuarioLogueado.NombreCompleto, DateTime.Now, DateTime.Now.AddMinutes(30), true, usuarioLogueado.Id.ToString());

                    string encTicket = FormsAuthentication.Encrypt(ticket);

                    HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);

                    HttpContext.Response.Cookies.Add(authCookie);

                    CustomIdentity newIdentity = new CustomIdentity(usuarioLogueado.NombreCompleto, ci.Id.ToString());

                    GenericPrincipal newUser = new GenericPrincipal(newIdentity, new string[] { });

                    HttpContext.User = newUser;
                }
            }

            PopulateViewBag();

            return View(model);
        }

        [HttpGet]
        public ActionResult CambiarContrasenia()
        {
            if (User.Identity.IsAuthenticated)
            {
                string cActual = Request["cActual"];
                string cNueva = Request["cNueva"];
                string ccNueva = Request["ccNueva"];

                string cActualEnc = UtilesSeguridad.Encriptar(cActual);
                string cNuevaEnc = UtilesSeguridad.Encriptar(cNueva);
                string ccNuevaEnc = UtilesSeguridad.Encriptar(ccNueva);

                CustomIdentity ci = (CustomIdentity)ControllerContext.HttpContext.User.Identity;

                Usuario usuarioLogueado = usuarioUserProcess.ObtenerUsuarioPorId(ci.Id);
               
                if (!usuarioLogueado.Password.Equals(cActualEnc))
                {
                    return Content("La contraseña actual no es correcta.", "text/html");
                }
                else
                {
                    if (cNueva.Length < 6)
                    {
                        return Content("El largo mínimo de la contraseña es de 6 caracteres.", "text/html");
                    }
                    else if (!cNuevaEnc.Equals(ccNuevaEnc))
                    {
                        return Content("Las nuevas contraseñas no cohinciden.", "text/html");
                    }
                    else
                    {
                        usuarioLogueado.Password = cNuevaEnc;

                        usuarioUserProcess.EditarUsuario(usuarioLogueado);

                        return Content("OK", "text/html");
                    }
                }
            }
            
            return Content("Debe autenticarse.", "text/html");
        }
    }
}
