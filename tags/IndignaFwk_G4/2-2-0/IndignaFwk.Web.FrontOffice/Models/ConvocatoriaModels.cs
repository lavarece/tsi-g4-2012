using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;
using IndignaFwk.Web.FrontOffice.Util;

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

    public class FiltroConvocatoriaModel
    {
        [Display(Name = "Título:")]
        public string Titulo { get; set; }

        [Display(Name = "Descripción:")]
        public string Descripcion { get; set; }

        [Display(Name = "Quorum:")]
        public string Quorum { get; set; }

        [Display(Name = "Temática:")]
        public string Tematica { get; set; }

        [Display(Name = "Fecha inicio:")]
        public string FechaInicio { get; set; }

        [Display(Name = "Fecha fin:")]
        public string FechaFin { get; set; }

        [Display(Name = "Mostrar sólo a las que asistiré")]
        public bool Asistire { get; set; }
    }
}
