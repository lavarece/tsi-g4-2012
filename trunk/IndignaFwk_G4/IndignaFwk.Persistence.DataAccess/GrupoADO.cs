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
       
            try
            {
                command = conexion.CreateCommand();

                command.Connection = conexion;
                
                command.CommandText ="select * from Sitio where Id = @id";

                command.Parameters.AddWithValue("id", id);

                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Grupo grupo = new Grupo();

                    grupo.Id = UtilesBD.GetIntFromReader("id", reader);

                    grupo.Nombre = UtilesBD.GetStringFromReader("Nombre", reader);

                    grupo.LogoUrl = UtilesBD.GetStringFromReader("LogoUrl", reader);

                    grupo.Descripcion = UtilesBD.GetStringFromReader("Descripcion", reader);

                    grupo.Url = UtilesBD.GetStringFromReader("Url", reader);

                    return grupo;
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

        public Grupo ObtenerPorUrl(string url, SqlConnection conexion)
        {
            SqlDataReader reader = null;

            try
            {
                command = conexion.CreateCommand();

                command.Connection = conexion;

                command.CommandText = "select * from Sitio where Url = @url";

                command.Parameters.AddWithValue("url", url);

                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Grupo grupo = new Grupo();

                    grupo.Id = UtilesBD.GetIntFromReader("id", reader);

                    grupo.Nombre = UtilesBD.GetStringFromReader("Nombre", reader);

                    grupo.LogoUrl = UtilesBD.GetStringFromReader("LogoUrl", reader);

                    grupo.Descripcion = UtilesBD.GetStringFromReader("Descripcion", reader);

                    grupo.Url = UtilesBD.GetStringFromReader("Url", reader);

                    return grupo;
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