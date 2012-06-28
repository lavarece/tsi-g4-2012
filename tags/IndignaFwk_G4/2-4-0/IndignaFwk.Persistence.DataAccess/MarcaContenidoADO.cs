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

        private IContenidoADO _contenidoADO;
        protected IContenidoADO ContenidoADO
        {
            get
            {
                if(_contenidoADO == null)
                {
                    _contenidoADO = new ContenidoADO();
                }

                return _contenidoADO;
            }
        }

        public void Crear(MarcaContenido marcaContenido, SqlConnection conexion, SqlTransaction transaccion)
        {
            command = conexion.CreateCommand();

            command.Transaction = transaccion;

            command.Connection = conexion;

            command.CommandText = " insert into MarcaContenido(FK_Id_Contenido, FK_Id_Usuario, TipoMarca) " +
                                  " values(@idContenido, @idUsuario, @tipoMarca); " +
                                  " select @idGen = SCOPE_IDENTITY() FROM MarcaContenido; ";

            UtilesBD.SetParameter(command, "idContenido", marcaContenido.Contenido.Id);
            UtilesBD.SetParameter(command, "idUsuario", marcaContenido.UsuarioMarca.Id);
            UtilesBD.SetParameter(command, "tipoMarca", marcaContenido.TipoMarca);

            // indico que la query tiene un parámetro de salida thisId de tipo int
            command.Parameters.Add("@idGen", SqlDbType.Int).Direction = ParameterDirection.Output;

            command.ExecuteScalar();

            // este es el identificador generado
            marcaContenido.Id = (int)command.Parameters["@idGen"].Value;
        }

        public void Editar(MarcaContenido marcaContenido, SqlConnection conexion, SqlTransaction transaccion)
        {
            command = conexion.CreateCommand();

            command.Transaction = transaccion;

            command.Connection = conexion;

            command.CommandText = " UPDATE MarcaContenido SET " +
                                  " TipoMarca = @tipoMarca " +
                                  " WHERE Id = @id";

            UtilesBD.SetParameter(command, "id", marcaContenido.Id);
            UtilesBD.SetParameter(command, "tipoMarca", marcaContenido.TipoMarca);            

            command.ExecuteNonQuery();
        }

        public void Eliminar(int id, SqlConnection conexion, SqlTransaction transaccion)
        {
            command = conexion.CreateCommand();

            command.Transaction = transaccion;

            command.Connection = conexion;

            command.CommandText = "DELETE FROM MarcaContenido WHERE Id = @id";

            UtilesBD.SetParameter(command, "id", id);

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

                UtilesBD.SetParameter(command, "id", id);

                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    MarcaContenido marcaContenido = new MarcaContenido();

                    marcaContenido.Id = UtilesBD.GetIntFromReader("id", reader);

                    marcaContenido.TipoMarca = UtilesBD.GetStringFromReader("TipoMarca", reader);

                    marcaContenido.UsuarioMarca = UsuarioADO.Obtener(UtilesBD.GetIntFromReader("FK_Id_Usuario", reader), conexion);

                    marcaContenido.Contenido = ContenidoADO.Obtener(UtilesBD.GetIntFromReader("FK_Id_Contenido", reader), conexion);

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

        public MarcaContenido ObtenerPorUsuarioYContenido(int idUsuario, int idContenido, SqlConnection conexion)
        {
            SqlDataReader reader = null;

            try
            {
                command = conexion.CreateCommand();

                command.Connection = conexion;

                command.CommandText = "select * from MarcaContenido where FK_Id_Usuario = @idUsuario and FK_Id_Contenido = @idContenido";

                UtilesBD.SetParameter(command, "idUsuario", idUsuario);

                UtilesBD.SetParameter(command, "idContenido", idContenido);

                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    MarcaContenido marcaContenido = new MarcaContenido();

                    marcaContenido.Id = UtilesBD.GetIntFromReader("id", reader);

                    marcaContenido.TipoMarca = UtilesBD.GetStringFromReader("TipoMarca", reader);

                    marcaContenido.UsuarioMarca = UsuarioADO.Obtener(UtilesBD.GetIntFromReader("FK_Id_Usuario", reader), conexion);

                    marcaContenido.Contenido = ContenidoADO.Obtener(UtilesBD.GetIntFromReader("FK_Id_Contenido", reader), conexion);

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

                    marcaContenido.TipoMarca = UtilesBD.GetStringFromReader("TipoMarca", reader);

                    marcaContenido.UsuarioMarca = UsuarioADO.Obtener(UtilesBD.GetIntFromReader("FK_Id_Usuario", reader), conexion);

                    marcaContenido.Contenido = ContenidoADO.Obtener(UtilesBD.GetIntFromReader("FK_Id_Contenido", reader), conexion);

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
