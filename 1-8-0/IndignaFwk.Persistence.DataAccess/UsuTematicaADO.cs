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
    public class UsuTematicaADO : IUsuTematicaADO
    {
        private SqlCommand command;

        public void Crear(UsuTematica usuTem, SqlConnection conexion, SqlTransaction transaccion)
        {
            command = conexion.CreateCommand();

            command.Transaction = transaccion;

            command.Connection = conexion;

            command.CommandText = "INSERT INTO UsuTematica (FK_Id_Tematica, FK_Id_Usuario) "+
                                  "values(@idTematica, @idUsuario); " +
                                  " select @idGen = SCOPE_IDENTITY() FROM UsuTematica; ";

            UtilesBD.SetParameter(command, "idTemarica", usuTem.Tematica.Id);
            UtilesBD.SetParameter(command, "idUsuario", usuTem.Usuario.Id);
         
            // indico que la query tiene un parámetro de salida thisId de tipo int
            command.Parameters.Add("@idGen", SqlDbType.Int).Direction = ParameterDirection.Output;

            command.ExecuteScalar();

            // este es el identificador generado
            usuTem.Id = (int)command.Parameters["@idGen"].Value;
        }
       
        public void Editar(UsuTematica usuTem, SqlConnection conexion, SqlTransaction transaccion)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(int id, SqlConnection conexion, SqlTransaction transaccion)
        {
            command = conexion.CreateCommand();

            command.Transaction = transaccion;

            command.Connection = conexion;

            command.CommandText = "DELETE FROM UsuTematica WHERE Id = @id";

            UtilesBD.SetParameter(command, "id", id);

            command.ExecuteNonQuery();
        }

        public UsuTematica Obtener(int id, SqlConnection conexion)
        {
            SqlDataReader reader = null;

            try
            {
                command = conexion.CreateCommand();

                command.Connection = conexion;

                command.CommandText = "SELECT * FROM UsuTematica WHERE Id = @id";

                UtilesBD.SetParameter(command, "id", id);

                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    UsuTematica usuTematica = new UsuTematica();

                    usuTematica.Id = UtilesBD.GetIntFromReader("Id", reader);

                    // las referencias como siempre del os otors ado
                    return usuTematica;
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

        public List<UsuTematica> ObtenerListado(SqlConnection conexion)
        {
            SqlDataReader reader = null;

            List<UsuTematica> listaUsuTematica = new List<UsuTematica>();

            try
            {
                command = conexion.CreateCommand();

                command.Connection = conexion;

                command.CommandText = "SELECT * FROM UsuTematica";

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    UsuTematica usuTematica = new UsuTematica();

                    usuTematica.Id = UtilesBD.GetIntFromReader("Id", reader);

                    // las referencias como siempre del os otors ado
                    listaUsuTematica.Add(usuTematica);
                }

                return listaUsuTematica;
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
