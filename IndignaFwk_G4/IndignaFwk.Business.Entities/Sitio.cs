using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndignaFwk.Business.Entities
{
    public class Sitio
    {
        public Int32 Id { get; set; }

        public String Nombre { get; set; }

        public String LogoUrl { get; set; }

        public String Descripcion { get; set; }

        public List<Contenido> ListaContenido { get; set; }

        public Template Template { get; set; }

        public List<Imagen> ListaImagen { get; set; }

        public String Url { get; set; }

    }
}
