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
        
        public int Crear(Grupo grupo, SqlConnection conexion, SqlTransaction transaccion)
        {
            command = conexion.CreateCommand();

            command.Transaction = transaccion;

            command.Connection = conexion;
            
            command.CommandText = " insert into Sitio(Nombre, Descripcion, Url) " +
                                  " values(@nombre, @descripcion, @url); " + 
                                  " select @idGen = SCOPE_IDENTITY() FROM Sitio; ";
            
            UtilesBD.SetParameter(command, "nombre", grupo.Nombre);
            UtilesBD.SetParameter(command, "descripcion", grupo.Descripcion);
            UtilesBD.SetParameter(command, "url", grupo.Url);

            // indico que la query tiene un parámetro de salida thisId de tipo int
            command.Parameters.Add("@idGen", SqlDbType.Int).Direction = ParameterDirection.Output;

            command.ExecuteScalar();

            // este es el identificador generado
            return (int)command.Parameters["@idGen"].Value;
        }

        public void Editar(Grupo grupo, SqlConnection conexion, SqlTransaction transaccion)
        {
            command = conexion.CreateCommand();

            command.Transaction = transaccion;

            command.Connection = conexion;
            
            command.CommandText = " UPDATE Sitio SET " +
                                  " Nombre = @nombre, " + 
                                  " LogoUrl = @logoUrl," + 
                                  " Descripcion = @descripcion, " +
                                  " Url = @url " + 
                                  " WHERE Id = @id";

            UtilesBD.SetParameter(command, "id", grupo.Id);
            UtilesBD.SetParameter(command, "nombre", grupo.Nombre);
            UtilesBD.SetParameter(command, "logoUrl", grupo.LogoUrl);
            UtilesBD.SetParameter(command, "descripcion", grupo.Descripcion);
            UtilesBD.SetParameter(command, "url", grupo.Url);

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

                    grupo.LogoUrl = UtilesBD.GetStringFromReader("LogoUrl", reader);

                    grupo.Descripcion = UtilesBD.GetStringFromReader("Descripcion", reader);

                    grupo.Url = UtilesBD.GetStringFromReader("Url", reader);

                    // Las referencias cargarlas con los ADO particulares
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

                    grupo.LogoUrl = UtilesBD.GetStringFromReader("LogoUrl", reader);

                    grupo.Descripcion = UtilesBD.GetStringFromReader("Descripcion", reader);

                    grupo.Url = UtilesBD.GetStringFromReader("Url", reader);

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
                    Grupo varGrupo = new Grupo();

                    varGrupo.Id = UtilesBD.GetIntFromReader("Id", reader);

                    varGrupo.Nombre = UtilesBD.GetStringFromReader("Nombre", reader);

                    varGrupo.LogoUrl = UtilesBD.GetStringFromReader("LogoUrl", reader);

                    varGrupo.Descripcion = UtilesBD.GetStringFromReader("Descripcion", reader);

                    varGrupo.Url = UtilesBD.GetStringFromReader("Url", reader);

                    listaGrupos.Add(varGrupo);
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