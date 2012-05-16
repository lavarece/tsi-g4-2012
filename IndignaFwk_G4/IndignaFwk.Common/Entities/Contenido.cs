using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.Common.Enumeration;

namespace IndignaFwk.Common.Entities
{
    public class Contenido
    {
        public Int32 Id { get; set; }

        public EstadoContenidoEnum EstadoContenido { get; set; }

        public TipoContenidoEnum TipoContenido { get; set; }

        public String Url { get; set; }
    }

}
