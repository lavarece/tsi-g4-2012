using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.Common.Entities;
using System.Data.SqlClient;

namespace IndignaFwk.Persistence.DataAccess
{
    public interface IContenidoADO
    {
        int Crear(Contenido contenido, SqlConnection conexion, SqlTransaction transaccion);

        void Editar(Contenido contenido, SqlConnection conexion, SqlTransaction transaccion);

        void Eliminar(int id, SqlConnection conexion, SqlTransaction transaccion);

        Contenido Obtener(int id, SqlConnection conexion);

        List<Contenido> ObtenerListado(SqlConnection conexion);
    }
}
