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
    public class ConvocatoriaADO : IConvocatoriaADO
    {
        private SqlCommand command;

        public int Crear(Convocatoria convocatoria, SqlConnection conexion, SqlTransaction transaccion)
        {
            command = conexion.CreateCommand();

            command.Transaction = transaccion;

            command.Connection = conexion;

            command.CommandText = "INSERT INTO Convocatoria (Titulo, LogoUrl, Descripcion, Quorum, Coordenadas, FechaInicio, FechaFin, FK_Id_UsuarioCreacion, FK_Id_Sitio) " +
                                  "values(@Titulo, @LogoUrl, @Descripcion, @Quorum, @Coordenadas, @FechaInicio, @FechaFin, @IdUsuarioCreacion, @IdSitio); " +
                                  "select @idGen = SCOPE_IDENTITY() FROM Convocatoria ";

            UtilesBD.SetParameter(command, "Titulo", convocatoria.Titulo);
            UtilesBD.SetParameter(command, "Descripcion", convocatoria.Descripcion);
            UtilesBD.SetParameter(command, "Quorum", convocatoria.Quorum);            
            UtilesBD.SetParameter(command, "Coordenadas", convocatoria.Coordenadas);            
            UtilesBD.SetParameter(command, "LogoUrl", convocatoria.LogoUrl);
            UtilesBD.SetParameter(command, "FechaInicio", convocatoria.FechaInicio);
            UtilesBD.SetParameter(command, "FechaFin", convocatoria.FechaFin);
            UtilesBD.SetParameter(command, "IdUsuarioCreacion", convocatoria.UsuarioCreacion.Id);
            UtilesBD.SetParameter(command, "IdSitio", convocatoria.Grupo.Id);
            
            // indico que la query tiene un parámetro de salida thisId de tipo int
            command.Parameters.Add("@idGen", SqlDbType.Int).Direction = ParameterDirection.Output;

            command.ExecuteScalar();

            // este es el identificador generado
            return (int)command.Parameters["@idGen"].Value;
        }

        public void Editar(Convocatoria convocatoria, SqlConnection conexion, SqlTransaction transaccion)
        {
            command = conexion.CreateCommand();

            command.Transaction = transaccion;

            command.Connection = conexion;

            command.CommandText = "UPDATE Convocatoria SET " + 
                                  "Titulo = @titulo, " + 
                                  "LogoUrl = @logoUrl, " +
                                  "Descripción = @descripcion, " +
                                  "Quorum = @quorum, " +                                   
                                  "Coordenada = @coordenada " +
                                  "FechaInicio = @fechaInicio" +
                                  "FechaFin = @fechaFin" +
                                  "WHERE Id = @id";

            UtilesBD.SetParameter(command, "titulo", convocatoria.Titulo);
            UtilesBD.SetParameter(command, "logoUrl", convocatoria.LogoUrl);
            UtilesBD.SetParameter(command, "descripcion", convocatoria.Descripcion);
            UtilesBD.SetParameter(command, "quorum", convocatoria.Quorum);
            UtilesBD.SetParameter(command, "coordenada", convocatoria.Coordenadas);
            UtilesBD.SetParameter(command, "fechaInicio", convocatoria.FechaInicio);
            UtilesBD.SetParameter(command, "fechaFin", convocatoria.FechaFin);
            UtilesBD.SetParameter(command, "id", convocatoria.Id);
           
            command.ExecuteNonQuery();
        }

        public void Eliminar(int id, SqlConnection conexion, SqlTransaction transaccion)
        {
            command = conexion.CreateCommand();

            command.Transaction = transaccion;

            command.Connection = conexion;

            command.CommandText = "DELETE FROM Convocatoria WHERE Id = @id";

            UtilesBD.SetParameter(command, "id", id);

            command.ExecuteNonQuery();
        }

        public Convocatoria Obtener(int id, SqlConnection conexion)
        {
            SqlDataReader reader = null;

            try
            {
                command = conexion.CreateCommand();

                command.Connection = conexion;

                command.CommandText = "SELECT * FROM Convocatoria WHERE Id = @id";

                UtilesBD.SetParameter(command, "id", id);

                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Convocatoria convocatoria = new Convocatoria();

                    convocatoria.Id = UtilesBD.GetIntFromReader("Id", reader);
                    convocatoria.Titulo = UtilesBD.GetStringFromReader("Titulo", reader);                    
                    convocatoria.Descripcion = UtilesBD.GetStringFromReader("Descripcion", reader);
                    convocatoria.Quorum = UtilesBD.GetIntFromReader("Quorum", reader);
                    convocatoria.Coordenadas = UtilesBD.GetStringFromReader("Coordenadas", reader);
                    convocatoria.LogoUrl = UtilesBD.GetStringFromReader("LogoUrl", reader);                                        
                    convocatoria.FechaInicio = UtilesBD.GetDateTimeFromReader("FechaInicio", reader);
                    convocatoria.FechaFin = UtilesBD.GetDateTimeFromReader("FechaFin", reader);
                    convocatoria.Grupo = new Grupo { Id = UtilesBD.GetIntFromReader("FK_Id_Sitio", reader) };
                    convocatoria.UsuarioCreacion = new Usuario { Id = UtilesBD.GetIntFromReader("FK_Id_UsuarioCreacion", reader) };
                    
                    return convocatoria;
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

        public List<Convocatoria> ObtenerListado(SqlConnection conexion)
        {
            SqlDataReader reader = null;

            List<Convocatoria> listaConvocatorias = new List<Convocatoria>();

            try
            {
                command = conexion.CreateCommand();

                command.Connection = conexion;

                command.CommandText = "SELECT * FROM Convocatoria";

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Convocatoria convocatoria = new Convocatoria();

                    convocatoria.Id = UtilesBD.GetIntFromReader("Id", reader);
                    convocatoria.Titulo = UtilesBD.GetStringFromReader("Titulo", reader);
                    convocatoria.Descripcion = UtilesBD.GetStringFromReader("Descripcion", reader);
                    convocatoria.Quorum = UtilesBD.GetIntFromReader("Quorum", reader);
                    convocatoria.Coordenadas = UtilesBD.GetStringFromReader("Coordenadas", reader);
                    convocatoria.LogoUrl = UtilesBD.GetStringFromReader("LogoUrl", reader);
                    convocatoria.FechaInicio = UtilesBD.GetDateTimeFromReader("FechaInicio", reader);
                    convocatoria.FechaFin = UtilesBD.GetDateTimeFromReader("FechaFin", reader);
                    convocatoria.Grupo = new Grupo { Id = UtilesBD.GetIntFromReader("FK_Id_Sitio", reader) };
                    convocatoria.UsuarioCreacion = new Usuario { Id = UtilesBD.GetIntFromReader("FK_Id_UsuarioCreacion", reader) };

                    listaConvocatorias.Add(convocatoria);
                }

                return listaConvocatorias;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }

        public List<Convocatoria> ObtenerListadoPorGrupo(SqlConnection conexion, int idGrupo)
        {
            SqlDataReader reader = null;

            List<Convocatoria> listaConvocatorias = new List<Convocatoria>();

            try
            {
                command = conexion.CreateCommand();

                command.Connection = conexion;

                command.CommandText = "SELECT * FROM Convocatoria c where c.FK_Id_Sitio = @idGrupo";

                UtilesBD.SetParameter(command, "idGrupo", idGrupo);

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Convocatoria convocatoria = new Convocatoria();

                    convocatoria.Id = UtilesBD.GetIntFromReader("Id", reader);
                    convocatoria.Titulo = UtilesBD.GetStringFromReader("Titulo", reader);
                    convocatoria.Descripcion = UtilesBD.GetStringFromReader("Descripcion", reader);
                    convocatoria.Quorum = UtilesBD.GetIntFromReader("Quorum", reader);
                    convocatoria.Coordenadas = UtilesBD.GetStringFromReader("Coordenadas", reader);
                    convocatoria.LogoUrl = UtilesBD.GetStringFromReader("LogoUrl", reader);
                    convocatoria.FechaInicio = UtilesBD.GetDateTimeFromReader("FechaInicio", reader);
                    convocatoria.FechaFin = UtilesBD.GetDateTimeFromReader("FechaFin", reader);
                    convocatoria.Grupo = new Grupo { Id = UtilesBD.GetIntFromReader("FK_Id_Sitio", reader) };
                    convocatoria.UsuarioCreacion = new Usuario { Id = UtilesBD.GetIntFromReader("FK_Id_UsuarioCreacion", reader) };

                    listaConvocatorias.Add(convocatoria);
                }

                return listaConvocatorias;
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
