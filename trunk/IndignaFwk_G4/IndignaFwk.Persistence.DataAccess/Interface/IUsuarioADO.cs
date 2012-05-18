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
        public int Crear(Usuario usuario, SqlConnection conexion, SqlTransaction transaccion);

        public void Editar(Usuario usuario, SqlConnection conexion, SqlTransaction transaccion);

        void Eliminar(int id, SqlConnection conexion, SqlTransaction transaccion);

        public Usuario Obtener(int id, SqlConnection conexion);

        List<Usuario> ObtenerListado(SqlConnection conexion);
    }
}
