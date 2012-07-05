using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndignaFwk.Common.Entities
{
    public class Mensaje
    {
        public int Id { get; set; }

        public int IdRemitente { get; set; }

        public string Contenido { get; set; }

        public bool Leido { get; set; }
    }
}
