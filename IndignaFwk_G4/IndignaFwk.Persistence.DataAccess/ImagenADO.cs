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
    public class ImagenADO : IImagenADO
    {
        private SqlCommand command;

        public int Crear(Imagen imagen, SqlConnection conexion, SqlTransaction transaccion)
        {
            command = conexion.CreateCommand();

            command.Transaction = transaccion;

            command.Connection = conexion;

            command.CommandText = "INSERT INTO Imagen(Nombre, Referencia) " +
                                  "values(@nombre, @referencia); " + 
                                  "select @idGen = SCOPE_IDENTITY() FROM Imagen";

            command.Parameters.AddWithValue("nombre", imagen.Nombre);

            command.Parameters.AddWithValue("referencia", imagen.Referencia);

            // indico que la query tiene un parámetro de salida thisId de tipo int
            command.Parameters.Add("@idGen", SqlDbType.Int).Direction = ParameterDirection.Output;

            command.ExecuteScalar();

            // este es el identificador generado
            return (int)command.Parameters["@idGen"].Value;
        }

        public void Editar(Imagen imagen, SqlConnection conexion, SqlTransaction transaccion)
        {
            command = conexion.CreateCommand();

            command.Transaction = transaccion;

            command.Connection = conexion;

            command.CommandText = "UPDATE Imagen SET " + 
                                  "Nombre = @nombre, " + 
                                  "Referencia = @referencia " + 
                                  "WHERE Id = @id ";

            command.Parameters.AddWithValue("id", imagen.Id);
            command.Parameters.AddWithValue("nombre", imagen.Nombre);
            command.Parameters.AddWithValue("referencia", imagen.Referencia);

            command.ExecuteNonQuery();
        }

        public void Eliminar(int id, SqlConnection conexion, SqlTransaction transaccion)
        {
            command = conexion.CreateCommand();

            command.Transaction = transaccion;

            command.Connection = conexion;

            command.CommandText = "DELETE FROM Imagen WHERE Id = @id";

            command.Parameters.AddWithValue("id", id);

            command.ExecuteNonQuery();
        }

        public Imagen Obtener(int id, SqlConnection conexion)
        {
            SqlDataReader reader = null;

            try
            {
                command = conexion.CreateCommand();

                command.Connection = conexion;

                command.CommandText = "SELECT * FROM Imagen WHERE Id = @id";

                command.Parameters.AddWithValue("id", id); ;

                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Imagen imagen = new Imagen();

                    imagen.Id = UtilesBD.GetIntFromReader("Id", reader);

                    imagen.Nombre = UtilesBD.GetStringFromReader("Nombre", reader);

                    imagen.Referencia = UtilesBD.GetStringFromReader("Referencia", reader);

                    return imagen;
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

        public List<Imagen> ObtenerListado(SqlConnection conexion)
        {
            SqlDataReader reader = null;

            List<Imagen> listaImagenes = new List<Imagen>();

            try
            {
                command = conexion.CreateCommand();

                command.Connection = conexion;

                command.CommandText = "SELECT * FROM Imagen";

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Imagen imagen = new Imagen();

                    imagen.Id = UtilesBD.GetIntFromReader("Id", reader);

                    imagen.Nombre = UtilesBD.GetStringFromReader("Nombre", reader);

                    imagen.Referencia = UtilesBD.GetStringFromReader("Referencia", reader);

                    listaImagenes.Add(imagen);
                }

                return listaImagenes;
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
