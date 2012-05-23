using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.Common.Entities;
using IndignaFwk.Common.Util;
using System.Data.SqlClient;
using System.Data;

namespace IndignaFwk.Persistence.DataAccess
{
    public interface ITematicaADO
    {
        int Crear(Tematica tematica, SqlConnection conexion, SqlTransaction transaccion);

        void Editar(Tematica tematica, SqlConnection conexion, SqlTransaction transaccion);
        
        void Eliminar(int id, SqlConnection conexion, SqlTransaction transaccion);        

        Tematica Obtener(int id, SqlConnection conexion);

        List<Tematica> ObtenerListado(SqlConnection conexion);        
    }
}
