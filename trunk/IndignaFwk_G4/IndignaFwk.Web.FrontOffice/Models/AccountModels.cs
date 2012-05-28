using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;

namespace IndignaFwk.Web.FrontOffice.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "E-mail:")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña:")]
        public string Contraseña { get; set; }
    }

    public class RegistroModel
    {
        [Required(ErrorMessage="Campo obligatorio")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Region geografica")]
        public string RegionGeografica { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [StringLength(100, ErrorMessage = "El password debe ser mayor a 6 caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Contraseña { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmar contraseña")]
        [Compare("Contraseña", ErrorMessage = "El usuario y contraseña no coinciden.")]
        public string ConfirmarContraseña { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Pregunta secreta:")]
        public string PreguntaSecreta { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Respuesta secreta:")]
        public string RespuestaSecreta { get; set; }
    }
}