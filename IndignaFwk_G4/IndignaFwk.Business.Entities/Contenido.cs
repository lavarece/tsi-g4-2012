using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndignaFwk.Business.Entities
{
    public class Contenido
    {
        public Int32 Id { get; set; }

        public EstadoContenido EstadoContenido { get; set; }

        public TipoContenido TipoContenido { get; set; }

        public String Url { get; set; }

}
