using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.Common.Entities;

namespace IndignaFwk.Persistence.DataAccess
{
    public interface IContenidoADO
    {
        Int32 Crear(Contenido contenido);

        void Editar(Contenido contenido);

        void Eliminar(long id);

        Contenido Obtener(long id);

        List<Contenido> ObtenerListado();
    }
}
