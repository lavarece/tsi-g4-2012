using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.Common.Entities;
using System.Data.SqlClient;

namespace IndignaFwk.Persistence.DataAccess
{
    public interface IConvocatoriaADO
    {
        int Crear(Convocatoria convocatoria, SqlConnection conexion, SqlTransaction transaccion);

        void Editar(Convocatoria convocatoria, SqlConnection conexion, SqlTransaction transaccion);

        void Eliminar(int id, SqlConnection conexion, SqlTransaction transaccion);

        Convocatoria Obtener(int id, SqlConnection conexion);

        List<Convocatoria> ObtenerListado(SqlConnection conexion);
    }
}
