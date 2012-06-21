using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.Common.Entities;
using System.Data.SqlClient;
using IndignaFwk.Common.Filter;

namespace IndignaFwk.Persistence.DataAccess
{
    public interface IConvocatoriaADO
    {
        void Crear(Convocatoria convocatoria, SqlConnection conexion, SqlTransaction transaccion);

        void Editar(Convocatoria convocatoria, SqlConnection conexion, SqlTransaction transaccion);

        void Eliminar(int id, SqlConnection conexion, SqlTransaction transaccion);

        Convocatoria Obtener(int id, SqlConnection conexion);

        List<Convocatoria> ObtenerListado(SqlConnection conexion);

        List<Convocatoria> ObtenerConvocatoriasPorFiltro(FiltroBusqueda filtroBusqueda, SqlConnection conexion);

        List<Convocatoria> ObtenerListadoPorGrupo(SqlConnection conexion, int idGrupo);
    }
}
