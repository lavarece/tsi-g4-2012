using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.Common.Entities;
using System.Data.SqlClient;
using System.Data;

namespace IndignaFwk.Persistence.DataAccess
{
    public interface IFuenteExternaGrupoADO
    {
        void Crear(FuenteExternaGrupo fuenteExternaGrupo, SqlConnection conexion, SqlTransaction transaccion);

        void EliminarPorGrupo(int idGrupo, SqlConnection conexion, SqlTransaction transaccion);

        List<FuenteExternaGrupo> ObtenerListadoPorGrupo(int idGrupo, SqlConnection conexion);
    }
}
