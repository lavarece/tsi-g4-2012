using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;

namespace TemplatesIndignado.Models
{
    public class LoginModel
    {
        [Required]
        [Display(Name = "E-mail:")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña:")]
        public string Contraseña { get; set; }
    }

    public class RegistroModel
    {
        [Required]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Required]
        [Display(Name = "Region geografica")]
        public string RegionGeografica { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El password debe ser mayor a 6 caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Contraseña { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmar contraseña")]
        [Compare("Contraseña", ErrorMessage = "El usuario y contraseña no coinciden.")]
        public string ConfirmarContraseña { get; set; }

        [Required]
        [Display(Name = "Pregunta secreta:")]
        public string PreguntaSecreta { get; set; }

        [Required]
        [Display(Name = "Respuesta secreta:")]
        public string RespuestaSecreta { get; set; }
    }
}