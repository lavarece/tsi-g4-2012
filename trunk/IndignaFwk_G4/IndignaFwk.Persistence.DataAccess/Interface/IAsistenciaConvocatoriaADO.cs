using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.Common.Entities;
using System.Data.SqlClient;

namespace IndignaFwk.Persistence.DataAccess
{
    public interface IAsistenciaConvocatoriaADO
    {
        int Crear(AsistenciaConvocatoria asistenciaC, SqlConnection conexion, SqlTransaction transaccion);

        void Editar(AsistenciaConvocatoria asistenciaC, SqlConnection conexion, SqlTransaction transaccion);

        void Eliminar(int id, SqlConnection conexion, SqlTransaction transaccion);

        AsistenciaConvocatoria Obtener(int id, SqlConnection conexion);

        List<AsistenciaConvocatoria> ObtenerListado(SqlConnection conexion, SqlTransaction transaccion);
    }
}
