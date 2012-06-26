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

        Usuario ObtenerPorEmailYGrupo(string email, int idGrupo, SqlConnection conexion);

        Usuario ObtenerPorEmailPassYGrupo(string email, string pass, int idGrupo, SqlConnection conexion);

        List<Usuario> ObtenerListado(SqlConnection conexion);

        List<Usuario> ObtenerUsuariosPorIdGrupo(int idGrupo, SqlConnection conexion, SqlTransaction transaccion = null);

        List<Usuario> ObtenerUsuariosAgrupandoFechaRegistro(int idGrupo, SqlConnection conexion, SqlTransaction transaccion = null);
    }
}
