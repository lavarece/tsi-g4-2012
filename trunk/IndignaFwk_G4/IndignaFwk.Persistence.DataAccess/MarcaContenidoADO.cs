using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.Common.Entities;
using System.Data;
using IndignaFwk.Common.Util;
using System.Data.SqlClient;

namespace IndignaFwk.Persistence.DataAccess
{
    public class MarcaContenidoADO : IMarcaContenidoADO
    {
        private SqlCommand command;    

        public int Crear(MarcaContenido marcaContenido, SqlConnection conexion, SqlTransaction transaccion)
        {
            command = conexion.CreateCommand();

            command.Transaction = transaccion;

            command.Connection = conexion;

            command.CommandText = " insert into MarcaContenido(FK_Id_Contenido, FK_Id_Usuario, TipoMarca) " +
                                  " values(@idContenido, @idUsuario, @tipoMarca); " +
                                  " select @idGen = SCOPE_IDENTITY() FROM MarcaContenido; ";

            command.Parameters.AddWithValue("idContenido", marcaContenido.Contenido.Id);

            command.Parameters.AddWithValue("idUsuario", marcaContenido.UsuarioMarca.Id);

            command.Parameters.AddWithValue("tipoMarca", marcaContenido.TipoMarca);

            // indico que la query tiene un parámetro de salida thisId de tipo int
            command.Parameters.Add("@idGen", SqlDbType.Int).Direction = ParameterDirection.Output;

            command.ExecuteScalar();

            // este es el identificador generado
            return (int)command.Parameters["@idGen"].Value;
        }

        public void Editar(MarcaContenido marcaContenido, SqlConnection conexion, SqlTransaction transaccion)
        {
            command = conexion.CreateCommand();

            command.Transaction = transaccion;

            command.Connection = conexion;

            command.CommandText = " UPDATE MarcaContenido SET " +
                                  " TipoMarca = @tipoMarca " +
                                  " WHERE Id = @id";

            command.Parameters.AddWithValue("id", marcaContenido.Id);
            command.Parameters.AddWithValue("tipoMarca", marcaContenido.TipoMarca);            

            command.ExecuteNonQuery();
        }

        public void Eliminar(int id, SqlConnection conexion, SqlTransaction transaccion)
        {
            command = conexion.CreateCommand();

            command.Transaction = transaccion;

            command.Connection = conexion;

            command.CommandText = "DELETE FROM MarcaContenido WHERE Id = @id";

            command.Parameters.AddWithValue("id", id);

            command.ExecuteNonQuery();
        }

        public MarcaContenido Obtener(int id, SqlConnection conexion)
        {
            SqlDataReader reader = null;

            try
            {
                command = conexion.CreateCommand();

                command.Connection = conexion;

                command.CommandText = "select * from MarcaContenido where Id = @id";

                command.Parameters.AddWithValue("id", id);

                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    MarcaContenido marcaContenido = new MarcaContenido();

                    marcaContenido.Id = UtilesBD.GetIntFromReader("id", reader);

                    // Los datos referencia cargarlos con los ADO correspondientes

                    return marcaContenido;
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

        public List<MarcaContenido>  ObtenerListado(SqlConnection conexion)
        {
            SqlDataReader reader = null;

            List<MarcaContenido> listaMarcaContenido = new List<MarcaContenido>();

            try
            {
                command = conexion.CreateCommand();

                command.Connection = conexion;

                command.CommandText = "SELECT * FROM MarcaContenido";

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    MarcaContenido marcaContenido = new MarcaContenido();

                    marcaContenido.Id = UtilesBD.GetIntFromReader("id", reader);

                    // Los datos referencia cargarlos con los ADO correspondientes

                    listaMarcaContenido.Add(marcaContenido);
                }

                return listaMarcaContenido;
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
