using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.Business.Entities;

namespace IndignaFwk.Persistence.DataAccess
{
    public interface IConvocatoriaADO
    {
        long crear(Convocatoria convocatoria);

        void editar(Convocatoria convocatoria);

        void eliminar(long id);

        Contenido obtener(long id);

        List<Contenido> obtenerListado();
    }
}
