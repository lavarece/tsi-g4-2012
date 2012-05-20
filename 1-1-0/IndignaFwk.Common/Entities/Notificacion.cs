using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndignaFwk.Common.Entities
{
    public class Notificacion
    {
        public Int32 Id { get; set; }

        private String Contenido { get; set; }

        public bool Visto { get; set; }

        public Convocatoria Convocatoria { get; set; }

        public Usuario Usuario { get; set; }

    }
}
