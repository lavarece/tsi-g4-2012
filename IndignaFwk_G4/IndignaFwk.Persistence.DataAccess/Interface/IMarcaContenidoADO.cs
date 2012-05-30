using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.Common.Entities;
using System.Data.SqlClient;

namespace IndignaFwk.Persistence.DataAccess
{
    public interface IMarcaContenidoADO
    {
        int Crear(MarcaContenido marcaContenido, SqlConnection conexion, SqlTransaction transaccion);

        void Editar(MarcaContenido marcaContenido, SqlConnection conexion, SqlTransaction transaccion);

        void Eliminar(int id, SqlConnection conexion, SqlTransaction transaccion);

        MarcaContenido Obtener(int id, SqlConnection conexion);

        MarcaContenido ObtenerPorUsuarioYContenido(int idUsuario, int idContenido, SqlConnection conexion);

        List<MarcaContenido> ObtenerListado(SqlConnection conexion);
    }
}
