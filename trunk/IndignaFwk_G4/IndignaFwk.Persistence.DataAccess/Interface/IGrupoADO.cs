using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.Common.Entities;
using System.Data.SqlClient;

namespace IndignaFwk.Persistence.DataAccess
{
    public interface IGrupoADO
    {
        void Crear(Grupo grupo, SqlConnection conexion, SqlTransaction transaccion);

        void Editar(Grupo grupo, SqlConnection conexion, SqlTransaction transaccion);

        void Eliminar(int id, SqlConnection conexion, SqlTransaction transaccion);

        Grupo Obtener(int id, SqlConnection conexion);

        Grupo ObtenerPorUrl(string url, SqlConnection conexion);

        List<Grupo> ObtenerListado(SqlConnection conexion);
    }
}
