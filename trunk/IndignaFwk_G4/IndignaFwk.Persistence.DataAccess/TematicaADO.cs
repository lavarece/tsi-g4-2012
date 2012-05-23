using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.Common.Entities;
using System.Data;
using IndignaFwk.Common.Util;
using System.Data.SqlClient;

namespace IndignaFwk.Persistence.DataAccess
{
    public class TematicaADO : ITematicaADO
    {
        private SqlCommand command;    

        public int Crear(Tematica tematica, SqlConnection conexion, SqlTransaction transaccion)
        {
            command = conexion.CreateCommand();

            command.Transaction = transaccion;

            command.Connection = conexion;

            command.CommandText = " insert into Tematica(Nombre) " +
                                  " values(@nombre); " +
                                  " select @idGen = SCOPE_IDENTITY() FROM Tematica; ";

            command.Parameters.AddWithValue("nombre", tematica.Nombre);

            // indico que la query tiene un parámetro de salida thisId de tipo int
            command.Parameters.Add("@idGen", SqlDbType.Int).Direction = ParameterDirection.Output;

            command.ExecuteScalar();

            // este es el identificador generado
            return (int)command.Parameters["@idGen"].Value;
        }

        public void Editar(Tematica tematica, SqlConnection conexion, SqlTransaction transaccion)
        {
            command = conexion.CreateCommand();

            command.Transaction = transaccion;

            command.Connection = conexion;

            command.CommandText = " UPDATE Tematica SET " +
                                  " Nombre = @nombre, " +                                  
                                  " WHERE Id = @id";

            command.Parameters.AddWithValue("id", tematica.Id);
            command.Parameters.AddWithValue("nombre", tematica.Nombre);
            
            command.ExecuteNonQuery();
        }

        public void Eliminar(int id, SqlConnection conexion, SqlTransaction transaccion)
        {
            command = conexion.CreateCommand();

            command.Transaction = transaccion;

            command.Connection = conexion;

            command.CommandText = "DELETE FROM Tematica WHERE Id = @id";

            command.Parameters.AddWithValue("id", id);

            command.ExecuteNonQuery();
        }

        public Tematica Obtener(int id, SqlConnection conexion)
        {
            SqlDataReader reader = null;

            try
            {
                command = conexion.CreateCommand();

                command.Connection = conexion;

                command.CommandText = "select * from Tematica where Id = @id";

                command.Parameters.AddWithValue("id", id);

                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Tematica tematica = new Tematica();

                    tematica.Id = UtilesBD.GetIntFromReader("id", reader);

                    tematica.Nombre = UtilesBD.GetStringFromReader("Nombre", reader);
                    
                    return tematica;
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

        public List<Tematica> ObtenerListado(SqlConnection conexion)
        {
            SqlDataReader reader = null;

            List<Tematica> listaTematicas = new List<Tematica>();

            try
            {
                command = conexion.CreateCommand();

                command.Connection = conexion;

                command.CommandText = "SELECT * FROM Tematica";

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Tematica tematica = new Tematica();

                    tematica.Id = UtilesBD.GetIntFromReader("id", reader);

                    tematica.Nombre = UtilesBD.GetStringFromReader("Nombre", reader);

                    listaTematicas.Add(tematica);
                }

                return listaTematicas;
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
