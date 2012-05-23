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
    public class UsuarioADO : IUsuarioADO
    {
        private SqlCommand command;

        /* DEPENDENCIAS */
        private IGrupoADO _grupoADO;

        protected IGrupoADO GrupoADO
        {
            get
            {
                if (_grupoADO == null)
                {
                    _grupoADO = new GrupoADO();
                }

                return _grupoADO;
            }
        }

        public int Crear(Usuario usuario, SqlConnection conexion, SqlTransaction transaccion)
        {
            command = conexion.CreateCommand();

            command.Transaction = transaccion;

            command.Connection = conexion;

            command.CommandText = "INSERT INTO Usuario (Conectado, Descripcion, Email, FK_Id_Sitio, Nombre, Password, Pregunta, Region, Respuesta) " +
                                  "values(@Conectado, @Descripcion, @Email, @IdSitio, @Nombre, @Password, @Pregunta, @Region, @Respuesta); " +
                                  " select @idGen = SCOPE_IDENTITY() FROM Usuario; ";

            
            UtilesBD.SetParameter(command, "Conectado", (usuario.Conectado == true ? "1" : "0"));
            UtilesBD.SetParameter(command, "Descripcion", usuario.Descripcion);
            UtilesBD.SetParameter(command, "Email", usuario.Email);
            UtilesBD.SetParameter(command, "IdSitio", usuario.Grupo.Id);
            UtilesBD.SetParameter(command, "Nombre", usuario.Nombre);
            UtilesBD.SetParameter(command, "Password", usuario.Password);
            UtilesBD.SetParameter(command, "Region", usuario.Region);
            UtilesBD.SetParameter(command, "Respuesta", usuario.RespuestaSeguridad);
            UtilesBD.SetParameter(command, "Pregunta", usuario.PreguntaSeguridad);
            
            // indico que la query tiene un parámetro de salida thisId de tipo int
            command.Parameters.Add("@idGen", SqlDbType.Int).Direction = ParameterDirection.Output;

            command.ExecuteScalar();

            // este es el identificador generado
            return (int)command.Parameters["@idGen"].Value;
        }

        public void Editar(Usuario usuario, SqlConnection conexion, SqlTransaction transaccion)
        {
            command = conexion.CreateCommand();

            command.Transaction = transaccion;

            command.Connection = conexion;

            command.CommandText = "UPDATE Usuario SET " + 
                                  "Conectado = @conectado, " + 
                                  "Descripcion = @descripcion, " + 
                                  "Email = @email, " + 
                                  "FK_Id_Sitio = @sitio, " + 
                                  "Nombre=@nombre, " + 
                                  "Password = @password, " + 
                                  "Region = @region, " + 
                                  "Respuesta = @respuesta, " + 
                                  "Pregunta = @Pregunta " + 
                                  "WHERE Id = @id";

            UtilesBD.SetParameter(command, "Id", usuario.Id);
            UtilesBD.SetParameter(command, "Conectado", (usuario.Conectado == true ? "1" : "0"));
            UtilesBD.SetParameter(command, "Descripcion", usuario.Descripcion);
            UtilesBD.SetParameter(command, "Email", usuario.Email);
            UtilesBD.SetParameter(command, "IdSitio", usuario.Grupo.Id);
            UtilesBD.SetParameter(command, "Nombre", usuario.Nombre);
            UtilesBD.SetParameter(command, "Password", usuario.Password);
            UtilesBD.SetParameter(command, "Region", usuario.Region);
            UtilesBD.SetParameter(command, "Respuesta", usuario.RespuestaSeguridad);
            UtilesBD.SetParameter(command, "Pregunta", usuario.PreguntaSeguridad);

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

            try
            {
                command = conexion.CreateCommand();

                command.Connection = conexion;

                command.CommandText = "SELECT * FROM Usuario WHERE Id = @id";

                command.Parameters.AddWithValue("id", id);

                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Usuario usuario = new Usuario();

                    usuario.Id = UtilesBD.GetIntFromReader("Id", reader);

                    usuario.Nombre = UtilesBD.GetStringFromReader("Nombre", reader);

                    usuario.Conectado = ("1".Equals(UtilesBD.GetStringFromReader("Conectado", reader)) ? true : false);

                    usuario.Descripcion = UtilesBD.GetStringFromReader("Descripcion", reader);

                    usuario.Email = UtilesBD.GetStringFromReader("Email", reader);

                    usuario.Password = UtilesBD.GetStringFromReader("Password", reader);

                    usuario.PreguntaSeguridad = UtilesBD.GetStringFromReader("PreguntaSeguridad", reader);

                    usuario.RespuestaSeguridad = UtilesBD.GetStringFromReader("RespuestaSeguridad", reader);

                    usuario.Region = UtilesBD.GetStringFromReader("Region", reader);

                    // Las referecias cargaras con los otros dao
                    return usuario;
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

        public List<Usuario> ObtenerListado(SqlConnection conexion)
        {
            SqlDataReader reader = null;

            List<Usuario> listaUsuarios = new List<Usuario>();

            try
            {
                command = conexion.CreateCommand();

                command.Connection = conexion;

                command.CommandText = "SELECT * FROM Usuario";

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Usuario usuario = new Usuario();

                    usuario.Id = UtilesBD.GetIntFromReader("Id", reader);

                    usuario.Nombre = UtilesBD.GetStringFromReader("Nombre", reader);

                    usuario.Conectado = ("1".Equals(UtilesBD.GetStringFromReader("Conectado", reader)) ? true : false);

                    usuario.Descripcion = UtilesBD.GetStringFromReader("Descripcion", reader);

                    usuario.Email = UtilesBD.GetStringFromReader("Email", reader);

                    usuario.Password = UtilesBD.GetStringFromReader("Password", reader);

                    usuario.PreguntaSeguridad = UtilesBD.GetStringFromReader("PreguntaSeguridad", reader);

                    usuario.RespuestaSeguridad = UtilesBD.GetStringFromReader("RespuestaSeguridad", reader);

                    usuario.Region = UtilesBD.GetStringFromReader("Region", reader);

                    // Las referecias cargaras con los otros dao
                    listaUsuarios.Add(usuario);
                }

                return listaUsuarios;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }   
            }
        }

        public Usuario ObtenerPorEmail(string email, SqlConnection conexion)
        {
            SqlDataReader reader = null;

            try
            {
                command = conexion.CreateCommand();

                command.Connection = conexion;

                command.CommandText = "SELECT * FROM Usuario WHERE Email = @email";

                UtilesBD.SetParameter(command, "email", email);

                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Usuario usuario = new Usuario();

                    usuario.Id = UtilesBD.GetIntFromReader("Id", reader);

                    usuario.Nombre = UtilesBD.GetStringFromReader("Nombre", reader);

                    usuario.Conectado = ("1".Equals(UtilesBD.GetStringFromReader("Conectado", reader)) ? true : false);

                    usuario.Descripcion = UtilesBD.GetStringFromReader("Descripcion", reader);

                    usuario.Email = UtilesBD.GetStringFromReader("Email", reader);

                    usuario.Password = UtilesBD.GetStringFromReader("Password", reader);

                    usuario.PreguntaSeguridad = UtilesBD.GetStringFromReader("PreguntaSeguridad", reader);

                    usuario.RespuestaSeguridad = UtilesBD.GetStringFromReader("RespuestaSeguridad", reader);

                    usuario.Region = UtilesBD.GetStringFromReader("Region", reader);

                    usuario.Grupo = GrupoADO.Obtener(UtilesBD.GetIntFromReader("FK_Id_Grupo", reader), conexion);
                    
                    return usuario;
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
    }

       
}

