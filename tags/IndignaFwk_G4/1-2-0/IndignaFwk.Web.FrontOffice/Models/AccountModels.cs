using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;

namespace IndignaFwk.Web.FrontOffice.Models
{

    public class ChangePasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class LogOnModel
    {
        [Required]
        [Display(Name = "Usuario:")]
        public string Usuario { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña:")]
        public string Contraseña { get; set; }

        [Display(Name = "Recordarme?")]
        public bool Recordarme { get; set; }
    }

    public class RegisterModel
    {
        [Required]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required]
        [Display(Name="Apellido")]
        public string Apellido{get;set;}

        [Required]
        [Display(Name = "Region Geografica")]
        public string RegionGeografica { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Correo Electronico")]
        public string Correo { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El password debe ser mayor a 6 caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Contraseña { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Contraseña")]
        [Compare("Contraseña", ErrorMessage = "El usuario y contraseña no coinciden.")]
        public string ConfirmarContraseña { get; set; }

        [Required]
        [Display(Name = "Pregunta Secreta:")]
        public string PreguntaSecreta { get; set; }

        [Required]
        [Display(Name = "Correo Electronico:")]
        public string CorreoFacebook { get; set; }

        [Required]
        [Display(Name = "Contraseña:")]
        public string ContraseñaFacebook { get; set; }
    }
}
