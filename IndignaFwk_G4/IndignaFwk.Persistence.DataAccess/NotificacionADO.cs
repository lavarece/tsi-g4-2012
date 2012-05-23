using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.Common.Entities;
using System.Data.SqlClient;
using System.Data;
using IndignaFwk.Common.Util;

namespace IndignaFwk.Persistence.DataAccess
{
    public class NotificacionADO : INotificacionADO
    {
        private SqlCommand command;    

        public int Crear(Notificacion notificacion, SqlConnection conexion, SqlTransaction transaccion)
        {
            command = conexion.CreateCommand();

            command.Transaction = transaccion;

            command.Connection = conexion;

            command.CommandText = " insert into Notificacion(Contenido, Visto, FK_Id_Convocatoria, Fk_Id_Usuario) " +
                                  " values(@contenido, @visto, @idConvocatoria, @idUsuario); " +
                                  " select @idGen = SCOPE_IDENTITY() FROM Notificacion; ";

            command.Parameters.AddWithValue("contenido", notificacion.Contenido);

            command.Parameters.AddWithValue("visto", (notificacion.Visto == true ? "1" : "0"));

            command.Parameters.AddWithValue("idConvocatoria", notificacion.Convocatoria.Id);

            command.Parameters.AddWithValue("idUsuario", notificacion.Usuario.Id);

            // indico que la query tiene un parámetro de salida thisId de tipo int
            command.Parameters.Add("@idGen", SqlDbType.Int).Direction = ParameterDirection.Output;

            command.ExecuteScalar();

            // este es el identificador generado
            return (int)command.Parameters["@idGen"].Value;
        }

        public void Editar(Notificacion notificacion, SqlConnection conexion, SqlTransaction transaccion)
        {
            command = conexion.CreateCommand();

            command.Transaction = transaccion;

            command.Connection = conexion;

            command.CommandText = " UPDATE Notificacion SET " +
                                  " Contenido = @contenido, " +
                                  " Visto = @visto" +                                  
                                  " WHERE Id = @id";

            command.Parameters.AddWithValue("id", notificacion.Id);
            command.Parameters.AddWithValue("contenido", notificacion.Contenido);
            command.Parameters.AddWithValue("visto", (notificacion.Visto == true ? "1" : "0"));
            
            command.ExecuteNonQuery();
        }

        public void Eliminar(int id, SqlConnection conexion, SqlTransaction transaccion)
        {
            command = conexion.CreateCommand();

            command.Transaction = transaccion;

            command.Connection = conexion;

            command.CommandText = "DELETE FROM Notificacion WHERE Id = @id";

            command.Parameters.AddWithValue("id", id);

            command.ExecuteNonQuery();
        }

        public Notificacion Obtener(int id, SqlConnection conexion)
        {
            SqlDataReader reader = null;

            try
            {
                command = conexion.CreateCommand();

                command.Connection = conexion;

                command.CommandText = "select * from Notificacion where Id = @id";

                command.Parameters.AddWithValue("id", id);

                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Notificacion notificacion = new Notificacion();

                    notificacion.Id = UtilesBD.GetIntFromReader("id", reader);

                    notificacion.Contenido = UtilesBD.GetStringFromReader("Contenido", reader);

                    notificacion.Visto = ("1".Equals(UtilesBD.GetStringFromReader("Visto", reader)) ? true : false);

                    // Las relaciones desde los ADO particulares

                    return notificacion;
                }

                return null;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }

        public List<Notificacion> ObtenerListado(SqlConnection conexion)
        {
            SqlDataReader reader = null;

            List<Notificacion> listaNotificaciones = new List<Notificacion>();

            try
            {
                command = conexion.CreateCommand();

                command.Connection = conexion;

                command.CommandText = "SELECT * FROM Notificacion";

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Notificacion notificacion = new Notificacion();

                    notificacion.Id = UtilesBD.GetIntFromReader("id", reader);

                    notificacion.Contenido = UtilesBD.GetStringFromReader("Contenido", reader);

                    notificacion.Visto = ("1".Equals(UtilesBD.GetStringFromReader("Visto", reader)) ? true : false);

                    // Las relaciones desde los ADO particulares

                    listaNotificaciones.Add(notificacion);
                }

                return listaNotificaciones;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }
    }
}
