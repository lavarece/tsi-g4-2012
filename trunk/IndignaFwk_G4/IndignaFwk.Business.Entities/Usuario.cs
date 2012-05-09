using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndignaFwk.Business.Entities
{
    public class Usuario
    {
        public Int32 Id { get; set; }

        private String Email { get; set; }

        public String Nombre { get; set; }

        public String Password { get; set; }

        public String PreguntaSeguridad { get; set; }

        public String RespuestaSeguridad { get; set; }

        public String Region { get; set; }

        public List<Tematica> ListaTematicas { get; set; }
    }
}
