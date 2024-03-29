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
    public class NotificacionADO : INotificacionADO
    {
        private SqlCommand command;    

        //DEPENDENCIAS
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

        private IConvocatoriaADO _convocatoriaADO;
        protected IConvocatoriaADO ConvocatoriaADO
        {
            get
            {
                if (_convocatoriaADO == null)
                {
                    _convocatoriaADO = new ConvocatoriaADO();
                }

                return _convocatoriaADO;
            }
        }
        
        public void Crear(Notificacion notificacion, SqlConnection conexion, SqlTransaction transaccion)
        {
            command = conexion.CreateCommand();

            command.Transaction = transaccion;

            command.Connection = conexion;

            command.CommandText = " insert into Notificacion(Contenido, Visto, FK_Id_Convocatoria, Fk_Id_Usuario, FechaCreacion) " +
                                  " values(@contenido, @visto, @idConvocatoria, @idUsuario, @fechaCreacion); " +
                                  " select @idGen = SCOPE_IDENTITY() FROM Notificacion; ";

            UtilesBD.SetParameter(command, "contenido", notificacion.Contenido);
            UtilesBD.SetParameter(command, "visto", notificacion.Visto);
            UtilesBD.SetParameter(command, "idConvocatoria", notificacion.Convocatoria.Id);
            UtilesBD.SetParameter(command, "idUsuario", notificacion.Usuario.Id);
            UtilesBD.SetParameter(command, "fechaCreacion", notificacion.FechaCreacion);

            // indico que la query tiene un parámetro de salida thisId de tipo int
            command.Parameters.Add("@idGen", SqlDbType.Int).Direction = ParameterDirection.Output;

            command.ExecuteScalar();

            // este es el identificador generado
            notificacion.Id = (int)command.Parameters["@idGen"].Value;
        }

        public void Editar(Notificacion notificacion, SqlConnection conexion, SqlTransaction transaccion)
        {
            command = conexion.CreateCommand();

            command.Transaction = transaccion;

            command.Connection = conexion;

            command.CommandText = " UPDATE Notificacion SET " +
                                  " Contenido = @contenido, " +
                                  " Visto = @visto" +                                  
                                  " WHERE Id = @id";

            UtilesBD.SetParameter(command, "id", notificacion.Id);
            UtilesBD.SetParameter(command, "contenido", notificacion.Contenido);
            UtilesBD.SetParameter(command, "visto", notificacion.Visto);
            
            command.ExecuteNonQuery();
        }

        public void Eliminar(int id, SqlConnection conexion, SqlTransaction transaccion)
        {
            command = conexion.CreateCommand();

            command.Transaction = transaccion;

            command.Connection = conexion;

            command.CommandText = "DELETE FROM Notificacion WHERE Id = @id";

            UtilesBD.SetParameter(command, "id", id);

            command.ExecuteNonQuery();
        }

        public Notificacion Obtener(int id, SqlConnection conexion)
        {
            SqlDataReader reader = null;

            try
            {
                command = conexion.CreateCommand();

                command.Connection = conexion;

                command.CommandText = "select * from Notificacion where Id = @id";

                UtilesBD.SetParameter(command, "id", id);

                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Notificacion notificacion = new Notificacion();

                    notificacion.Id = UtilesBD.GetIntFromReader("id", reader);

                    notificacion.Contenido = UtilesBD.GetStringFromReader("Contenido", reader);

                    notificacion.Visto = UtilesBD.GetBoolFromReader("Visto", reader);

                    notificacion.FechaCreacion = UtilesBD.GetDateTimeFromReader("FechaCreacion", reader);

                    notificacion.Usuario = UsuarioADO.Obtener(UtilesBD.GetIntFromReader("FK_Id_Usuario", reader), conexion);

                    notificacion.Convocatoria = ConvocatoriaADO.Obtener(UtilesBD.GetIntFromReader("FK_Id_Convocatoria", reader), conexion);

                    return notificacion;
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

        public List<Notificacion> ObtenerListado(SqlConnection conexion)
        {
            SqlDataReader reader = null;

            List<Notificacion> listaNotificaciones = new List<Notificacion>();

            try
            {
                command = conexion.CreateCommand();

                command.Connection = conexion;

                command.CommandText = "SELECT * FROM Notificacion";

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Notificacion notificacion = new Notificacion();

                    notificacion.Id = UtilesBD.GetIntFromReader("id", reader);

                    notificacion.Contenido = UtilesBD.GetStringFromReader("Contenido", reader);

                    notificacion.Visto = UtilesBD.GetBoolFromReader("Visto", reader);

                    notificacion.FechaCreacion = UtilesBD.GetDateTimeFromReader("FechaCreacion", reader);

                    notificacion.Usuario = UsuarioADO.Obtener(UtilesBD.GetIntFromReader("FK_Id_Usuario", reader), conexion);

                    notificacion.Convocatoria = ConvocatoriaADO.Obtener(UtilesBD.GetIntFromReader("FK_Id_Convocatoria", reader), conexion);

                    listaNotificaciones.Add(notificacion);
                }

                return listaNotificaciones;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }

        public List<Notificacion> ObtenerListadoPorUsuario(SqlConnection conexion, int idUsuario)
        {
            SqlDataReader reader = null;

            List<Notificacion> listaNotificaciones = new List<Notificacion>();

            try
            {
                command = conexion.CreateCommand();

                command.Connection = conexion;

                command.CommandText = "SELECT * FROM Notificacion n where n.FK_Id_Usuario = @idUsuario";

                UtilesBD.SetParameter(command, "idUsuario", idUsuario);

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Notificacion notificacion = new Notificacion();

                    notificacion.Id = UtilesBD.GetIntFromReader("id", reader);

                    notificacion.Contenido = UtilesBD.GetStringFromReader("Contenido", reader);

                    notificacion.Visto = UtilesBD.GetBoolFromReader("Visto", reader);

                    notificacion.FechaCreacion = UtilesBD.GetDateTimeFromReader("FechaCreacion", reader);

                    notificacion.Usuario = UsuarioADO.Obtener(UtilesBD.GetIntFromReader("FK_Id_Usuario", reader), conexion);

                    notificacion.Convocatoria = ConvocatoriaADO.Obtener(UtilesBD.GetIntFromReader("FK_Id_Convocatoria", reader), conexion);

                    listaNotificaciones.Add(notificacion);
                }

                return listaNotificaciones;
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
