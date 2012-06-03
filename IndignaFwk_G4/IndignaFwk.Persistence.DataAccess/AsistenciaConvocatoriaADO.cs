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
    public class AsistenciaConvocatoriaADO : IAsistenciaConvocatoriaADO
    {
        private SqlCommand command;

        public int Crear(AsistenciaConvocatoria asistenciaConvocatoria, SqlConnection conexion, SqlTransaction transaccion)
        {
            command = conexion.CreateCommand();

            command.Transaction = transaccion;

            command.Connection = conexion;

            command.CommandText = "INSERT INTO AsistenciaConvocatoria (FK_Id_Convocatoria, Fk_Id_Usuario) " +
                                  "values(@idConvocatoria, @idUsuario); " + 
                                  "select @idGen = SCOPE_IDENTITY() FROM AsistenciaConvocatoria";
            
            UtilesBD.SetParameter(command, "idConvocatoria", asistenciaConvocatoria.Convocatoria.Id);

            UtilesBD.SetParameter(command, "idUsuario", asistenciaConvocatoria.Usuario.Id);

            command.Parameters.Add("@idGen", SqlDbType.Int).Direction = ParameterDirection.Output;

            command.ExecuteScalar();

            return (int) command.Parameters["@idGen"].Value;
        }

        public void Editar(AsistenciaConvocatoria asistenciaConvocatoria, SqlConnection conexion, SqlTransaction transaccion)
        {
            command = conexion.CreateCommand();

            command.Transaction = transaccion;

            command.Connection = conexion;

            command.CommandText = "UPDATE AsistenciaConvocatoria SET " + 
                                  "FK_Id_Convocatoria = @idConvocatoria, " +
                                  "FK_Id_Usuario = @idUsuario " + 
                                  "WHERE Id = @id";

            UtilesBD.SetParameter(command, "id", asistenciaConvocatoria.Id);

            UtilesBD.SetParameter(command, "idConvocatoria", asistenciaConvocatoria.Convocatoria.Id);

            UtilesBD.SetParameter(command, "idUsuario", asistenciaConvocatoria.Usuario.Id);
          
            command.ExecuteNonQuery();
        }
    
        public void Eliminar(int id, SqlConnection conexion, SqlTransaction transaccion)
        {
            command = conexion.CreateCommand();

            command.Transaction = transaccion;

            command.Connection = conexion;

            command.CommandText = "DELETE FROM AsistenciaConvocatoria WHERE Id = @id";

            UtilesBD.SetParameter(command, "id", id);

            command.ExecuteNonQuery();
        }

        public AsistenciaConvocatoria Obtener(int id, SqlConnection conexion)
        {
            SqlDataReader reader = null;

            try
            {
                command = conexion.CreateCommand();

                command.Connection = conexion;

                command.CommandText = "SELECT * FROM AsistenciaConvocatoria WHERE Id = @id";

                UtilesBD.SetParameter(command, "id", id);

                reader = command.ExecuteReader();

                if(reader.Read())
                {
                    AsistenciaConvocatoria asistenciaC = new AsistenciaConvocatoria();

                    asistenciaC.Id = UtilesBD.GetIntFromReader("id", reader);

                    asistenciaC.Convocatoria = new Convocatoria { Id = UtilesBD.GetIntFromReader("FK_Id_Convocatoria", reader) };

                    asistenciaC.Usuario = new Usuario { Id = UtilesBD.GetIntFromReader("FK_Id_Usuario", reader) };

                    return asistenciaC;
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

        public List <AsistenciaConvocatoria> ObtenerListadoPorIdUsuario(int idUsuario, SqlConnection conexion)
        {
            SqlDataReader reader = null;

            List<AsistenciaConvocatoria> listaAsistenciaC = new List<AsistenciaConvocatoria>();

            try
            {
                command = conexion.CreateCommand();

                command.Connection = conexion;

                command.CommandText = "SELECT * FROM AsistenciaConvocatoria WHERE FK_Id_Usuario = @idUsuario";

                UtilesBD.SetParameter(command, "idUsuario", idUsuario);

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    AsistenciaConvocatoria asistenciaC = new AsistenciaConvocatoria();

                    asistenciaC.Id = UtilesBD.GetIntFromReader("id", reader);

                    asistenciaC.Convocatoria = new Convocatoria { Id = UtilesBD.GetIntFromReader("FK_Id_Convocatoria", reader) };

                    asistenciaC.Usuario = new Usuario { Id = UtilesBD.GetIntFromReader("FK_Id_Usuario", reader) };

                    listaAsistenciaC.Add(asistenciaC);
                }

                return listaAsistenciaC;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }


        public AsistenciaConvocatoria ObtenerPorUsuarioYConvocatoria(int idUsuario, int idConvocatoria, SqlConnection conexion)
        {
            SqlDataReader reader = null;

            try
            {
                command = conexion.CreateCommand();

                command.Connection = conexion;

                command.CommandText = "SELECT * FROM AsistenciaConvocatoria WHERE FK_Id_Usuario = @idUsuario and FK_Id_Convocatoria = @idConvocatoria ";

                UtilesBD.SetParameter(command, "idUsuario", idUsuario);

                UtilesBD.SetParameter(command, "idConvocatoria", idConvocatoria);

                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    AsistenciaConvocatoria asistenciaC = new AsistenciaConvocatoria();

                    asistenciaC.Id = UtilesBD.GetIntFromReader("id", reader);

                    asistenciaC.Convocatoria = new Convocatoria { Id = UtilesBD.GetIntFromReader("FK_Id_Convocatoria", reader) };

                    asistenciaC.Usuario = new Usuario { Id = UtilesBD.GetIntFromReader("FK_Id_Usuario", reader) };

                    return asistenciaC;
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

        public List<AsistenciaConvocatoria> ObtenerListado(SqlConnection conexion)
        {
            SqlDataReader reader = null;

            List<AsistenciaConvocatoria> listaAsistenciaC = new List<AsistenciaConvocatoria>();

            try
            {
                command = conexion.CreateCommand();

                command.Connection = conexion;

                command.CommandText = "SELECT * FROM AsistenciaConvocatoria";

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    AsistenciaConvocatoria asistenciaC = new AsistenciaConvocatoria();

                    asistenciaC.Id = UtilesBD.GetIntFromReader("id", reader);

                    asistenciaC.Convocatoria = new Convocatoria { Id = UtilesBD.GetIntFromReader("FK_Id_Convocatoria", reader) };

                    asistenciaC.Usuario = new Usuario { Id = UtilesBD.GetIntFromReader("FK_Id_Usuario", reader) };

                    listaAsistenciaC.Add(asistenciaC);
                }

                return listaAsistenciaC;
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
