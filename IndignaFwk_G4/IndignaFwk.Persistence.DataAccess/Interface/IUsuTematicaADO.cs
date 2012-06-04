using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.Common.Entities;
using System.Data.SqlClient;

namespace IndignaFwk.Persistence.DataAccess
{
    public interface IUsuTematicaADO
    {
        void Crear(UsuTematica usuTem, SqlConnection conexion, SqlTransaction transaccion);

        void Editar(UsuTematica usuTem, SqlConnection conexion, SqlTransaction transaccion);

        void Eliminar(int id, SqlConnection conexion, SqlTransaction transaccion);

        UsuTematica Obtener(int id, SqlConnection conexion);

        List<UsuTematica> ObtenerListado(SqlConnection conexion);
    }
}
