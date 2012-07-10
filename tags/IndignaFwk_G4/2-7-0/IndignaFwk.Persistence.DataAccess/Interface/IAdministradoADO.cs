using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.Common.Entities;
using System.Data.SqlClient;

namespace IndignaFwk.Persistence.DataAccess
{
    public interface IAdministradoADO
    {
        void Crear(Administrador administrador, SqlConnection conexion, SqlTransaction transaccion);

        void Editar(Administrador administrador, SqlConnection conexion, SqlTransaction transaccion);

        void Eliminar(int id, SqlConnection conexion, SqlTransaction transaccion);

        Administrador Obtener(int id, SqlConnection conexion);

        List<Administrador> ObtenerListado(SqlConnection conexion);

        Administrador ObtenerPorEmailYPass(string email, string pass, SqlConnection conexion);
    }
}
