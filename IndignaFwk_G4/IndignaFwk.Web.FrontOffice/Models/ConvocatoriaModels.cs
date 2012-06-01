using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;

namespace IndignaFwk.Web.FrontOffice.Models
{
    public class ConvocatoriaModel
    {
        [Required(ErrorMessage="Campo obligatorio")]
        [Display(Name = "Titulo:")]
        public string Titulo { get; set; }

        [Display(Name = "Link foto:")]
        public string LogoUrl { get; set; }

        [Required(ErrorMessage="Campo obligatorio")]
        [Display(Name = "Descripcion:")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage="Campo obligatorio")]
        [Display(Name = "Quorum:")]
        public int Quorum { get; set; }

        [Required(ErrorMessage="Campo obligatorio")]
        [Display(Name = "Ubicación (Lat, Lon):")]
        public string Coordenadas { get; set; }

        [Required(ErrorMessage="Campo obligatorio")]
        [Display(Name = "Comienzo:")]
        public DateTime? FechaInicio{ get; set; }

        [Required(ErrorMessage="Campo obligatorio")]
        [Display(Name = "Fin:")]
        public DateTime? FechaFin { get; set; }
    }

}
