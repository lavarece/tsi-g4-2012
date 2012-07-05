using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.Common.Entities;
using System.Data.SqlClient;
using System.Data;
using IndignaFwk.Common.Util;
using IndignaFwk.Common.Enumeration;


namespace IndignaFwk.Persistence.DataAccess
{
    public class ContenidoADO : IContenidoADO
    {
        private SqlCommand command;

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

        public void Crear(Contenido contenido, SqlConnection conexion, SqlTransaction transaccion)
        {
            command = conexion.CreateCommand();

            command.Transaction = transaccion;

            command.Connection = conexion;

            command.CommandText = "INSERT INTO Contenido(Titulo, Comentario, Url, NivelVisibilidad, TipoContenido, FechaCreacion, FK_Id_UsuarioCreacion, FK_Id_Sitio, Eliminado) " +
                                  "values(@titulo, @comentario, @url, @nivelVisibilidad, @tipoContenido, @fechaCreacion, @idUsuarioCreacion, @idSitio, @eliminado);" +
                                  "select @idGen = SCOPE_IDENTITY() FROM Contenido;";

            UtilesBD.SetParameter(command, "titulo", contenido.Titulo);
            UtilesBD.SetParameter(command, "comentario", contenido.Comentario);
            UtilesBD.SetParameter(command, "url", contenido.Url);
            UtilesBD.SetParameter(command, "nivelVisibilidad", contenido.NivelVisibilidad);
            UtilesBD.SetParameter(command, "tipoContenido", contenido.TipoContenido);
            UtilesBD.SetParameter(command, "fechaCreacion", contenido.FechaCreacion);            
            UtilesBD.SetParameter(command, "idUsuarioCreacion", contenido.UsuarioCreacion.Id);
            UtilesBD.SetParameter(command, "idSitio", contenido.Grupo.Id);
            UtilesBD.SetParameter(command, "eliminado", false);

            command.Parameters.Add("@idGen", SqlDbType.Int).Direction = ParameterDirection.Output;

            command.ExecuteScalar();

            contenido.Id = (int)command.Parameters["@idGen"].Value;            
        }

        public void Editar(Contenido contenido, SqlConnection conexion, SqlTransaction transaccion)
        {
            command = conexion.CreateCommand();

            command.Transaction = transaccion;

            command.Connection = conexion;
            
            command.CommandText = ("UPDATE Contenido " + 
                                   "SET Titulo = @titulo, " +
                                   "Comentario = @comentario, " + 
                                   "Url = @url, " + 
                                   "NivelVisibilidad = @nivelVisibilidad, " + 
                                   "TipoContenido = @tipoContenido " + 
                                   "WHERE Id = @id");

            UtilesBD.SetParameter(command, "Id", contenido.Id);
            UtilesBD.SetParameter(command, "titulo", contenido.Titulo);
            UtilesBD.SetParameter(command, "comentario", contenido.Comentario);
            UtilesBD.SetParameter(command, "url", contenido.Url);
            UtilesBD.SetParameter(command, "nivelVisibilidad", contenido.NivelVisibilidad);
            UtilesBD.SetParameter(command, "tipoContenido", contenido.TipoContenido);

            command.ExecuteNonQuery();
        }

        public void Eliminar(int id, SqlConnection conexion, SqlTransaction transaccion)
        {
            command = conexion.CreateCommand();

            command.Transaction = transaccion;

            command.Connection = conexion;
            
            command.CommandText = "update Contenido set Eliminado = 1 WHERE Id = @id";
            
            UtilesBD.SetParameter(command, "id", id);

            command.ExecuteNonQuery();            
        }

        public Contenido Obtener(int id, SqlConnection conexion)
        {
            SqlDataReader reader = null;

            try
            {
                command = conexion.CreateCommand();

                command.Connection = conexion;

                StringBuilder sbQuery = new StringBuilder();

                sbQuery.Append(" SELECT c.*, ")
                       .Append(" (select COUNT(mc.id) from MarcaContenido mc where mc.FK_Id_Contenido = c.Id and mc.TipoMarca = '" + TipoMarcaContenidoEnum.ME_GUSTA.Valor + "') cantidadMegusta, ")
                       .Append(" (select COUNT(mc.id) from MarcaContenido mc where mc.FK_Id_Contenido = c.Id and mc.TipoMarca = '" + TipoMarcaContenidoEnum.INADECUADO.Valor + "') cantidadInadecuado ")
                       .Append(" FROM Contenido c WHERE Id = @id and Eliminado = 0 ");

                command.CommandText = sbQuery.ToString();

                UtilesBD.SetParameter(command, "id", id);

                reader = command.ExecuteReader();

                if(reader.Read())
                {
                    Contenido contenido = new Contenido();

                    contenido.Id = UtilesBD.GetIntFromReader("Id", reader);

                    contenido.Titulo = UtilesBD.GetStringFromReader("Titulo", reader);

                    contenido.Comentario = UtilesBD.GetStringFromReader("Comentario", reader);

                    contenido.Url = UtilesBD.GetStringFromReader("Url", reader);

                    contenido.NivelVisibilidad = UtilesBD.GetStringFromReader("NivelVisibilidad", reader);

                    contenido.TipoContenido = UtilesBD.GetStringFromReader("TipoContenido", reader);

                    contenido.FechaCreacion = UtilesBD.GetDateTimeFromReader("FechaCreacion", reader);

                    contenido.CantidadMeGusta = UtilesBD.GetIntFromReader("cantidadMeGusta", reader);

                    contenido.CantidadInadecuado = UtilesBD.GetIntFromReader("cantidadInadecuado", reader);

                    contenido.UsuarioCreacion = UsuarioADO.Obtener(UtilesBD.GetIntFromReader("FK_Id_UsuarioCreacion", reader), conexion);

                    contenido.Grupo = GrupoADO.Obtener(UtilesBD.GetIntFromReader("FK_Id_Sitio", reader), conexion);

                    return contenido;
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

        public List<Contenido> ObtenerListadoPorGrupoYVisibilidad(SqlConnection conexion, int idGrupo, string visibilidadContenido)
        {
            SqlDataReader reader = null;

            List<Contenido> listaContenido = new List<Contenido>();

            try
            {
                command = conexion.CreateCommand();

                command.Connection = conexion;

                StringBuilder sbQuery = new StringBuilder();
                
                sbQuery.Append(" SELECT c.*, ")
                       .Append(" (select COUNT(mc.id) from MarcaContenido mc where mc.FK_Id_Contenido = c.Id and mc.TipoMarca = '" + TipoMarcaContenidoEnum.ME_GUSTA.Valor + "') cantidadMegusta, ")
                       .Append(" (select COUNT(mc.id) from MarcaContenido mc where mc.FK_Id_Contenido = c.Id and mc.TipoMarca = '" + TipoMarcaContenidoEnum.INADECUADO.Valor + "') cantidadInadecuado ")        
                       .Append(" FROM Contenido c where FK_Id_sitio = @idGrupo and Eliminado = 0 ");

                if (!String.IsNullOrEmpty(visibilidadContenido))
                {
                    sbQuery.Append(" and c.NivelVisibilidad = @visibilidadContenido");
                }

                sbQuery.Append(" order by c.FechaCreacion desc ");

                command.CommandText = sbQuery.ToString();

                UtilesBD.SetParameter(command, "idGrupo", idGrupo);

                if (!String.IsNullOrEmpty(visibilidadContenido))
                {
                    UtilesBD.SetParameter(command, "visibilidadContenido", visibilidadContenido);
                }
                
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Contenido contenido = new Contenido();

                    contenido.Id = UtilesBD.GetIntFromReader("Id", reader);

                    contenido.Titulo = UtilesBD.GetStringFromReader("Titulo", reader);

                    contenido.Comentario = UtilesBD.GetStringFromReader("Comentario", reader);

                    contenido.Url = UtilesBD.GetStringFromReader("Url", reader);

                    contenido.NivelVisibilidad = UtilesBD.GetStringFromReader("NivelVisibilidad", reader);

                    contenido.TipoContenido = UtilesBD.GetStringFromReader("TipoContenido", reader);

                    contenido.FechaCreacion = UtilesBD.GetDateTimeFromReader("FechaCreacion", reader);

                    contenido.CantidadMeGusta = UtilesBD.GetIntFromReader("cantidadMeGusta", reader);

                    contenido.CantidadInadecuado = UtilesBD.GetIntFromReader("cantidadInadecuado", reader);

                    contenido.UsuarioCreacion = UsuarioADO.Obtener(UtilesBD.GetIntFromReader("FK_Id_UsuarioCreacion", reader), conexion);

                    contenido.Grupo = GrupoADO.Obtener(UtilesBD.GetIntFromReader("FK_Id_Sitio", reader), conexion);

                    listaContenido.Add(contenido);
                }

                return listaContenido;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }   
            }
        }

        public List<Contenido> ObtenerXPorGrupoYVisibilidad(SqlConnection conexion, int idGrupo, string visibilidadContenido, int x)
        {
            SqlDataReader reader = null;

            List<Contenido> listaContenido = new List<Contenido>();

            try
            {
                command = conexion.CreateCommand();

                command.Connection = conexion;

                StringBuilder sbQuery = new StringBuilder();

                sbQuery.Append(" SELECT TOP " + x + " c.*, ")
                       .Append(" (select COUNT(mc.id) from IndignadoFDb.dbo.MarcaContenido mc where mc.FK_Id_Contenido = c.Id and mc.TipoMarca = '" + TipoMarcaContenidoEnum.ME_GUSTA.Valor + "') cantidadMegusta, ")
                       .Append(" (select COUNT(mc.id) from IndignadoFDb.dbo.MarcaContenido mc where mc.FK_Id_Contenido = c.Id and mc.TipoMarca = '" + TipoMarcaContenidoEnum.INADECUADO.Valor + "') cantidadInadecuado ")
                       .Append(" FROM Contenido c ")
                       .Append(" WHERE c.Eliminado = 0 and c.FK_Id_Sitio = @idGrupo ");
	        
                if (!String.IsNullOrEmpty(visibilidadContenido))
                {
                    sbQuery.Append(" and c.NivelVisibilidad = @visibilidadContenido");
                }

                sbQuery.Append(" ORDER BY cantidadMegusta DESC, c.FechaCreacion DESC ");

                
                command.CommandText = sbQuery.ToString();

                UtilesBD.SetParameter(command, "idGrupo", idGrupo);

                if (!String.IsNullOrEmpty(visibilidadContenido))
                {
                    UtilesBD.SetParameter(command, "visibilidadContenido", visibilidadContenido);
                }

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Contenido contenido = new Contenido();

                    contenido.Id = UtilesBD.GetIntFromReader("Id", reader);

                    contenido.Titulo = UtilesBD.GetStringFromReader("Titulo", reader);

                    contenido.Comentario = UtilesBD.GetStringFromReader("Comentario", reader);

                    contenido.Url = UtilesBD.GetStringFromReader("Url", reader);

                    contenido.NivelVisibilidad = UtilesBD.GetStringFromReader("NivelVisibilidad", reader);

                    contenido.TipoContenido = UtilesBD.GetStringFromReader("TipoContenido", reader);

                    contenido.FechaCreacion = UtilesBD.GetDateTimeFromReader("FechaCreacion", reader);

                    contenido.CantidadMeGusta = UtilesBD.GetIntFromReader("cantidadMeGusta", reader);

                    contenido.CantidadInadecuado = UtilesBD.GetIntFromReader("cantidadInadecuado", reader);

                    contenido.UsuarioCreacion = UsuarioADO.Obtener(UtilesBD.GetIntFromReader("FK_Id_UsuarioCreacion", reader), conexion);

                    contenido.Grupo = GrupoADO.Obtener(UtilesBD.GetIntFromReader("FK_Id_Sitio", reader), conexion);

                    listaContenido.Add(contenido);
                }

                return listaContenido;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }

        public List<Contenido> ObtenerListadoPorTematica(int idTematica, SqlConnection conexion)
        {
            SqlDataReader reader = null;

            List<Contenido> listaContenido = new List<Contenido>();

            try
            {
                command = conexion.CreateCommand();

                command.Connection = conexion;

                StringBuilder sbQuery = new StringBuilder();

                sbQuery.Append(" SELECT c.*, ")
                       .Append(" (select COUNT(mc.id) from IndignadoFDb.dbo.MarcaContenido mc where mc.FK_Id_Contenido = c.Id and mc.TipoMarca = '" + TipoMarcaContenidoEnum.ME_GUSTA.Valor + "') cantidadMegusta, ")
                       .Append(" (select COUNT(mc.id) from IndignadoFDb.dbo.MarcaContenido mc where mc.FK_Id_Contenido = c.Id and mc.TipoMarca = '" + TipoMarcaContenidoEnum.INADECUADO.Valor + "') cantidadInadecuado ")
                       .Append(" FROM Contenido c left join ")
                       .Append(" Sitio s on c.FK_Id_Sitio = s.Id ")
                       .Append(" WHERE s.FK_Id_Tematica = @idTematica and Eliminado = 0");

                command.CommandText = sbQuery.ToString();

                UtilesBD.SetParameter(command, "idTematica", idTematica);

                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Contenido contenido = new Contenido();

                    contenido.Id = UtilesBD.GetIntFromReader("Id", reader);

                    contenido.Titulo = UtilesBD.GetStringFromReader("Titulo", reader);

                    contenido.Comentario = UtilesBD.GetStringFromReader("Comentario", reader);

                    contenido.Url = UtilesBD.GetStringFromReader("Url", reader);

                    contenido.NivelVisibilidad = UtilesBD.GetStringFromReader("NivelVisibilidad", reader);

                    contenido.TipoContenido = UtilesBD.GetStringFromReader("TipoContenido", reader);

                    contenido.FechaCreacion = UtilesBD.GetDateTimeFromReader("FechaCreacion", reader);

                    contenido.CantidadMeGusta = UtilesBD.GetIntFromReader("cantidadMeGusta", reader);

                    contenido.CantidadInadecuado = UtilesBD.GetIntFromReader("cantidadInadecuado", reader);

                    contenido.UsuarioCreacion = UsuarioADO.Obtener(UtilesBD.GetIntFromReader("FK_Id_UsuarioCreacion", reader), conexion);

                    contenido.Grupo = GrupoADO.Obtener(UtilesBD.GetIntFromReader("FK_Id_Sitio", reader), conexion);

                    listaContenido.Add(contenido);
                }

                return listaContenido;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }

        public Contenido ObtenerContenidoConMarcas(int id, SqlConnection conexion)
        {
            SqlDataReader reader = null;

            try
            {
                command = conexion.CreateCommand();

                command.Connection = conexion;

                StringBuilder sbQuery = new StringBuilder();

                sbQuery.Append(" SELECT c.*, ")
                       .Append(" (select COUNT(mc.id) from MarcaContenido mc where mc.FK_Id_Contenido = c.Id and mc.TipoMarca = '" + TipoMarcaContenidoEnum.INADECUADO.Valor + "') cantidadInadecuado ")
                       .Append(" FROM Contenido c WHERE Id = @id and Eliminado = 0");

                command.CommandText = sbQuery.ToString();

                UtilesBD.SetParameter(command, "id", id);

                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Contenido contenido = new Contenido();

                    contenido.Id = UtilesBD.GetIntFromReader("Id", reader);

                    contenido.Titulo = UtilesBD.GetStringFromReader("Titulo", reader);

                    contenido.Comentario = UtilesBD.GetStringFromReader("Comentario", reader);

                    contenido.Url = UtilesBD.GetStringFromReader("Url", reader);

                    contenido.NivelVisibilidad = UtilesBD.GetStringFromReader("NivelVisibilidad", reader);

                    contenido.TipoContenido = UtilesBD.GetStringFromReader("TipoContenido", reader);

                    contenido.FechaCreacion = UtilesBD.GetDateTimeFromReader("FechaCreacion", reader);

                    contenido.CantidadInadecuado = UtilesBD.GetIntFromReader("cantidadInadecuado", reader);

                    contenido.UsuarioCreacion = UsuarioADO.Obtener(UtilesBD.GetIntFromReader("FK_Id_UsuarioCreacion", reader), conexion);

                    contenido.Grupo = GrupoADO.Obtener(UtilesBD.GetIntFromReader("FK_Id_Sitio", reader), conexion);

                    return contenido;
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


        public List<Contenido> ObtenerListadoPorGrupoNoEliminado(SqlConnection conexion, int idGrupo)
        {
            SqlDataReader reader = null;

            List<Contenido> listaContenido = new List<Contenido>();

            try
            {
                command = conexion.CreateCommand();

                command.Connection = conexion;

                StringBuilder sbQuery = new StringBuilder();

                sbQuery.Append(" SELECT c.*, ")
                       .Append(" (select COUNT(mc.id) from MarcaContenido mc where mc.FK_Id_Contenido = c.Id and mc.TipoMarca = '" + TipoMarcaContenidoEnum.INADECUADO.Valor + "') cantidadInadecuado ")
                       .Append(" FROM Contenido c where FK_Id_sitio = @idGrupo and Eliminado = 0 ");

                command.CommandText = sbQuery.ToString();

                UtilesBD.SetParameter(command, "idGrupo", idGrupo);

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Contenido contenido = new Contenido();

                    contenido.Id = UtilesBD.GetIntFromReader("Id", reader);

                    contenido.Titulo = UtilesBD.GetStringFromReader("Titulo", reader);

                    contenido.Comentario = UtilesBD.GetStringFromReader("Comentario", reader);

                    contenido.Url = UtilesBD.GetStringFromReader("Url", reader);

                    contenido.NivelVisibilidad = UtilesBD.GetStringFromReader("NivelVisibilidad", reader);

                    contenido.TipoContenido = UtilesBD.GetStringFromReader("TipoContenido", reader);

                    contenido.FechaCreacion = UtilesBD.GetDateTimeFromReader("FechaCreacion", reader);

                    contenido.CantidadInadecuado = UtilesBD.GetIntFromReader("cantidadInadecuado", reader);

                    contenido.UsuarioCreacion = UsuarioADO.Obtener(UtilesBD.GetIntFromReader("FK_Id_UsuarioCreacion", reader), conexion);

                    contenido.Grupo = GrupoADO.Obtener(UtilesBD.GetIntFromReader("FK_Id_Sitio", reader), conexion);

                    listaContenido.Add(contenido);
                }

                return listaContenido;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }


        public List<Contenido> ObtenerListadoPorGrupo(SqlConnection conexion, int idGrupo)
        {
            SqlDataReader reader = null;

            List<Contenido> listaContenido = new List<Contenido>();

            try
            {
                command = conexion.CreateCommand();

                command.Connection = conexion;

                StringBuilder sbQuery = new StringBuilder();

                sbQuery.Append(" SELECT c.*, ")
                       .Append(" (select COUNT(mc.id) from MarcaContenido mc where mc.FK_Id_Contenido = c.Id and mc.TipoMarca = '" + TipoMarcaContenidoEnum.INADECUADO.Valor + "') cantidadInadecuado ")
                       .Append(" FROM Contenido c where FK_Id_sitio = @idGrupo  ");

                command.CommandText = sbQuery.ToString();

                UtilesBD.SetParameter(command, "idGrupo", idGrupo);

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Contenido contenido = new Contenido();

                    contenido.Id = UtilesBD.GetIntFromReader("Id", reader);

                    contenido.Titulo = UtilesBD.GetStringFromReader("Titulo", reader);

                    contenido.Comentario = UtilesBD.GetStringFromReader("Comentario", reader);

                    contenido.Url = UtilesBD.GetStringFromReader("Url", reader);

                    contenido.NivelVisibilidad = UtilesBD.GetStringFromReader("NivelVisibilidad", reader);

                    contenido.TipoContenido = UtilesBD.GetStringFromReader("TipoContenido", reader);

                    contenido.FechaCreacion = UtilesBD.GetDateTimeFromReader("FechaCreacion", reader);

                    contenido.CantidadInadecuado = UtilesBD.GetIntFromReader("cantidadInadecuado", reader);

                    contenido.UsuarioCreacion = UsuarioADO.Obtener(UtilesBD.GetIntFromReader("FK_Id_UsuarioCreacion", reader), conexion);

                    contenido.Grupo = GrupoADO.Obtener(UtilesBD.GetIntFromReader("FK_Id_Sitio", reader), conexion);

                    listaContenido.Add(contenido);
                }

                return listaContenido;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }

    
        public List<Contenido> ObtenerContenidoEliminadoPorUsuario(int id, SqlConnection conexion)
        {
            SqlDataReader reader = null;

            List<Contenido> listaContenido = new List<Contenido>();

            try
            {
                command = conexion.CreateCommand();

                command.Connection = conexion;

                StringBuilder sbQuery = new StringBuilder();

                sbQuery.Append(" SELECT c.*")
                       .Append(" FROM Contenido c WHERE FK_Id_UsuarioCreacion = @id and Eliminado = 1");

                command.CommandText = sbQuery.ToString();

                UtilesBD.SetParameter(command, "id", id);

                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Contenido contenido = new Contenido();

                    contenido.Id = UtilesBD.GetIntFromReader("Id", reader);

                    contenido.Titulo = UtilesBD.GetStringFromReader("Titulo", reader);

                    contenido.Comentario = UtilesBD.GetStringFromReader("Comentario", reader);

                    contenido.Url = UtilesBD.GetStringFromReader("Url", reader);

                    contenido.NivelVisibilidad = UtilesBD.GetStringFromReader("NivelVisibilidad", reader);

                    contenido.TipoContenido = UtilesBD.GetStringFromReader("TipoContenido", reader);

                    contenido.FechaCreacion = UtilesBD.GetDateTimeFromReader("FechaCreacion", reader);

                    //contenido.CantidadMeGusta = UtilesBD.GetIntFromReader("cantidadMeGusta", reader);

                    //contenido.CantidadInadecuado = UtilesBD.GetIntFromReader("cantidadInadecuado", reader);

                    contenido.UsuarioCreacion = UsuarioADO.Obtener(UtilesBD.GetIntFromReader("FK_Id_UsuarioCreacion", reader), conexion);

                    contenido.Grupo = GrupoADO.Obtener(UtilesBD.GetIntFromReader("FK_Id_Sitio", reader), conexion);

                    listaContenido.Add(contenido);
                }

                return listaContenido;
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
