using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.Common.Entities;
using System.Data.SqlClient;

namespace IndignaFwk.Persistence.DataAccess
{
    public interface INotificacionADO
    {
        int Crear(Notificacion notificacion, SqlConnection conexion, SqlTransaction transaccion);

        void Editar(Notificacion notificacion, SqlConnection conexion, SqlTransaction transaccion);

        void Eliminar(int id, SqlConnection conexion, SqlTransaction transaccion);

        Notificacion Obtener(int id, SqlConnection conexion);

        List<Notificacion> ObtenerListado(SqlConnection conexion);
    }
}
