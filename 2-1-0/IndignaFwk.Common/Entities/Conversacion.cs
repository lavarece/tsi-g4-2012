using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndignaFwk.Common.Entities
{
    public class Conversacion
    {
        public Conversacion()
        {
            ListaMensajes = new List<Mensaje>();
        }

        public int IdUsuarioA { get; set; }

        public int IdUsuarioB { get; set; }

        public int IdGrupo { get; set; }

        public IList<Mensaje> ListaMensajes { get; set; }
    }
}
