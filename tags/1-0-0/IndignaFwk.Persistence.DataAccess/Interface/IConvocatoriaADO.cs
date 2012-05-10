using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.Business.Entities;

namespace IndignaFwk.Persistence.DataAccess
{
    public interface IConvocatoriaADO
    {
        Int32 Crear(Convocatoria convocatoria);

        void Editar(Convocatoria convocatoria);

        void Eliminar(long id);

        Contenido Obtener(long id);

        List<Contenido> ObtenerListado();
    }
}
