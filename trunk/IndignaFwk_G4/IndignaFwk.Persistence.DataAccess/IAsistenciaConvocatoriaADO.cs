using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.Business.Entities;

namespace IndignaFwk.Persistence.DataAccess
{
    public interface IAsistenciaConvocatoriaADO
    {
        long crear(AsistenciaConvocatoria asistenciaConvocatoria);

        void editar(AsistenciaConvocatoria asistenciaConvocatoria);

        void eliminar(long id);

        AsistenciaConvocatoria obtener(long id);

        List<AsistenciaConvocatoria> obtenerListado();
    }
}
