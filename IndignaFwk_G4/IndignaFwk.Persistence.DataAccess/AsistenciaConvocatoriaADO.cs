using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.Common.Entities;

namespace IndignaFwk.Persistence.DataAccess
{
    public class AsistenciaConvocatoriaADO : IAsistenciaConvocatoriaADO
    {
        public Int32 Crear(AsistenciaConvocatoria asistenciaConvocatoria)
        {
            return 0;
        }

        public void Editar(AsistenciaConvocatoria asistenciaConvocatoria)
        {
        }

        public void Eliminar(long id)
        {

        }

        public AsistenciaConvocatoria Obtener(long id)
        {
            return new AsistenciaConvocatoria();
        }

        public List<AsistenciaConvocatoria> ObtenerListado()
        {
            return new List<AsistenciaConvocatoria>();
        }
    }
}
