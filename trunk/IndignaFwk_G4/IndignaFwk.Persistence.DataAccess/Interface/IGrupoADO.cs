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
        Int32 Crear(Grupo grupo, SqlConnection conexion);

        void Editar(Grupo grupo, SqlConnection conexion);

        void Eliminar(int id, SqlConnection conexion);

        Grupo Obtener(int id, SqlConnection conexion);

        Grupo ObtenerPorUrl(string url, SqlConnection conexion);

        List<Grupo> ObtenerListado(SqlConnection conexion);
    }
}
