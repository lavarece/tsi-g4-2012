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
    public class AdministradorADO : IAdministradoADO
    {
        private SqlCommand command;

        public int Crear(Administrador administrador, SqlConnection conexion, SqlTransaction transaccion)
        {
            command = conexion.CreateCommand();

            command.Transaction = transaccion;

            command.Connection = conexion;

            command.CommandText = "INSERT INTO Administrador(Nombre, Email, Password, Pregunta, Respuesta, Region) " +
                                  "values(@nombre, @email, @password, @pregunta, @respuesta, @region);" +
                                  "select @idGen = SCOPE_IDENTITY() FROM Administrador;";

            UtilesBD.SetParameter(command, "nombre", administrador.Nombre);
            UtilesBD.SetParameter(command, "email", administrador.Email);
            UtilesBD.SetParameter(command, "password", administrador.Password);
            UtilesBD.SetParameter(command, "pregunta", administrador.Pregunta);
            UtilesBD.SetParameter(command, "respuesta", administrador.Respuesta);
            UtilesBD.SetParameter(command, "region", administrador.Region);

            command.Parameters.Add("@idGen", SqlDbType.Int).Direction = ParameterDirection.Output;

            command.ExecuteScalar();

            return (int)command.Parameters["@idGen"].Value;
        }

        public void Editar(Administrador administrador, SqlConnection conexion, SqlTransaction transaccion)
        {
            command = conexion.CreateCommand();

            command.Transaction = transaccion;

            command.Connection = conexion;

            command.CommandText = "UPDATE Administrador SET " +
                                  "Nombre = @nombre, " +
                                  "Email = @email, " +
                                  "Password = @password, " +
                                  "Pregunta = @pregunta, " +
                                  "Respuesta = @respuesta, " +
                                  "Region = @region, " +
                                  "WHERE Id = @id";

            UtilesBD.SetParameter(command, "nombre", administrador.Nombre);
            UtilesBD.SetParameter(command, "email", administrador.Email);
            UtilesBD.SetParameter(command, "password", administrador.Password);
            UtilesBD.SetParameter(command, "pregunta", administrador.Pregunta);
            UtilesBD.SetParameter(command, "respuesta", administrador.Respuesta);
            UtilesBD.SetParameter(command, "region", administrador.Region);

            command.ExecuteNonQuery(); 
        }

        public void Eliminar(int id, SqlConnection conexion, SqlTransaction transaccion)
        {
            command = conexion.CreateCommand();

            command.Transaction = transaccion;

            command.Connection = conexion;

            command.CommandText = "DELETE FROM Adinistrador WHERE Id = @id";

            command.Parameters.AddWithValue("id", id);

            command.ExecuteNonQuery();
        }

        public Administrador Obtener(int id, SqlConnection conexion)
        {
            SqlDataReader reader = null;

            try
            {
                command = conexion.CreateCommand();

                command.Connection = conexion;

                command.CommandText = "SELECT * FROM Administrador WHERE Id = @id";

                command.Parameters.AddWithValue("id", id);

                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Administrador administrador = new Administrador();

                    administrador.Id = UtilesBD.GetIntFromReader("Id", reader);

                    administrador.Nombre = UtilesBD.GetStringFromReader("Nombre", reader);

                    administrador.Password = UtilesBD.GetStringFromReader("Conectado", reader);

                    administrador.Pregunta = UtilesBD.GetStringFromReader("Descripcion", reader);

                    administrador.Respuesta = UtilesBD.GetStringFromReader("Email", reader);

                    administrador.Region = UtilesBD.GetStringFromReader("Password", reader);

                    // Las referecias cargaras con los otros dao
                    return administrador;
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

        public List<Administrador> ObtenerListado(SqlConnection conexion)
        {
            SqlDataReader reader = null;

            List<Administrador> listaAdminstrador = new List<Administrador>();

            try
            {
                command = conexion.CreateCommand();

                command.Connection = conexion;

                command.CommandText = "SELECT * FROM Administrador";

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Administrador administrador = new Administrador();

                    administrador.Id = UtilesBD.GetIntFromReader("Id", reader);

                    administrador.Nombre = UtilesBD.GetStringFromReader("Nombre", reader);

                    administrador.Password = UtilesBD.GetStringFromReader("Conectado", reader);

                    administrador.Pregunta = UtilesBD.GetStringFromReader("Descripcion", reader);

                    administrador.Respuesta = UtilesBD.GetStringFromReader("Email", reader);

                    administrador.Region = UtilesBD.GetStringFromReader("Password", reader);

                    // Las referecias cargaras con los otros dao
                    listaAdminstrador.Add(administrador);
                }

                return listaAdminstrador;
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
