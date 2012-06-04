using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using IndignaFwk.Common.Entities;

namespace IndignaFwk.Persistence.DataAccess
{
    public interface IUsuarioADO
    {
        void Crear(Usuario usuario, SqlConnection conexion, SqlTransaction transaccion);
        
        void Editar(Usuario usuario, SqlConnection conexion, SqlTransaction transaccion);

        void Eliminar(int id, SqlConnection conexion, SqlTransaction transaccion);

        Usuario Obtener(int id, SqlConnection conexion);

        Usuario ObtenerPorEmailYPass(string email, string pass, SqlConnection conexion);

        List<Usuario> ObtenerListado(SqlConnection conexion);

        Usuario ObtenerPorEmail(string email, SqlConnection conexion);

        List<Usuario> ObtenerUsuariosPorIdGrupo(int idGrupo, SqlConnection conexion, SqlTransaction transaccion = null);
    }
}
