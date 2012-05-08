using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.Business.Entities;

namespace IndignaFwk.Persistence.DataAccess
{
    public interface IContenidoADO
    {
        long crear(Contenido contenido);

        void editar(Contenido contenido);

        void eliminar(long id);

        Contenido obtener(long id);

        List<Contenido> obtenerListado();
    }
}
