using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndignaFwk.Common.Entities
{
    public class Usuario
    {
        public int Id { get; set; }

        public String Descripcion { get; set; }

        public bool Conectado { get; set; }

        public String Email { get; set; }

        public String Nombre { get; set; }

        public int IdSitio { get; set; }

        public String Password { get; set; }

        public String PreguntaSeguridad { get; set; }

        public String RespuestaSeguridad { get; set; }

        public String Region { get; set; }

        public List<Tematica> ListaTematicas { get; set; }
    }
}
