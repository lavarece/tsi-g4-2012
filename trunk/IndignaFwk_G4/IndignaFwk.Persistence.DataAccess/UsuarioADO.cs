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
            command.Parameters.AddWithValue("IdSitio", usuario.Grupo);
            command.Parameters.AddWithValue("Nombre", usuario.Nombre);
            command.Parameters.AddWithValue("Password", usuario.Password);
            command.Parameters.AddWithValue("Region", usuario.Region);
            command.Parameters.AddWithValue("Respuesta", usuario.RespuestaSeguridad);

            command.ExecuteNonQuery();

            return 0;
        }

        public void Editar(Usuario usuario, SqlConnection conexion, SqlTransaction transaccion)
        {

            command = conexion.CreateCommand();
            command.Transaction = transaccion;
            command.Connection = conexion;

            command.CommandText = "UPDATE Usuario SET Conectado = @conectado, Descripcion = @descripcion, Email = @email, IdSitio = @sitio, Nombre=@nombre, Password = @password, Region = @region, Respuesta = @respuesta WHERE Id = @id";

            command.Parameters.AddWithValue("Id", usuario.Id);
            command.Parameters.AddWithValue("Conectado", usuario.Conectado);
            command.Parameters.AddWithValue("Descripcion", usuario.Descripcion);
            command.Parameters.AddWithValue("Email", usuario.Email);
            command.Parameters.AddWithValue("IdSitio", usuario.Grupo);
            command.Parameters.AddWithValue("Nombre", usuario.Nombre);
            command.Parameters.AddWithValue("Password", usuario.Password);
            command.Parameters.AddWithValue("Region", usuario.Region);
            command.Parameters.AddWithValue("Respuesta", usuario.RespuestaSeguridad);

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

            command = new SqlCommand("Select * from Usuario where Id = @id", conexion);

            SqlParameter param = new SqlParameter();

            param.ParameterName = "@id";

            param.Value = id;

            command.Parameters.Add(param);

            reader = command.ExecuteReader();

            while (reader.Read())
            {
               /* grupo.Id = ((int)reader["Id"]);
                grupo.Nombre = ((string)reader["Nombre"]);
                grupo.LogoUrl = ((string)reader["LogoUrl"]);
                grupo.Descripcion = ((string)reader["Descripcion"]);
                grupo.Url = ((string)reader["Url"]); */   
            }

            return usuario;
        
        }

        public List<Usuario> ObtenerListado(SqlConnection conexion)
        {
            SqlDataReader reader = null;

            List<Usuario> _usuario = new List<Usuario>();

            command = new SqlCommand("Select * from Usuario", conexion);

            reader = command.ExecuteReader();


            while (reader.Read())
            {
                Usuario varUsuario = new Usuario();

                varUsuario.Id = ((int)reader["Id"]);
                varUsuario.Conectado = ((bool)reader["Conectado"]);
                varUsuario.Descripcion = ((String)reader["Descripcion"]);
                varUsuario.Email = ((String)reader["Email"]);
                varUsuario.Grupo = ((Grupo)reader["Grupo"]);
                varUsuario.Nombre = ((String)reader["Nombre"]);
                varUsuario.Password = ((String)reader["Password"]);
                varUsuario.PreguntaSeguridad = ((String)reader["Pregunta"]);
                varUsuario.Region = ((String)reader["Region"]);
                varUsuario.RespuestaSeguridad = ((String)reader["Respuesta"]);
                _usuario.Add(varUsuario);
            }

            return _usuario;
        }

       
    }
}
