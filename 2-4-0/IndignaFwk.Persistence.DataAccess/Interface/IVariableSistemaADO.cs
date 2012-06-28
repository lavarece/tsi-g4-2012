using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.Common.Entities;
using System.Data.SqlClient;

namespace IndignaFwk.Persistence.DataAccess
{
    public interface IVariableSistemaADO
    {
        void Crear(VariableSistema variableSistema, SqlConnection conexion, SqlTransaction transaccion);

        void Editar(VariableSistema variableSistema, SqlConnection conexion, SqlTransaction transaccion);

        void Eliminar(int id, SqlConnection conexion, SqlTransaction transaccion);

        VariableSistema Obtener(int id, SqlConnection conexion);

        VariableSistema ObtenerPorNombre(string nombre, SqlConnection conexion);
        
        List<VariableSistema> ObtenerListado(SqlConnection conexion);
    }
}
