using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.Common.Entities;

namespace IndignaFwk.Persistence.DataAccess
{
    public interface IAsistenciaConvocatoriaADO
    {
        Int32 Crear(AsistenciaConvocatoria asistenciaConvocatoria);

        void Editar(AsistenciaConvocatoria asistenciaConvocatoria);

        void Eliminar(long id);

        AsistenciaConvocatoria Obtener(long id);

        List<AsistenciaConvocatoria> ObtenerListado();
    }
}
