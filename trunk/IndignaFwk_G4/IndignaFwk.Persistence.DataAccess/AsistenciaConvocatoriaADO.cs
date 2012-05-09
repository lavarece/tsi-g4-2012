using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.Business.Entities;

namespace IndignaFwk.Persistence.DataAccess
{
    public class AsistenciaConvocatoriaADO : IAsistenciaConvocatoriaADO
    {
        public long crear(AsistenciaConvocatoria asistenciaConvocatoria)
        {
            return 0;
        }

        public void editar(AsistenciaConvocatoria asistenciaConvocatoria)
        {
        }

        public void eliminar(long id)
        {

        }

        public AsistenciaConvocatoria obtener(long id)
        {
            return new AsistenciaConvocatoria();
        }

        List<AsistenciaConvocatoria> obtenerListado()
        {
            return new List<AsistenciaConvocatoria>();
        }
    }
}
