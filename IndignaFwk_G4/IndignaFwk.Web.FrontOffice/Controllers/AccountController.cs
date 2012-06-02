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
                usuario.Apellido = model.Apellido;
                usuario.Descripcion = model.Descripcion;
                usuario.Email = model.Email;

                //Encripto contraseña para guardar en la base
                usuario.Password = UtilesSeguridad.Encriptar(model.Contraseña);
                usuario.Pregunta = model.PreguntaSecreta;
                usuario.Respuesta = model.RespuestaSecreta;
                usuario.Region = model.RegionGeografica;
                usuario.Grupo = this.site.Grupo;
                //controlar mail que no exista en la base para ese grupo

                //Si el usuario existe te retorna a la web
                if (usuarioUserProcess.ObtenerUsuarioPorEmail(model.Email) == null)
                {
                    usuarioUserProcess.CrearNuevoUsuario(usuario);

                    AddControllerMessage("Usuario registrado correctamente.");
                }
                else
                {
                    ModelState.AddModelError("", "El e-mail seleccionado ya esta siendo utilizado por otro usuario.");
                }
            }

            PopulateViewBag();

            return View(model);
        }    
    }
}
