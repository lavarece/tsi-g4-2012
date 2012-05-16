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

        void Eliminar(Int32 id, SqlConnection conexion);

        Grupo Obtener(Int32 id, SqlConnection conexion);

        List<Grupo> ObtenerListado(SqlConnection conexion);
    }
}
