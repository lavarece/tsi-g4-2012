using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.Common.Entities;
using System.Data.SqlClient;

namespace IndignaFwk.Persistence.DataAccess
{
    public class AsistenciaConvocatoriaADO : IAsistenciaConvocatoriaADO
    {
        private SqlCommand command;

        public int Crear(AsistenciaConvocatoria asistenciaC, SqlConnection conexion, SqlTransaction transaccion)
        {
            command = conexion.CreateCommand();
            command.Transaction = transaccion;
            command.Connection = conexion;

            command.CommandText = "INSERT INTO AsistenciaConvocatoria (Convocatoria, Usuario) values(@Convocatoria, @Usuario)";

            command.Parameters.AddWithValue("Convocatoria", asistenciaC.Convocatoria);
            command.Parameters.AddWithValue("Usuario", asistenciaC.Usuario);
          
            command.ExecuteNonQuery();

            return 0;
        }


        public void Editar(AsistenciaConvocatoria asistenciaC, SqlConnection conexion, SqlTransaction transaccion)
        {

            command = conexion.CreateCommand();
            command.Transaction = transaccion;
            command.Connection = conexion;

            command.CommandText = "UPDATE AsistenciaConvocatoria SET Convocatoria = @convocatoria, Usuario = @usuario WHERE Id = @id";

            command.Parameters.AddWithValue("Id", asistenciaC.Id);
            command.Parameters.AddWithValue("Convocatoria", asistenciaC.Convocatoria);
            command.Parameters.AddWithValue("Usuario", asistenciaC.Usuario);
          
            command.ExecuteNonQuery();
        }


        public void Eliminar(int id, SqlConnection conexion, SqlTransaction transaccion)
        {
            command = conexion.CreateCommand();
            command.Transaction = transaccion;
            command.Connection = conexion;

            command.CommandText = "DELETE FROM AsistenciaConvocatoria WHERE Id = @id";

            command.Parameters.AddWithValue("id", id);

            command.ExecuteNonQuery();
        }


        public AsistenciaConvocatoria Obtener(int id, SqlConnection conexion)
        {

            SqlDataReader reader = null;

            AsistenciaConvocatoria asistenciaC = new AsistenciaConvocatoria();

            try
            {
                command = conexion.CreateCommand();
                command.Connection = conexion;

                command.CommandText = "SELECT * FROM AsistenciaConvocatoria WHERE Id = @id";

                SqlParameter param = new SqlParameter();

                param.ParameterName = "@id";

                param.Value = id;

                command.Parameters.Add(param);

                reader = command.ExecuteReader();

                bool encontrado = false;

                while ((reader.Read()) && (!encontrado))
                {
                    asistenciaC.Id = ((int)reader["Id"]);
                    asistenciaC.Convocatoria = ((Convocatoria)reader["Convocatoria"]);
                    asistenciaC.Usuario = ((Usuario)reader["Usuario"]);
                   
                    if (((int)reader["Id"]) == id)
                    {
                        encontrado = true;
                    }
                }

                return asistenciaC;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }


        public List<AsistenciaConvocatoria> ObtenerListado(SqlConnection conexion, SqlTransaction transaccion)
        {
            SqlDataReader reader = null;

            List<AsistenciaConvocatoria> _asistenciaC = new List<AsistenciaConvocatoria>();

            try
            {
                command = conexion.CreateCommand();
                command.Transaction = transaccion;
                command.Connection = conexion;

                command.CommandText = "SELECT * FROM AsistenciaConvocatoria";

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    AsistenciaConvocatoria varAsistenciaC = new AsistenciaConvocatoria();

                    varAsistenciaC.Id = ((int)reader["Id"]);
                    varAsistenciaC.Convocatoria = ((Convocatoria)reader["Convocatoria"]);
                    varAsistenciaC.Usuario = ((Usuario)reader["Usuario"]);

                    _asistenciaC.Add(varAsistenciaC);
                }

                return _asistenciaC;
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
