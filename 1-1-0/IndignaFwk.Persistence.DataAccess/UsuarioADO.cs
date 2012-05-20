using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.Common.Entities;
using System.Data.SqlClient;

namespace IndignaFwk.Persistence.DataAccess
{
    public class UsuarioADO : IUsuarioADO
    {
        private SqlCommand command;

        public int Crear(Usuario usuario, SqlConnection conexion, SqlTransaction transaccion)
        {
            command = conexion.CreateCommand();
            command.Transaction = transaccion;
            command.Connection = conexion;

            command.CommandText = "INSERT INTO Usuario (Conectado, Descripcion, Email, IdSitio, Nombre, Password, Pregunta, Region, Respuesta) values(@Conectado, @Descripcion, @Email, @IdSitio, @Nombre, @Password, @Pregunta, @Region, @Respuesta)";

            command.Parameters.AddWithValue("Conectado", usuario.Conectado);
            command.Parameters.AddWithValue("Descripcion", usuario.Descripcion);
            command.Parameters.AddWithValue("Email", usuario.Email);
            command.Parameters.AddWithValue("IdSitio", usuario.IdSitio);
            command.Parameters.AddWithValue("Nombre", usuario.Nombre);
            command.Parameters.AddWithValue("Password", usuario.Password);
            command.Parameters.AddWithValue("Region", usuario.Region);
            command.Parameters.AddWithValue("Respuesta", usuario.RespuestaSeguridad);
            command.Parameters.AddWithValue("Pregunta", usuario.PreguntaSeguridad);

            command.ExecuteNonQuery();

            return 0;
        }

        public void Editar(Usuario usuario, SqlConnection conexion, SqlTransaction transaccion)
        {

            command = conexion.CreateCommand();
            command.Transaction = transaccion;
            command.Connection = conexion;

            command.CommandText = "UPDATE Usuario SET Conectado = @conectado, Descripcion = @descripcion, Email = @email, IdSitio = @sitio, Nombre=@nombre, Password = @password, Region = @region, Respuesta = @respuesta, Pregunta = @Pregunta WHERE Id = @id";

            command.Parameters.AddWithValue("Id", usuario.Id);
            command.Parameters.AddWithValue("Conectado", usuario.Conectado);
            command.Parameters.AddWithValue("Descripcion", usuario.Descripcion);
            command.Parameters.AddWithValue("Email", usuario.Email);
            command.Parameters.AddWithValue("IdSitio", usuario.IdSitio);
            command.Parameters.AddWithValue("Nombre", usuario.Nombre);
            command.Parameters.AddWithValue("Password", usuario.Password);
            command.Parameters.AddWithValue("Region", usuario.Region);
            command.Parameters.AddWithValue("Respuesta", usuario.RespuestaSeguridad);
            command.Parameters.AddWithValue("Pregunta", usuario.PreguntaSeguridad);

            command.ExecuteNonQuery();          
        }

        public void Eliminar(int id, SqlConnection conexion, SqlTransaction transaccion)
        {
            command = conexion.CreateCommand();
            command.Transaction = transaccion;
            command.Connection = conexion;

            command.CommandText = "DELETE FROM Usuario WHERE Id = @id";

            command.Parameters.AddWithValue("id", id);

            command.ExecuteNonQuery();
        }

        public Usuario Obtener(int id, SqlConnection conexion)
        {

            SqlDataReader reader = null;

            Usuario usuario = new Usuario();

            try
            {
                command = conexion.CreateCommand();
                command.Connection = conexion;

                command.CommandText = "SELECT * FROM Sitio WHERE Id = @id";

                SqlParameter param = new SqlParameter();

                param.ParameterName = "@id";

                param.Value = id;

                command.Parameters.Add(param);

                reader = command.ExecuteReader();

                bool encontrado = false;

                while ((reader.Read()) && (!encontrado))
                {
                    usuario.Id = ((int)reader["Id"]);
                    usuario.Nombre = ((string)reader["Nombre"]);
                    usuario.Conectado = ((bool)reader["Conectado"]);
                    usuario.Descripcion = ((string)reader["Descripcion"]);
                    usuario.Email = ((string)reader["Email"]);
                    usuario.IdSitio = ((int)reader["IdSitio"]);
                    usuario.Password = ((string)reader["Password"]);
                    usuario.PreguntaSeguridad = ((string)reader["PreguntaSeguridad"]);
                    usuario.RespuestaSeguridad = ((string)reader["RespuestaSeguridad"]);
                    usuario.Region = ((string)reader["Region"]);

                    if (((int)reader["Id"]) == id)
                    {
                        encontrado = true;
                    }
                }

                return usuario;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }

        public List<Usuario> ObtenerListado(SqlConnection conexion, SqlTransaction transaccion)
        {
            SqlDataReader reader = null;

            List<Usuario> _usuario = new List<Usuario>();

            try
            {
                command = conexion.CreateCommand();
                command.Transaction = transaccion;
                command.Connection = conexion;

                command.CommandText = "SELECT * FROM Usuario";

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Usuario varUsuario = new Usuario();

                    varUsuario.Id = ((int)reader["Id"]);
                    varUsuario.Nombre = ((string)reader["Nombre"]);
                    varUsuario.Conectado = ((bool)reader["Conectado"]);
                    varUsuario.Descripcion = ((string)reader["Descripcion"]);
                    varUsuario.Email = ((string)reader["Email"]);
                    varUsuario.IdSitio = ((int)reader["IdSitio"]);
                    varUsuario.Password = ((string)reader["Password"]);
                    varUsuario.PreguntaSeguridad = ((string)reader["PreguntaSeguridad"]);
                    varUsuario.RespuestaSeguridad = ((string)reader["RespuestaSeguridad"]);
                    varUsuario.Region = ((string)reader["Region"]);

                    _usuario.Add(varUsuario);
                }

                return _usuario;
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

