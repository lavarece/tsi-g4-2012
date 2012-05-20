using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.Common.Entities;
using System.Data.SqlClient;

namespace IndignaFwk.Persistence.DataAccess
{
    public class ContenidoADO : IContenidoADO
    {
        private SqlCommand command;

        public int Crear(Contenido contenido, SqlConnection conexion, SqlTransaction transaccion)
        {
            command = conexion.CreateCommand();
            command.Transaction = transaccion;
            command.Connection = conexion;
            
            command.CommandText = ("INSERT INTO Contenido(Url) values(@url)");
            
            command.Parameters.AddWithValue("url", contenido.Url);
            
            command.ExecuteNonQuery();

            return 0;
        }

        /*************************************************************************************/
        /*************************************************************************************/

        public void Editar(Contenido contenido, SqlConnection conexion, SqlTransaction transaccion)
        {
            command = conexion.CreateCommand();
            command.Transaction = transaccion;
            command.Connection = conexion;
            
            command.CommandText = ("UPDATE Contenido SET Url = @url WHERE Id = @id");

            command.Parameters.AddWithValue("Id", contenido.Id);
            command.Parameters.AddWithValue("url", contenido.Url);

            command.ExecuteNonQuery();
        }

        /*************************************************************************************/
        /*************************************************************************************/

        public void Eliminar(int id, SqlConnection conexion, SqlTransaction transaccion)
        {
            command = conexion.CreateCommand();
            command.Transaction = transaccion;
            command.Connection = conexion;
            
            command.CommandText = "DELETE FROM Contenido WHERE Id = @id";
            
            command.Parameters.AddWithValue("id", id);

            command.ExecuteNonQuery();            
        }

        /*************************************************************************************/
        /*************************************************************************************/

        public Contenido Obtener(int id, SqlConnection conexion, SqlTransaction transaccion)
        {
            SqlDataReader reader = null;

            Contenido contenido = new Contenido();

            try
            {
                command = conexion.CreateCommand();
                command.Transaction = transaccion;
                command.Connection = conexion;
                
                command.CommandText = "SELECT * FROM Contenido WHERE Id = @id";

                SqlParameter param = new SqlParameter();

                param.ParameterName = "@id";

                param.Value = id;

                command.Parameters.Add(param);

                reader = command.ExecuteReader();

                bool encontrado = false;

                while ((reader.Read()) && (!encontrado))
                {
                    contenido.Id = ((int)reader["Id"]);
                    contenido.Url = ((string)reader["Url"]);

                    if (((int)reader["Id"]) == id)
                    {
                        encontrado = true;
                    }
                }

                return contenido;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }

        /*************************************************************************************/
        /*************************************************************************************/

        public List<Contenido> ObtenerListado(SqlConnection conexion, SqlTransaction transaccion)
        {
            SqlDataReader reader = null;

            List<Contenido> contenidoList = new List<Contenido>();

            try
            {
                command = conexion.CreateCommand();
                command.Transaction = transaccion;
                command.Connection = conexion;

                command.CommandText = "SELECT * FROM Contenido";

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Contenido contenido = new Contenido();

                    contenido.Id = ((int)reader["Id"]);
                    contenido.Url = ((string)reader["Url"]);

                    contenidoList.Add(contenido);
                }

                return contenidoList;
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
