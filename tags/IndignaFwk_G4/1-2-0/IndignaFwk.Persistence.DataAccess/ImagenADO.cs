using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.Common.Entities;
using System.Data.SqlClient;

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

            command.CommandText = "INSERT INTO Imagen(Nombre, Referencia) values(@nombre, @referencia)";

            command.Parameters.AddWithValue("nombre", imagen.Nombre);
            command.Parameters.AddWithValue("referencia", imagen.Referencia);

            command.ExecuteNonQuery();

            return 0;
        }

        /*************************************************************************************/
        /*************************************************************************************/

        public void Editar(Imagen imagen, SqlConnection conexion, SqlTransaction transaccion)
        {
            command = conexion.CreateCommand();
            command.Transaction = transaccion;
            command.Connection = conexion;

            command.CommandText = " UPDATE Imagen SET Nombre = @nombre, Referencia = @referencia WHERE Id = @id ";

            command.Parameters.AddWithValue("id", imagen.Id);
            command.Parameters.AddWithValue("nombre", imagen.Nombre);
            command.Parameters.AddWithValue("referencia", imagen.Referencia);

            command.ExecuteNonQuery();
        }

        /*************************************************************************************/
        /*************************************************************************************/

        public void Eliminar(int id, SqlConnection conexion, SqlTransaction transaccion)
        {
            command = conexion.CreateCommand();
            command.Transaction = transaccion;
            command.Connection = conexion;

            command.CommandText = "DELETE FROM Imagen WHERE Id = @id";

            command.Parameters.AddWithValue("id", id);

            command.ExecuteNonQuery();
        }

        /*************************************************************************************/
        /*************************************************************************************/

        public Imagen Obtener(int id, SqlConnection conexion, SqlTransaction transaccion)
        {
            SqlDataReader reader = null;

            Imagen imagen = new Imagen();

            try
            {
                command = conexion.CreateCommand();
                command.Transaction = transaccion;
                command.Connection = conexion;

                command.CommandText = "SELECT * FROM Imagen WHERE Id = @id";

                SqlParameter param = new SqlParameter();

                param.ParameterName = "@id";

                param.Value = id;

                command.Parameters.Add(param);

                reader = command.ExecuteReader();

                bool encontrado = false;

                while ((reader.Read()) && (!encontrado))
                {
                    imagen.Id = ((int)reader["Id"]);
                    imagen.Nombre = ((string)reader["Nombre"]);
                    imagen.Referencia = ((string)reader["Referencia"]);

                    if (((int)reader["Id"]) == id)
                    {
                        encontrado = true;
                    }
                }

                return imagen;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }

        public List<Imagen> ObtenerListado(SqlConnection conexion, SqlTransaction transaccion)
        {
            SqlDataReader reader = null;

            List<Imagen> imagenList = new List<Imagen>();

            try
            {
                command = conexion.CreateCommand();
                command.Transaction = transaccion;
                command.Connection = conexion;

                command.CommandText = "SELECT * FROM Imagen";

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Imagen imagen = new Imagen();

                    imagen.Id = ((int)reader["Id"]);
                    imagen.Nombre = ((string)reader["Nombre"]);
                    imagen.Referencia = ((string)reader["Referencia"]);

                    imagenList.Add(imagen);
                }

                return imagenList;
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
