using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.Business.Entities;
using System.Data.SqlClient;

namespace IndignaFwk.Persistence.DataAccess
{
    public class UsuarioADO : IUsuarioADO
    {
        private SqlCommand command;

        public Int32 Crear(Usuario usuario, SqlConnection conexion)
        {
            command = new SqlCommand("Insert into Usuario(Conectado, Descripcion, Email, IdSitio, Nombre, Password, Pregunta, Region, Respuesta) values(@Conectado, @Descripcion, @Email, @IdSitio, @Nombre, @Password, @Pregunta, @Region, @Respuesta)", conexion);
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

        public void Editar(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(long id)
        {
            throw new NotImplementedException();
        }

        public Usuario Obtener(long id)
        {
            throw new NotImplementedException();
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

                varUsuario.Id = ((Int32)reader["Id"]);
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

        public List<Usuario> ObtenerListado()
        {
            throw new NotImplementedException();
        }
    }
}
