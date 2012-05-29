using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.Common.Entities;
using System.Data.SqlClient;

namespace IndignaFwk.Persistence.DataAccess
{
    public interface IImagenADO
    {
        int Crear(Imagen imagen, SqlConnection conexion, SqlTransaction transaccion);

        void Editar(Imagen imagen, SqlConnection conexion, SqlTransaction transaccion);

        void Eliminar(int id, SqlConnection conexion, SqlTransaction transaccion);

        Imagen Obtener(int id, SqlConnection conexion);

        List<Imagen> ObtenerListado(SqlConnection conexion);
    }
}
