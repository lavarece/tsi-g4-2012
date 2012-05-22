using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.Common.Entities;
using System.Data.SqlClient;

namespace IndignaFwk.Persistence.DataAccess
{
    public class UsuTematicaADO : IUsuTematicaADO
    {

        private SqlCommand command;

        public int Crear(UsuTematica usuTem, SqlConnection conexion, SqlTransaction transaccion)
        {
            command = conexion.CreateCommand();
            command.Transaction = transaccion;
            command.Connection = conexion;

            command.CommandText = "INSERT INTO UsuTematica (Tematica, Usuario) values(@Tematica, @Usuario)";

            command.Parameters.AddWithValue("Temarica", usuTem.Tematica);
            command.Parameters.AddWithValue("Usuario", usuTem.Usuario);
         
            command.ExecuteNonQuery();

            return 0;
        }

        //----------------------------------------------------------------------------------------------
        public void Editar(UsuTematica usuTem, SqlConnection conexion, SqlTransaction transaccion)
        {

            command = conexion.CreateCommand();
            command.Transaction = transaccion;
            command.Connection = conexion;

            command.CommandText = "UPDATE UsuTematica SET Tematica = @tematica, Usuario = @usuario WHERE Id = @id";

            command.Parameters.AddWithValue("Id", usuTem.Id);
            command.Parameters.AddWithValue("Tematica", usuTem.Tematica);
            command.Parameters.AddWithValue("Usuario", usuTem.Usuario);
            
            command.ExecuteNonQuery();
        }

        //------------------------------------------------------------------------------------------------
        public void Eliminar(int id, SqlConnection conexion, SqlTransaction transaccion)
        {
            command = conexion.CreateCommand();
            command.Transaction = transaccion;
            command.Connection = conexion;

            command.CommandText = "DELETE FROM UsuTematica WHERE Id = @id";

            command.Parameters.AddWithValue("id", id);

            command.ExecuteNonQuery();
        }

        //-------------------------------------------------------------------------------------------------
        public UsuTematica Obtener(int id, SqlConnection conexion)
        {

            SqlDataReader reader = null;

            UsuTematica usuTem = new UsuTematica();

            try
            {
                command = conexion.CreateCommand();
                command.Connection = conexion;

                command.CommandText = "SELECT * FROM UsuTematica WHERE Id = @id";

                SqlParameter param = new SqlParameter();

                param.ParameterName = "@id";

                param.Value = id;

                command.Parameters.Add(param);

                reader = command.ExecuteReader();

                bool encontrado = false;

                while ((reader.Read()) && (!encontrado))
                {
                    usuTem.Id = ((int)reader["Id"]);
                    usuTem.Usuario = ((Usuario)reader["Usuario"]);
                    usuTem.Tematica = ((Tematica)reader["Tematica"]);
                    
                    if (((int)reader["Id"]) == id)
                    {
                        encontrado = true;
                    }
                }

                return usuTem;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }

        //-----------------------------------------------------------------------------------------------
        public List<UsuTematica> ObtenerListado(SqlConnection conexion, SqlTransaction transaccion)
        {
            SqlDataReader reader = null;

            List<UsuTematica> _usuTem = new List<UsuTematica>();

            try
            {
                command = conexion.CreateCommand();
                command.Transaction = transaccion;
                command.Connection = conexion;

                command.CommandText = "SELECT * FROM UsuTematica";

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    UsuTematica varUsuTem = new UsuTematica();

                    varUsuTem.Id = ((int)reader["Id"]);
                    varUsuTem.Usuario = ((Usuario)reader["Usuario"]);
                    varUsuTem.Tematica = ((Tematica)reader["Tematica"]);

                    _usuTem.Add(varUsuTem);
                }

                return _usuTem;
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
