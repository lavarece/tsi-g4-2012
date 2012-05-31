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
    public class VariableSistemaADO : IVariableSistemaADO
    {
        private SqlCommand command;

        public int Crear(VariableSistema variableSistema, SqlConnection conexion, SqlTransaction transaccion)
        {
            command = conexion.CreateCommand();

            command.Transaction = transaccion;

            command.Connection = conexion;

            command.CommandText = "INSERT INTO VariableSistema(Nombre, Valor) " +
                                  "values(@nombre, @valor); " +
                                  "select @idGen = SCOPE_IDENTITY() FROM VariableSistema";

            UtilesBD.SetParameter(command, "nombre", variableSistema.Nombre);
            UtilesBD.SetParameter(command, "valor", variableSistema.Valor);

            // indico que la query tiene un parámetro de salida thisId de tipo int
            command.Parameters.Add("@idGen", SqlDbType.Int).Direction = ParameterDirection.Output;

            command.ExecuteScalar();

            // este es el identificador generado
            return (int)command.Parameters["@idGen"].Value;
        }

        public void Editar(VariableSistema variableSistema, SqlConnection conexion, SqlTransaction transaccion)
        {
            command = conexion.CreateCommand();

            command.Transaction = transaccion;

            command.Connection = conexion;

            command.CommandText = "UPDATE VariableSistema SET " +
                                  "Nombre = @nombre, " +
                                  "Valor = @valor " +
                                  "WHERE Id = @id ";

            UtilesBD.SetParameter(command, "id", variableSistema.Id);
            UtilesBD.SetParameter(command, "nombre", variableSistema.Nombre);
            UtilesBD.SetParameter(command, "valor", variableSistema.Valor);

            command.ExecuteNonQuery();
        }

        public void Eliminar(int id, SqlConnection conexion, SqlTransaction transaccion)
        {
            command = conexion.CreateCommand();

            command.Transaction = transaccion;

            command.Connection = conexion;

            command.CommandText = "DELETE FROM VariableSistema WHERE Id = @id";

            UtilesBD.SetParameter(command, "id", id);

            command.ExecuteNonQuery();
        }

        public VariableSistema Obtener(int id, SqlConnection conexion)
        {
            SqlDataReader reader = null;

            try
            {
                command = conexion.CreateCommand();

                command.Connection = conexion;

                command.CommandText = "SELECT * FROM VariableSistema WHERE Id = @id";

                UtilesBD.SetParameter(command, "id", id); ;

                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    VariableSistema variableSistema = new VariableSistema();

                    variableSistema.Id = UtilesBD.GetIntFromReader("Id", reader);

                    variableSistema.Nombre = UtilesBD.GetStringFromReader("Nombre", reader);

                    variableSistema.Valor = UtilesBD.GetStringFromReader("Valor", reader);

                    return variableSistema;
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

        public VariableSistema ObtenerPorNombre(string nombre, SqlConnection conexion)
        {
            SqlDataReader reader = null;

            try
            {
                command = conexion.CreateCommand();

                command.Connection = conexion;

                command.CommandText = "SELECT * FROM VariableSistema WHERE Nombre = @nombre";

                UtilesBD.SetParameter(command, "nombre", nombre);

                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    VariableSistema vSistema = new VariableSistema();

                    vSistema.Id = UtilesBD.GetIntFromReader("Id", reader);

                    vSistema.Nombre = UtilesBD.GetStringFromReader("Nombre", reader);

                    vSistema.Valor = UtilesBD.GetStringFromReader("Valor", reader);

                    return vSistema;
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
    

        
        
        
        public List<VariableSistema> ObtenerListado(SqlConnection conexion)
        {
            SqlDataReader reader = null;

            List<VariableSistema> listaVariables = new List<VariableSistema>();

            try
            {
                command = conexion.CreateCommand();

                command.Connection = conexion;

                command.CommandText = "SELECT * FROM VariableSistema";

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    VariableSistema variableSistema = new VariableSistema();

                    variableSistema.Id = UtilesBD.GetIntFromReader("Id", reader);

                    variableSistema.Nombre = UtilesBD.GetStringFromReader("Nombre", reader);

                    variableSistema.Valor = UtilesBD.GetStringFromReader("Valor", reader);

                    listaVariables.Add(variableSistema);
                }

                return listaVariables;
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
