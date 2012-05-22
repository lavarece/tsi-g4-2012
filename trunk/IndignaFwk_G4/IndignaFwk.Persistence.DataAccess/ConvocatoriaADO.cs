using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.Common.Entities;
using System.Data.SqlClient;

namespace IndignaFwk.Persistence.DataAccess
{
    public class ConvocatoriaADO : IConvocatoriaADO
    {
        private SqlCommand command;

        public int Crear(Convocatoria convocatoria, SqlConnection conexion, SqlTransaction transaccion)
        {
            command = conexion.CreateCommand();
            command.Transaction = transaccion;
            command.Connection = conexion;

            command.CommandText = "INSERT INTO Convocatoria (Titulo, LogoUrl, Descripcion, Quorum, Categoria, Coordenada) values(@Titulo, @LogoUrl, @Descricpion, @Quorum, @Categoria, @Coordenada)";

            command.Parameters.AddWithValue("Titulo", convocatoria.Titulo);
            command.Parameters.AddWithValue("LogoUrl", convocatoria.Logo);
            command.Parameters.AddWithValue("Descripcion", convocatoria.Descripcion);
            command.Parameters.AddWithValue("Quorum", convocatoria.Quorum);
            command.Parameters.AddWithValue("Categoria", convocatoria.Categoria);
            command.Parameters.AddWithValue("Coordenada", convocatoria.Coordenadas);
            
            command.ExecuteNonQuery();

            return 0;
        }

        //-------------------------------------------------------------------------------------------------
        public void Editar(Convocatoria convocatoria, SqlConnection conexion, SqlTransaction transaccion)
        {

            command = conexion.CreateCommand();
            command.Transaction = transaccion;
            command.Connection = conexion;

            command.CommandText = "UPDATE Convocatoria SET Titulo = @titulo, LogoUrl = @logoUrl, Descripción = @descripcion, Quorum = @quorum, Categoria=@categoria, Coordenada = @coordenada WHERE Id = @id";

            command.Parameters.AddWithValue("Titulo", convocatoria.Titulo);
            command.Parameters.AddWithValue("LogoUrl", convocatoria.Logo);
            command.Parameters.AddWithValue("Descripcion", convocatoria.Descripcion);
            command.Parameters.AddWithValue("Quorum", convocatoria.Quorum);
            command.Parameters.AddWithValue("Categoria", convocatoria.Categoria);
            command.Parameters.AddWithValue("Coordenada", convocatoria.Coordenadas);
           
            command.ExecuteNonQuery();
        }

        //-------------------------------------------------------------------------------------------------
        public void Eliminar(int id, SqlConnection conexion, SqlTransaction transaccion)
        {
            command = conexion.CreateCommand();
            command.Transaction = transaccion;
            command.Connection = conexion;

            command.CommandText = "DELETE FROM Convocatoria WHERE Id = @id";

            command.Parameters.AddWithValue("id", id);

            command.ExecuteNonQuery();
        }

        //-------------------------------------------------------------------------------------------------
        public Convocatoria Obtener(int id, SqlConnection conexion)
        {

            SqlDataReader reader = null;

            Convocatoria convocatoria = new Convocatoria();

            try
            {
                command = conexion.CreateCommand();
                command.Connection = conexion;

                command.CommandText = "SELECT * FROM Convocatoria WHERE Id = @id";

                SqlParameter param = new SqlParameter();

                param.ParameterName = "@id";

                param.Value = id;

                command.Parameters.Add(param);

                reader = command.ExecuteReader();

                bool encontrado = false;

                while ((reader.Read()) && (!encontrado))
                {
                    convocatoria.Id = ((int)reader["Id"]);
                    convocatoria.Titulo = ((string)reader["Titulo"]);
                    convocatoria.Logo = ((string)reader["Logo"]);
                    convocatoria.Descripcion = ((string)reader["Descripcion"]);
                    convocatoria.Quorum = ((int)reader["Quorum"]);
                    convocatoria.Categoria = ((Tematica)reader["Categoria"]);
                    convocatoria.Coordenadas = ((string)reader["Coordenadas"]);
                    
                    if (((int)reader["Id"]) == id)
                    {
                        encontrado = true;
                    }
                }

                return convocatoria;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }

        //---------------------------------------------------------------------------------
        public List<Convocatoria> ObtenerListado(SqlConnection conexion, SqlTransaction transaccion)
        {
            SqlDataReader reader = null;

            List<Convocatoria> _convocatoria = new List<Convocatoria>();

            try
            {
                command = conexion.CreateCommand();
                command.Transaction = transaccion;
                command.Connection = conexion;

                command.CommandText = "SELECT * FROM Convocatoria";

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Convocatoria varConvocatoria = new Convocatoria();

                    varConvocatoria.Id = ((int)reader["Id"]);
                    varConvocatoria.Titulo = ((string)reader["Titulo"]);
                    varConvocatoria.Logo = ((string)reader["Logo"]);
                    varConvocatoria.Descripcion = ((string)reader["Descripcion"]);
                    varConvocatoria.Quorum = ((int)reader["Quorum"]);
                    varConvocatoria.Categoria = ((Tematica)reader["Categoria"]);
                    varConvocatoria.Coordenadas = ((string)reader["Coordenadas"]);

                    _convocatoria.Add(varConvocatoria);
                }

                return _convocatoria;
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
