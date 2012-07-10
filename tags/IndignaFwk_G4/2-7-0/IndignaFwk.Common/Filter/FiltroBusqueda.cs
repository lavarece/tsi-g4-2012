using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndignaFwk.Common.Filter
{
    public class FiltroBusqueda
    {
        public int IdGrupo { get; set; }

        public int IdUsuario { get; set; }

        public string Titulo { get; set; }

        public string Descripcion { get; set; }

        public int Quorum { get; set; }

        public string Tematica { get; set; }

        public DateTime? FechaInicio { get; set; }

        public DateTime? FechaFin { get; set; }

        public Boolean Asistire { get; set; }

    }
}
