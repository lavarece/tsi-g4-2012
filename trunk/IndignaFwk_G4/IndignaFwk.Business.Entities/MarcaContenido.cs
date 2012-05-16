using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.Common.Enumeration;

namespace IndignaFwk.Business.Entities
{
    public class MarcaContenido
    {
        public Int32 Id { get; set; }

        private Contenido Contenido { get; set; }

        public TipoMarcaContenidoEnum TipoMarca { get; set; }

        public Usuario UsuarioMarca { get; set; }

    }
}
