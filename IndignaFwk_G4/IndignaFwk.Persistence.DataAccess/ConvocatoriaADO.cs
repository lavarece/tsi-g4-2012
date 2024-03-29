﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.Common.Entities;
using System.Data.SqlClient;
using System.Data;
using IndignaFwk.Common.Util;
using IndignaFwk.Common.Filter;

namespace IndignaFwk.Persistence.DataAccess
{
    public class ConvocatoriaADO : IConvocatoriaADO
    {
        private SqlCommand command;

        // DEPENDENCIAS
        private IUsuarioADO _usuarioADO;
        protected IUsuarioADO UsuarioADO
        {
            get
            {
                if (_usuarioADO == null)
                {
                    _usuarioADO = new UsuarioADO();
                }

                return _usuarioADO;
            }
        }

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

        public void Crear(Convocatoria convocatoria, SqlConnection conexion, SqlTransaction transaccion)
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
            convocatoria.Id = (int)command.Parameters["@idGen"].Value;
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

                StringBuilder sbQuery = new StringBuilder();

                sbQuery.Append(" SELECT c.*, ")
                       .Append(" (select count(ac.Id) from AsistenciaConvocatoria ac where ac.FK_Id_Convocatoria = c.Id) cantidadAsistencias ")
                       .Append(" FROM Convocatoria c WHERE c.Id = @id ");

                command.CommandText = sbQuery.ToString();

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
                    convocatoria.Grupo = GrupoADO.Obtener(UtilesBD.GetIntFromReader("FK_Id_Sitio", reader), conexion);
                    convocatoria.UsuarioCreacion = UsuarioADO.Obtener(UtilesBD.GetIntFromReader("FK_Id_UsuarioCreacion", reader), conexion);
                    convocatoria.CantidadAsistencias = UtilesBD.GetIntFromReader("cantidadAsistencias", reader);

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


        public List<Convocatoria> ObtenerConvocatoriasPorFiltro(FiltroBusqueda filtroBusqueda, SqlConnection conexion)
        {
            SqlDataReader reader = null;

            List<Convocatoria> listaConvocatorias = new List<Convocatoria>();

            try
            {
                command = conexion.CreateCommand();

                command.Connection = conexion;

                /* Consulta dinamica que devuelve una lista de convocatorias. Esta consulta varia dependiendo de
                 * los valores que se hayan ingresado en el filtro de busqueda de convocatorias.
                 */
                StringBuilder sbQuery = new StringBuilder();
                
                sbQuery.Append(" SELECT c.*, ")
                       .Append(" (select count(ac.Id) from AsistenciaConvocatoria ac where ac.FK_Id_Convocatoria = c.Id) cantidadAsistencias ")
                       .Append(" FROM Convocatoria c INNER JOIN Sitio s ON c.FK_Id_Sitio = s.Id ");

                if (filtroBusqueda.Asistire)
                {
                    sbQuery.Append(" INNER JOIN AsistenciaConvocatoria ac ON c.Id = ac.FK_Id_Convocatoria ");
                }

                sbQuery.Append(" WHERE @idGrupo = s.Id ");

                if (filtroBusqueda.Asistire)
                {
                    sbQuery.Append(" AND @idUsuario = ac.FK_Id_Usuario ");
                }

                if (filtroBusqueda.Titulo != null)
                {
                    sbQuery.Append(" AND @titulo = c.Titulo ");
                }

                if (filtroBusqueda.Descripcion != null)
                {
                    sbQuery.Append(" AND @descripcion = c.Descripcion ");
                }

                if (filtroBusqueda.Quorum != -1)
                {
                    sbQuery.Append(" AND @quorum = c.Quorum ");
                }

                if (filtroBusqueda.FechaInicio != null)
                {
                    sbQuery.Append(" AND @fechaInicio = c.FechaInicio ");
                }

                if (filtroBusqueda.FechaFin != null)
                {
                    sbQuery.Append(" AND @fechaFin = c.FechaFin ");
                }

                if (filtroBusqueda.Tematica != null)
                {
                    sbQuery.Append(" AND @tematica = s.FK_Id_Tematica ");                
                }

                //Seteo la consulta final en la variable command
                command.CommandText = sbQuery.ToString();
                

                //Referencio las variables utilizadas en la consulta con los atributos del filtro
                UtilesBD.SetParameter(command, "idGrupo", filtroBusqueda.IdGrupo);
                
                if (filtroBusqueda.Asistire)
                {
                    UtilesBD.SetParameter(command, "idUsuario", filtroBusqueda.IdUsuario);
                }

                if (filtroBusqueda.Titulo != null)
                {
                    UtilesBD.SetParameter(command, "titulo", filtroBusqueda.Titulo);
                }

                if (filtroBusqueda.Descripcion != null)
                {
                    UtilesBD.SetParameter(command, "descripcion", filtroBusqueda.Descripcion);
                }

                if (filtroBusqueda.Quorum != -1)
                {
                    UtilesBD.SetParameter(command, "quorum", filtroBusqueda.Quorum);
                }

                if (filtroBusqueda.FechaInicio != null)
                {
                    UtilesBD.SetParameter(command, "fechaInicio", filtroBusqueda.FechaInicio);
                }

                if (filtroBusqueda.FechaFin != null)
                {
                    UtilesBD.SetParameter(command, "fechaFin", filtroBusqueda.FechaFin);
                }

                if (filtroBusqueda.Tematica != null)
                {
                    UtilesBD.SetParameter(command, "tematica", filtroBusqueda.Tematica);
                }


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
                    convocatoria.Grupo = GrupoADO.Obtener(UtilesBD.GetIntFromReader("FK_Id_Sitio", reader), conexion);
                    convocatoria.UsuarioCreacion = UsuarioADO.Obtener(UtilesBD.GetIntFromReader("FK_Id_UsuarioCreacion", reader), conexion);
                    convocatoria.CantidadAsistencias = UtilesBD.GetIntFromReader("cantidadAsistencias", reader);

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


        public List<Convocatoria> ObtenerListado(SqlConnection conexion)
        {
            SqlDataReader reader = null;

            List<Convocatoria> listaConvocatorias = new List<Convocatoria>();

            try
            {
                command = conexion.CreateCommand();

                command.Connection = conexion;

                StringBuilder sbQuery = new StringBuilder();

                sbQuery.Append(" SELECT c.*, ")
                       .Append(" (select count(ac.Id) from AsistenciaConvocatoria ac where ac.FK_Id_Convocatoria = c.Id) cantidadAsistencias ")
                       .Append(" FROM Convocatoria c ");

                command.CommandText = sbQuery.ToString();

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
                    convocatoria.Grupo = GrupoADO.Obtener(UtilesBD.GetIntFromReader("FK_Id_Sitio", reader), conexion);
                    convocatoria.UsuarioCreacion = UsuarioADO.Obtener(UtilesBD.GetIntFromReader("FK_Id_UsuarioCreacion", reader), conexion);
                    convocatoria.CantidadAsistencias = UtilesBD.GetIntFromReader("cantidadAsistencias", reader);

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

                StringBuilder sbQuery = new StringBuilder();

                sbQuery.Append(" SELECT c.*, ")
                       .Append(" (select count(ac.Id) from AsistenciaConvocatoria ac where ac.FK_Id_Convocatoria = c.Id) cantidadAsistencias ")
                       .Append(" FROM Convocatoria c WHERE c.FK_Id_Sitio = @idGrupo ");

                command.CommandText = sbQuery.ToString();

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
                    convocatoria.Grupo = GrupoADO.Obtener(UtilesBD.GetIntFromReader("FK_Id_Sitio", reader), conexion);
                    convocatoria.UsuarioCreacion = UsuarioADO.Obtener(UtilesBD.GetIntFromReader("FK_Id_UsuarioCreacion", reader), conexion);
                    convocatoria.CantidadAsistencias = UtilesBD.GetIntFromReader("cantidadAsistencias", reader);

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

        public List<Convocatoria> ObtenerListadoPorTematica(int idTematica, SqlConnection conexion)
        {
            SqlDataReader reader = null;

            List<Convocatoria> listaConvocatorias = new List<Convocatoria>();

            try
            {
                command = conexion.CreateCommand();

                command.Connection = conexion;

                StringBuilder sbQuery = new StringBuilder();

                sbQuery.Append(" SELECT c.*, ")
                       .Append(" (select count(ac.Id) from AsistenciaConvocatoria ac where ac.FK_Id_Convocatoria = c.Id) cantidadAsistencias ")
                       .Append(" FROM Convocatoria c left join ")
                       .Append(" Sitio s on c.FK_Id_Sitio = s.Id ") 
                       .Append(" WHERE s.FK_Id_Tematica = @idTematica ");

                command.CommandText = sbQuery.ToString();

                UtilesBD.SetParameter(command, "idTematica", idTematica);

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
                    convocatoria.Grupo = GrupoADO.Obtener(UtilesBD.GetIntFromReader("FK_Id_Sitio", reader), conexion);
                    convocatoria.UsuarioCreacion = UsuarioADO.Obtener(UtilesBD.GetIntFromReader("FK_Id_UsuarioCreacion", reader), conexion);
                    convocatoria.CantidadAsistencias = UtilesBD.GetIntFromReader("cantidadAsistencias", reader);

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
