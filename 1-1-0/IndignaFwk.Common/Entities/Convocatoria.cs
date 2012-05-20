using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndignaFwk.Common.Entities
{
    public class Convocatoria
    {
        public Int32 Id { get; set; }

        public String Titulo { get; set; }

        public String Descripcion { get; set; }

        public int Quorum { get; set; }

        public String Coordenadas { get; set; }

        public String Logo { get; set; }

        public Tematica Categoria { get; set; }

        public Grupo Grupo { get; set; }

        public Usuario UsuarioCreacion { get; set; }
    }
}
