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
    public class ContenidoADO : IContenidoADO
    {
        private SqlCommand command;

        public int Crear(Contenido contenido, SqlConnection conexion, SqlTransaction transaccion)
        {
            command = conexion.CreateCommand();

            command.Transaction = transaccion;

            command.Connection = conexion;

            command.CommandText = "INSERT INTO Contenido(Titulo, Comentario, Url, NivelVisibilidad, TipoContenido, FechaCreacion, FK_Id_UsuarioCreacion) " +
                                  "values(@titulo, @comentario, @url, @nivelVisibilidad, @tipoContenido, @fechaCreacion, @idUsuarioCreacion);" +
                                  "select @idGen = SCOPE_IDENTITY() FROM Contenido;";

            UtilesBD.SetParameter(command, "titulo", contenido.Titulo);
            UtilesBD.SetParameter(command, "comentario", contenido.Comentario);
            UtilesBD.SetParameter(command, "url", contenido.Url);
            UtilesBD.SetParameter(command, "nivelVisibilidad", contenido.NivelVisibilidad);
            UtilesBD.SetParameter(command, "tipoContenido", contenido.TipoContenido);
            UtilesBD.SetParameter(command, "fechaCreacion", contenido.FechaCreacion);
            UtilesBD.SetParameter(command, "idUsuarioCreacion", contenido.UsuarioCreacion.Id);

            command.Parameters.Add("@idGen", SqlDbType.Int).Direction = ParameterDirection.Output;

            command.ExecuteScalar();

            return (int)command.Parameters["@idGen"].Value;            
        }

        public void Editar(Contenido contenido, SqlConnection conexion, SqlTransaction transaccion)
        {
            command = conexion.CreateCommand();

            command.Transaction = transaccion;

            command.Connection = conexion;
            
            command.CommandText = ("UPDATE Contenido " + 
                                   "SET Titulo = @titulo, " +
                                   "Comentario = @comentario, " + 
                                   "Url = @url, " + 
                                   "NivelVisibilidad = @nivelVisibilidad, " + 
                                   "TipoContenido = @tipoContenido " + 
                                   "WHERE Id = @id");

            UtilesBD.SetParameter(command, "Id", contenido.Id);
            UtilesBD.SetParameter(command, "titulo", contenido.Titulo);
            UtilesBD.SetParameter(command, "comentario", contenido.Comentario);
            UtilesBD.SetParameter(command, "url", contenido.Url);
            UtilesBD.SetParameter(command, "nivelVisibilidad", contenido.NivelVisibilidad);
            UtilesBD.SetParameter(command, "tipoContenido", contenido.TipoContenido);

            command.ExecuteNonQuery();
        }

        public void Eliminar(int id, SqlConnection conexion, SqlTransaction transaccion)
        {
            command = conexion.CreateCommand();

            command.Transaction = transaccion;

            command.Connection = conexion;
            
            command.CommandText = "DELETE FROM Contenido WHERE Id = @id";
            
            UtilesBD.SetParameter(command, "id", id);

            command.ExecuteNonQuery();            
        }

        public Contenido Obtener(int id, SqlConnection conexion)
        {
            SqlDataReader reader = null;

            try
            {
                command = conexion.CreateCommand();

                command.Connection = conexion;
                
                command.CommandText = "SELECT * FROM Contenido WHERE Id = @id";

                UtilesBD.SetParameter(command, "id", id);

                reader = command.ExecuteReader();

                if(reader.Read())
                {
                    Contenido contenido = new Contenido();

                    contenido.Id = UtilesBD.GetIntFromReader("Id", reader);

                    contenido.Titulo = UtilesBD.GetStringFromReader("Titulo", reader);

                    contenido.Comentario = UtilesBD.GetStringFromReader("Comentario", reader);

                    contenido.Url = UtilesBD.GetStringFromReader("Url", reader);

                    contenido.NivelVisibilidad = UtilesBD.GetStringFromReader("NivelVisibilidad", reader);

                    contenido.TipoContenido = UtilesBD.GetStringFromReader("TipoContenido", reader);

                    contenido.FechaCreacion = UtilesBD.GetDateTimeFromReader("FechaCreacion", reader);

                    contenido.UsuarioCreacion = new Usuario { Id = UtilesBD.GetIntFromReader("FK_Id_UsuarioCreacion", reader) };

                    return contenido;
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

        public List<Contenido> ObtenerListado(SqlConnection conexion)
        {
            SqlDataReader reader = null;

            List<Contenido> listaContenido = new List<Contenido>();

            try
            {
                command = conexion.CreateCommand();

                command.Connection = conexion;

                command.CommandText = "SELECT * FROM Contenido";

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Contenido contenido = new Contenido();

                    contenido.Id = UtilesBD.GetIntFromReader("Id", reader);

                    contenido.Titulo = UtilesBD.GetStringFromReader("Titulo", reader);

                    contenido.Comentario = UtilesBD.GetStringFromReader("Comentario", reader);

                    contenido.Url = UtilesBD.GetStringFromReader("Url", reader);

                    contenido.NivelVisibilidad = UtilesBD.GetStringFromReader("NivelVisibilidad", reader);

                    contenido.TipoContenido = UtilesBD.GetStringFromReader("TipoContenido", reader);

                    contenido.FechaCreacion = UtilesBD.GetDateTimeFromReader("FechaCreacion", reader);

                    listaContenido.Add(contenido);
                }

                return listaContenido;
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