﻿using System;
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

        // DEPENDENCIAS
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

        public void Crear(Usuario usuario, SqlConnection conexion, SqlTransaction transaccion)
        {
            command = conexion.CreateCommand();

            command.Transaction = transaccion;

            command.Connection = conexion;

            command.CommandText = "INSERT INTO Usuario (Conectado, Descripcion, Email, Nombre, Apellido, Password, Pregunta, Coordenadas, Respuesta, Eliminado, FK_Id_Sitio, FK_Id_Imagen) " +
                                  "values(@Conectado, @Descripcion, @Email, @Nombre, @Apellido, @Password, @Pregunta, @Coordenadas, @Respuesta, @Eliminado, @IdSitio, @IdImagen); " +
                                  " select @idGen = SCOPE_IDENTITY() FROM Usuario; ";

            
            UtilesBD.SetParameter(command, "Conectado", (usuario.Conectado == true ? "1" : "0"));
            UtilesBD.SetParameter(command, "Descripcion", usuario.Descripcion);
            UtilesBD.SetParameter(command, "Email", usuario.Email);            
            UtilesBD.SetParameter(command, "Nombre", usuario.Nombre);
            UtilesBD.SetParameter(command, "Apellido", usuario.Apellido);
            UtilesBD.SetParameter(command, "Password", usuario.Password);
            UtilesBD.SetParameter(command, "Coordenadas", usuario.Coordenadas);
            UtilesBD.SetParameter(command, "Respuesta", usuario.Respuesta);
            UtilesBD.SetParameter(command, "Pregunta", usuario.Pregunta);
            UtilesBD.SetParameter(command, "Eliminado", false);
            UtilesBD.SetParameter(command, "IdSitio", usuario.Grupo.Id);

            if(usuario.Imagen != null)
                UtilesBD.SetParameter(command, "IdImagen", usuario.Imagen.Id);
            else
                UtilesBD.SetParameter(command, "IdImagen", null);
            
            // indico que la query tiene un parámetro de salida thisId de tipo int
            command.Parameters.Add("@idGen", SqlDbType.Int).Direction = ParameterDirection.Output;

            command.ExecuteScalar();

            // este es el identificador generado
            usuario.Id = (int)command.Parameters["@idGen"].Value;
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
                                  "Nombre = @nombre, " +
                                  "Apellido = @apellido, " +
                                  "Password = @password, " +
                                  "Coordenadas = @Coordenadas, " + 
                                  "Respuesta = @respuesta, " + 
                                  "Pregunta = @Pregunta " + 
                                  "WHERE Id = @id";

            UtilesBD.SetParameter(command, "Id", usuario.Id);
            UtilesBD.SetParameter(command, "Conectado", (usuario.Conectado == true ? "1" : "0"));
            UtilesBD.SetParameter(command, "Descripcion", usuario.Descripcion);
            UtilesBD.SetParameter(command, "Email", usuario.Email);
            UtilesBD.SetParameter(command, "Nombre", usuario.Nombre);
            UtilesBD.SetParameter(command, "Apellido", usuario.Apellido);
            UtilesBD.SetParameter(command, "Password", usuario.Password);
            UtilesBD.SetParameter(command, "Coordenadas", usuario.Coordenadas);
            UtilesBD.SetParameter(command, "Respuesta", usuario.Respuesta);
            UtilesBD.SetParameter(command, "Pregunta", usuario.Pregunta);

            command.ExecuteNonQuery();          
        }

        public void Eliminar(int id, SqlConnection conexion, SqlTransaction transaccion)
        {
            command = conexion.CreateCommand();

            command.Transaction = transaccion;

            command.Connection = conexion;

            command.CommandText = "UPDATE Usuario Set Eliminado = 1 WHERE Id = @id";

            UtilesBD.SetParameter(command, "id", id);

            command.ExecuteNonQuery();
        }

        public Usuario Obtener(int id, SqlConnection conexion)
        {
            SqlDataReader reader = null;

            try
            {
                command = conexion.CreateCommand();

                command.Connection = conexion;

                command.CommandText = "SELECT * FROM Usuario WHERE Id = @id and Eliminado = 0";

                command.Parameters.AddWithValue("id", id);

                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Usuario usuario = new Usuario();

                    usuario.Id = UtilesBD.GetIntFromReader("Id", reader);

                    usuario.Nombre = UtilesBD.GetStringFromReader("Nombre", reader);

                    usuario.Apellido = UtilesBD.GetStringFromReader("Apellido", reader);

                    usuario.Conectado = ("1".Equals(UtilesBD.GetStringFromReader("Conectado", reader)) ? true : false);

                    usuario.Descripcion = UtilesBD.GetStringFromReader("Descripcion", reader);

                    usuario.Email = UtilesBD.GetStringFromReader("Email", reader);

                    usuario.Password = UtilesBD.GetStringFromReader("Password", reader);

                    usuario.Pregunta = UtilesBD.GetStringFromReader("Pregunta", reader);

                    usuario.Respuesta = UtilesBD.GetStringFromReader("Respuesta", reader);

                    usuario.Coordenadas = UtilesBD.GetStringFromReader("Coordenadas", reader);

                    usuario.FechaRegistro = (DateTime)UtilesBD.GetDateTimeFromReader("FechaRegistro", reader);

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

        public List<Usuario> ObtenerUsuariosPorIdGrupo(int idGrupo, SqlConnection conexion, SqlTransaction transaccion = null)
        {
            SqlDataReader reader = reader = null;

            List<Usuario> listaUsuarioGrupo = new List<Usuario>();

            try
            {
                command = conexion.CreateCommand();

                if (transaccion != null)
                {
                    command.Transaction = transaccion;
                }

                command.Connection = conexion;

                command.CommandText = "SELECT * FROM Usuario WHERE FK_Id_Sitio = @id and Eliminado = 0";

                command.Parameters.AddWithValue("id", idGrupo);

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Usuario usuario = new Usuario();

                    usuario.Id = UtilesBD.GetIntFromReader("Id", reader);

                    usuario.Nombre = UtilesBD.GetStringFromReader("Nombre", reader);

                    usuario.Apellido = UtilesBD.GetStringFromReader("Apellido", reader);

                    usuario.Conectado = ("1".Equals(UtilesBD.GetStringFromReader("Conectado", reader)) ? true : false);

                    usuario.Descripcion = UtilesBD.GetStringFromReader("Descripcion", reader);

                    usuario.Email = UtilesBD.GetStringFromReader("Email", reader);

                    usuario.Password = UtilesBD.GetStringFromReader("Password", reader);

                    usuario.Pregunta = UtilesBD.GetStringFromReader("Pregunta", reader);

                    usuario.Respuesta = UtilesBD.GetStringFromReader("Respuesta", reader);

                    usuario.Coordenadas = UtilesBD.GetStringFromReader("Coordenadas", reader);

                    usuario.FechaRegistro = (DateTime)UtilesBD.GetDateTimeFromReader("FechaRegistro", reader);

                    listaUsuarioGrupo.Add(usuario);
                }
                return listaUsuarioGrupo;

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

                command.CommandText = "SELECT * FROM Usuario where Eliminado = 0";

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Usuario usuario = new Usuario();

                    usuario.Id = UtilesBD.GetIntFromReader("Id", reader);

                    usuario.Nombre = UtilesBD.GetStringFromReader("Nombre", reader);

                    usuario.Apellido = UtilesBD.GetStringFromReader("Apellido", reader);

                    usuario.Conectado = ("1".Equals(UtilesBD.GetStringFromReader("Conectado", reader)) ? true : false);

                    usuario.Descripcion = UtilesBD.GetStringFromReader("Descripcion", reader);

                    usuario.Email = UtilesBD.GetStringFromReader("Email", reader);

                    usuario.Password = UtilesBD.GetStringFromReader("Password", reader);

                    usuario.Pregunta = UtilesBD.GetStringFromReader("Pregunta", reader);

                    usuario.Respuesta = UtilesBD.GetStringFromReader("Respuesta", reader);

                    usuario.Coordenadas = UtilesBD.GetStringFromReader("Coordenadas", reader);

                    usuario.FechaRegistro = (DateTime)UtilesBD.GetDateTimeFromReader("FechaRegistro", reader);

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



        public Usuario ObtenerPorEmailYGrupo(string email, int idGrupo, SqlConnection conexion)
        { 
            SqlDataReader reader = null;

            try
            {
                command = conexion.CreateCommand();

                command.Connection = conexion;

                command.CommandText = "SELECT * FROM Usuario WHERE Email = @email and FK_Id_Sitio = @idSitio and Eliminado = 0";

                UtilesBD.SetParameter(command, "email", email);

                UtilesBD.SetParameter(command, "idSitio", idGrupo);

                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Usuario usuario = new Usuario();

                    usuario.Id = UtilesBD.GetIntFromReader("Id", reader);

                    usuario.Nombre = UtilesBD.GetStringFromReader("Nombre", reader);

                    usuario.Apellido = UtilesBD.GetStringFromReader("Apellido", reader);

                    usuario.Conectado = ("1".Equals(UtilesBD.GetStringFromReader("Conectado", reader)) ? true : false);

                    usuario.Descripcion = UtilesBD.GetStringFromReader("Descripcion", reader);

                    usuario.Email = UtilesBD.GetStringFromReader("Email", reader);

                    usuario.Password = UtilesBD.GetStringFromReader("Password", reader);

                    usuario.Pregunta = UtilesBD.GetStringFromReader("Pregunta", reader);

                    usuario.Respuesta = UtilesBD.GetStringFromReader("Respuesta", reader);

                    usuario.Coordenadas = UtilesBD.GetStringFromReader("Coordenadas", reader);

                    usuario.Grupo = new Grupo { Id = UtilesBD.GetIntFromReader("FK_Id_Sitio", reader) };

                    usuario.FechaRegistro = (DateTime)UtilesBD.GetDateTimeFromReader("FechaRegistro", reader);
                    
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
        
        public Usuario ObtenerPorEmailPassYGrupo(string email, string pass, int idGrupo, SqlConnection conexion)
        {
            SqlDataReader reader = null;

            try
            {
                command = conexion.CreateCommand();

                command.Connection = conexion;

                command.CommandText = "SELECT * FROM Usuario WHERE Email = @email and Password = @pass and FK_Id_Sitio = @idSitio and Eliminado = 0";

                UtilesBD.SetParameter(command, "email", email);

                UtilesBD.SetParameter(command, "pass", pass);

                UtilesBD.SetParameter(command, "idSitio", idGrupo);

                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Usuario usuario = new Usuario();

                    usuario.Id = UtilesBD.GetIntFromReader("Id", reader);

                    usuario.Nombre = UtilesBD.GetStringFromReader("Nombre", reader);

                    usuario.Apellido = UtilesBD.GetStringFromReader("Apellido", reader);

                    usuario.Conectado = ("1".Equals(UtilesBD.GetStringFromReader("Conectado", reader)) ? true : false);

                    usuario.Descripcion = UtilesBD.GetStringFromReader("Descripcion", reader);

                    usuario.Email = UtilesBD.GetStringFromReader("Email", reader);

                    usuario.Password = UtilesBD.GetStringFromReader("Password", reader);

                    usuario.Pregunta = UtilesBD.GetStringFromReader("Pregunta", reader);

                    usuario.Respuesta = UtilesBD.GetStringFromReader("Respuesta", reader);

                    usuario.Coordenadas = UtilesBD.GetStringFromReader("Coordenadas", reader);

                    usuario.Grupo = GrupoADO.Obtener(UtilesBD.GetIntFromReader("FK_Id_Sitio", reader), conexion);

                    usuario.FechaRegistro = (DateTime) UtilesBD.GetDateTimeFromReader("FechaRegistro", reader);

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

        public List<Usuario> ObtenerUsuariosAgrupandoFechaRegistro(int idGrupo, SqlConnection conexion, SqlTransaction transaccion = null)
        {
            SqlDataReader reader = reader = null;

            List<Usuario> listaUsuarioGrupo = new List<Usuario>();

            try
            {
                command = conexion.CreateCommand();

                if (transaccion != null)
                {
                    command.Transaction = transaccion;
                }

                command.Connection = conexion;

                command.CommandText = "Select CONVERT (varchar(10), U.FechaRegistro, 120), U.Nombre from [IndignadoFDb].[dbo].[Usuario] AS U where U.FK_Id_Sitio = '@id' group by CONVERT (varchar(10), U.FechaRegistro, 120), U.Nombre";

                command.Parameters.AddWithValue("id", idGrupo);

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Usuario usuario = new Usuario();

                    usuario.Id = UtilesBD.GetIntFromReader("Id", reader);

                    usuario.Nombre = UtilesBD.GetStringFromReader("Nombre", reader);

                    usuario.Apellido = UtilesBD.GetStringFromReader("Apellido", reader);

                    usuario.Conectado = ("1".Equals(UtilesBD.GetStringFromReader("Conectado", reader)) ? true : false);

                    usuario.Descripcion = UtilesBD.GetStringFromReader("Descripcion", reader);

                    usuario.Email = UtilesBD.GetStringFromReader("Email", reader);

                    usuario.Password = UtilesBD.GetStringFromReader("Password", reader);

                    usuario.Pregunta = UtilesBD.GetStringFromReader("Pregunta", reader);

                    usuario.Respuesta = UtilesBD.GetStringFromReader("Respuesta", reader);

                    usuario.Coordenadas = UtilesBD.GetStringFromReader("Coordenadas", reader);

                    usuario.FechaRegistro = (DateTime)UtilesBD.GetDateTimeFromReader("FechaRegistro", reader);

                    listaUsuarioGrupo.Add(usuario);
                }
                return listaUsuarioGrupo;

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

