using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndignaFwk.Business.Entities
{
    public class MarcaContenido
    {
        public Int32 Id { get; set; }

        private Contenido Contenido { get; set; }

        public TipoMarcaContenido TipoMarca { get; set; }

        public Usuario UsuarioMarca { get; set; }

    }
}
