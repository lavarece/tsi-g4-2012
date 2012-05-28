using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;

namespace IndignaFwk.Web.FrontOffice.Models
{
    public class FiltroConvocatoriaModel
    {
        [Required(ErrorMessage="Campo obligatorio")]
        [Display(Name = "Título:")]
        public string Titulo { get; set; }

        [Required(ErrorMessage="Campo obligatorio")]
        [Display(Name = "Descripción:")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage="Campo obligatorio")]
        [Display(Name = "Quorum:")]
        public string Quorum { get; set; }

        [Required(ErrorMessage="Campo obligatorio")]
        [Display(Name = "Temática:")]
        public string Tematica { get; set; }

        [Required(ErrorMessage="Campo obligatorio")]
        [Display(Name = "Fecha inicio:")]
        public string FechaInicio { get; set; }

        [Required(ErrorMessage="Campo obligatorio")]
        [Display(Name = "Fecha fin:")]
        public string FechaFin { get; set; }
    }
}