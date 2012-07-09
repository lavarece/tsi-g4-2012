using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;
using IndignaFwk.Common.Enumeration;

namespace IndignaFwk.Web.FrontOffice.Models
{
    public class ContenidoModel
    {
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Nivel de visibilidad:")]
        public string Visibilidad { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Título:")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Comentario:")]
        public string Comentario { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Url:")]
        public string Url { get; set; }
    }
}