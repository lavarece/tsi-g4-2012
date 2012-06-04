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
    public class GrupoADO : IGrupoADO
    {
        private SqlCommand command;    
        
        public void Crear(Grupo grupo, SqlConnection conexion, SqlTransaction transaccion)
        {
            command = conexion.CreateCommand();

            command.Transaction = transaccion;

            command.Connection = conexion;

            command.CommandText = " insert into Sitio(Nombre, Descripcion, Url, Coordenadas, FK_Id_Imagen, FK_Id_Layout, FK_Id_Tematica) " +
                                  " values(@nombre, @descripcion, @url, @coordenadas, @idImagen, @idLayout, @idTematica); " + 
                                  " select @idGen = SCOPE_IDENTITY() FROM Sitio; ";
            
            UtilesBD.SetParameter(command, "nombre", grupo.Nombre);
            UtilesBD.SetParameter(command, "descripcion", grupo.Descripcion);
            UtilesBD.SetParameter(command, "url", grupo.Url);
            UtilesBD.SetParameter(command, "coordenadas", grupo.Coordenadas);
            UtilesBD.SetParameter(command, "idLayout", grupo.Layout.Id);
            UtilesBD.SetParameter(command, "idTematica", grupo.Tematica.Id);

            if (grupo.Imagen != null)
                UtilesBD.SetParameter(command, "idImagen", grupo.Imagen.Id);
            else
                UtilesBD.SetParameter(command, "idImagen", null);

            // indico que la query tiene un parámetro de salida thisId de tipo int
            command.Parameters.Add("@idGen", SqlDbType.Int).Direction = ParameterDirection.Output;

            command.ExecuteScalar();

            // este es el identificador generado
            grupo.Id = (int)command.Parameters["@idGen"].Value;
        }

        public void Editar(Grupo grupo, SqlConnection conexion, SqlTransaction transaccion)
        {
            command = conexion.CreateCommand();

            command.Transaction = transaccion;

            command.Connection = conexion;
            
            command.CommandText = " UPDATE Sitio SET " +
                                  " Nombre = @nombre, " +                                    
                                  " Descripcion = @descripcion, " +
                                  " Url = @url " +
                                  " Coordenadas = @coordenadas" +                                  
                                  " FK_Id_Layout = @idLayout," +
                                  " FK_Id_Tematica = @idTematica," +
                                  " FK_Id_Imagen = @idImagen," +
                                  " WHERE Id = @id";

            UtilesBD.SetParameter(command, "id", grupo.Id);
            UtilesBD.SetParameter(command, "nombre", grupo.Nombre);       
            UtilesBD.SetParameter(command, "descripcion", grupo.Descripcion);
            UtilesBD.SetParameter(command, "url", grupo.Url);
            UtilesBD.SetParameter(command, "coordenadas", grupo.Coordenadas);
            UtilesBD.SetParameter(command, "idLayout", grupo.Layout.Id);
            UtilesBD.SetParameter(command, "idTematica", grupo.Tematica.Id);

            if(grupo.Imagen != null)
                UtilesBD.SetParameter(command, "idImagen", grupo.Imagen.Id);
            else
                UtilesBD.SetParameter(command, "idImagen", null);

            command.ExecuteNonQuery();
        }

        public void Eliminar(int id, SqlConnection conexion, SqlTransaction transaccion)
        {
            command = conexion.CreateCommand();

            command.Transaction = transaccion;

            command.Connection = conexion;
            
            command.CommandText = "DELETE FROM Sitio WHERE Id = @id";
            
            UtilesBD.SetParameter(command, "id", id);
            
            command.ExecuteNonQuery();
        }

        public Grupo Obtener(int id, SqlConnection conexion)
        {
            SqlDataReader reader = null;
       
            try
            {
                command = conexion.CreateCommand();

                command.Connection = conexion;
                
                command.CommandText ="select * from Sitio where Id = @id";

                UtilesBD.SetParameter(command, "id", id);

                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Grupo grupo = new Grupo();

                    grupo.Id = UtilesBD.GetIntFromReader("id", reader);

                    grupo.Nombre = UtilesBD.GetStringFromReader("Nombre", reader);

                    grupo.Descripcion = UtilesBD.GetStringFromReader("Descripcion", reader);

                    grupo.Url = UtilesBD.GetStringFromReader("Url", reader);

                    grupo.Coordenadas = UtilesBD.GetStringFromReader("Coordenadas", reader);

                    grupo.Layout = new Layout { Id = UtilesBD.GetIntFromReader("FK_Id_Layout", reader) };

                    grupo.Tematica = new Tematica { Id = UtilesBD.GetIntFromReader("FK_Id_Tematica", reader) };

                    grupo.Imagen = new Imagen { Id = UtilesBD.GetIntFromReader("FK_Id_Imagen", reader) };

                    return grupo;
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

        public Grupo ObtenerPorUrl(string url, SqlConnection conexion)
        {
            SqlDataReader reader = null;

            try
            {
                command = conexion.CreateCommand();

                command.Connection = conexion;

                command.CommandText = "select * from Sitio where Url = @url";

                UtilesBD.SetParameter(command, "url", url);

                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Grupo grupo = new Grupo();

                    grupo.Id = UtilesBD.GetIntFromReader("id", reader);

                    grupo.Nombre = UtilesBD.GetStringFromReader("Nombre", reader);

                    grupo.Descripcion = UtilesBD.GetStringFromReader("Descripcion", reader);

                    grupo.Url = UtilesBD.GetStringFromReader("Url", reader);

                    grupo.Coordenadas = UtilesBD.GetStringFromReader("Coordenadas", reader);

                    grupo.Layout = new Layout { Id = UtilesBD.GetIntFromReader("FK_Id_Layout", reader) };

                    grupo.Tematica = new Tematica { Id = UtilesBD.GetIntFromReader("FK_Id_Tematica", reader) };

                    grupo.Imagen = new Imagen { Id = UtilesBD.GetIntFromReader("FK_Id_Imagen", reader) };

                    return grupo;
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

        public List<Grupo> ObtenerListado(SqlConnection conexion)
        {
            SqlDataReader reader = null;

            List<Grupo> listaGrupos = new List<Grupo>();

            try
            {
                command = conexion.CreateCommand();

                command.Connection = conexion;

                command.CommandText = "SELECT * FROM Sitio";

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Grupo grupo = new Grupo();

                    grupo.Id = UtilesBD.GetIntFromReader("Id", reader);

                    grupo.Nombre = UtilesBD.GetStringFromReader("Nombre", reader);

                    grupo.Descripcion = UtilesBD.GetStringFromReader("Descripcion", reader);

                    grupo.Url = UtilesBD.GetStringFromReader("Url", reader);

                    grupo.Coordenadas = UtilesBD.GetStringFromReader("Coordenadas", reader);

                    grupo.Layout = new Layout { Id = UtilesBD.GetIntFromReader("FK_Id_Layout", reader) };

                    grupo.Tematica = new Tematica { Id = UtilesBD.GetIntFromReader("FK_Id_Tematica", reader) };

                    grupo.Imagen = new Imagen { Id = UtilesBD.GetIntFromReader("FK_Id_Imagen", reader) };

                    listaGrupos.Add(grupo);
                }

                return listaGrupos;
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