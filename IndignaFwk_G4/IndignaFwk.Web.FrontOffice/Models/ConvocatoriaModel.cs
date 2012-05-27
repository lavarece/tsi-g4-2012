using System.ComponentModel.DataAnnotations;
using IndignaFwk.Web.FrontOffice.Models;

namespace IndignaFwk.Web.FrontOffice.Models
{
    public class ConvocatoriaModel
    {
        public int ID;

        [Required]
        [Display(Name = "Titulo:")]
        public string Titulo { get; set; }

        [Display(Name = "Foto")]
        public string Foto { get; set; }

        [Display(Name = "Descripcion:")]
        public string Descripcion { get; set; }

        [Display(Name = "Categoria:")]
        public string Categoria { get; set; }

    }

}
