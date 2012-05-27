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
        [Required]
        [Display(Name = "Título:")]
        public string Titulo { get; set; }

        [Required]
        [Display(Name = "Descripción:")]
        public string Descripcion { get; set; }

        [Required]
        [Display(Name = "Quorum:")]
        public string Quorum { get; set; }

        [Required]
        [Display(Name = "Temática:")]
        public string Tematica { get; set; }
    }
}