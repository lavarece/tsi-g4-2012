using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.Common.Entities;
using System.Data.SqlClient;
using System.Data;

namespace IndignaFwk.Persistence.DataAccess
{
    public class GrupoADO : IGrupoADO
    {
        private SqlCommand command;    
        
        public int Crear(Grupo grupo, SqlConnection conexion, SqlTransaction transaccion)
        {
            command = conexion.CreateCommand();

            command.Transaction = transaccion;

            command.Connection = conexion;
            
            command.CommandText = " insert into Sitio(Nombre, Descripcion, Url) " +
                                  " values(@nombre, @descripcion, @url) " + 
                                  " select @idGen = SCOPE_IDENTITY() FROM Sitio ";
            
            command.Parameters.AddWithValue("nombre", grupo.Nombre);

            command.Parameters.AddWithValue("descripcion", grupo.Descripcion);

            command.Parameters.AddWithValue("url", grupo.Url);

            // indico que la query tiene un parámetro de salida thisId de tipo int
            command.Parameters.Add("@idGen", SqlDbType.Int).Direction = ParameterDirection.Output;

            command.ExecuteScalar();

            // este es el identificador generado
            int idNuevo = (int)command.Parameters["@idGen"].Value;

            return idNuevo;
        }

        /*************************************************************************************/
        /*************************************************************************************/

        public void Editar(Grupo grupo, SqlConnection conexion, SqlTransaction transaccion)
        {
            command = conexion.CreateCommand();
            command.Transaction = transaccion;
            command.Connection = conexion;
            
            command.CommandText = " UPDATE Sitio SET Nombre = @nombre, LogoUrl = @logoUrl, Descripcion = @descripcion, Url = @url WHERE Id = @id ";

            command.Parameters.AddWithValue("id", grupo.Id);
            command.Parameters.AddWithValue("nombre", grupo.Nombre);
            command.Parameters.AddWithValue("logoUrl", grupo.LogoUrl);
            command.Parameters.AddWithValue("descripcion", grupo.Descripcion);
            command.Parameters.AddWithValue("url", grupo.Url);

            command.ExecuteNonQuery();
        }

        /*************************************************************************************/
        /*************************************************************************************/

        public void Eliminar(int id, SqlConnection conexion, SqlTransaction transaccion)
        {
            command = conexion.CreateCommand();
            command.Transaction = transaccion;
            command.Connection = conexion;
            
            command.CommandText = "DELETE FROM Sitio WHERE Id = @id";
            
            command.Parameters.AddWithValue("id", id);
            
            command.ExecuteNonQuery();
        }

        public Grupo Obtener(int id, SqlConnection conexion)
        {
            SqlDataReader reader = null;
       
            Grupo grupo = new Grupo();

            try
            {
                command = conexion.CreateCommand();
                command.Connection = conexion;
                
                command.CommandText ="SELECT * FROM Sitio WHERE Id = @id";

                SqlParameter param = new SqlParameter();

                param.ParameterName = "@id";

                param.Value = id;

                command.Parameters.Add(param);

                reader = command.ExecuteReader();

                bool encontrado = false;

                while ((reader.Read()) && (!encontrado))
                {
                    grupo.Id = ((int)reader["Id"]);
                    grupo.Nombre = ((string)reader["Nombre"]);
                    grupo.LogoUrl = ((string)reader["LogoUrl"]);
                    grupo.Descripcion = ((string)reader["Descripcion"]);
                    grupo.Url = ((string)reader["Url"]);

                    if (((int)reader["Id"]) == id)
                    {
                        encontrado = true;
                    }
                }

                return grupo;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }            
            }
        }

        public Grupo ObtenerPorUrl(string url, SqlConnection conexion)
        {
            SqlDataReader reader = null;

            try
            {
                command = conexion.CreateCommand();

                command.Connection = conexion;

                command.CommandText = "SELECT * FROM Sitio WHERE Url = @url";

                command.Parameters.Add(new SqlParameter("@url", url));

                reader = command.ExecuteReader();

                if (reader.NextResult())
                {
                    Grupo grupo = new Grupo();

                    grupo.Id = ((int)reader["Id"]);

                    grupo.Nombre = ((string)reader["Nombre"]);

                    grupo.LogoUrl = ((string)reader["LogoUrl"]);

                    grupo.Descripcion = ((string)reader["Descripcion"]);

                    grupo.Url = ((string)reader["Url"]);

                    return grupo;
                }
                else
                {
                    return null;
                }
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
        
        public List<Grupo> ObtenerListado(SqlConnection conexion)
        {
            SqlDataReader reader = null;

            List<Grupo> _grupo = new List<Grupo>();

            try
            {
                command = conexion.CreateCommand();
                command.Connection = conexion;

                command.CommandText = "SELECT * FROM Sitio";

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Grupo varGrupo = new Grupo();

                    varGrupo.Id = ((int)reader["Id"]);
                    varGrupo.Nombre = ((string)reader["Nombre"]);
                    varGrupo.LogoUrl = ((string)reader["LogoUrl"]);
                    varGrupo.Descripcion = ((string)reader["Descripcion"]);
                    varGrupo.Url = ((string)reader["Url"]);

                    _grupo.Add(varGrupo);
                }

                return _grupo;
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