using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.Common.Entities;
using System.Data.SqlClient;

namespace IndignaFwk.Persistence.DataAccess
{
    public class GrupoADO : IGrupoADO
    {
        private SqlCommand command;    
        
        public int Crear(Grupo sitio, SqlConnection conexion)
        {
            command = new SqlCommand("Insert into Sitio(Nombre, LogoUrl, Descripcion, Url) values(@nombre, @logoUrl, @descripcion, @url)", conexion);
            command.Parameters.AddWithValue("nombre", sitio.Nombre);
            command.Parameters.AddWithValue("logoUrl", sitio.LogoUrl);
            command.Parameters.AddWithValue("descripcion", sitio.Descripcion);
            command.Parameters.AddWithValue("url", sitio.Url);

            command.ExecuteNonQuery();

            return 0;
        }

        public void Editar(Grupo grupo, SqlConnection conexion)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(int id, SqlConnection conexion)
        {
            throw new NotImplementedException();
        }

        //to do
        public Grupo Obtener(int id, SqlConnection conexion)
        {
            SqlDataReader reader = null;

            Grupo grupo = new Grupo();

            command = new SqlCommand("Select * from Sitio where Id = @id", conexion);

            SqlParameter param = new SqlParameter();

            param.ParameterName = "@id";

            param.Value = id;

            command.Parameters.Add(param);

            reader = command.ExecuteReader();

            while (reader.Read())
            {
                grupo.Id = ((int)reader["Id"]);
                grupo.Nombre = ((string)reader["Nombre"]);
                grupo.LogoUrl = ((string)reader["LogoUrl"]);
                grupo.Descripcion = ((string)reader["Descripcion"]);
                grupo.Url = ((string)reader["Url"]);    
            }

            return grupo;
        }


        /******** ADO que obtiene un grupo por su url ************/

        public Grupo ObtenerPorUrl(string url, SqlConnection conexion)
        {
            SqlDataReader reader = null;

            Grupo grupo = new Grupo();
            
            try
            {
                command = new SqlCommand("Select * from Sitio where Url = @url", conexion);

                SqlParameter param = new SqlParameter();

                param.ParameterName = "@url";

                param.Value = url;

                command.Parameters.Add(param);

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    grupo.Id = ((int)reader["Id"]);
                    grupo.Nombre = ((string)reader["Nombre"]);
                    grupo.LogoUrl = ((string)reader["LogoUrl"]);
                    grupo.Descripcion = ((string)reader["Descripcion"]);
                    grupo.Url = ((string)reader["Url"]);
                }

                return grupo;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }


        /*****  ADO que obtiene el listado de todos los usuarios *******/
        // to do
        public List<Grupo> ObtenerListado(SqlConnection conexion)
        {
            SqlDataReader reader = null;

            List<Grupo> _grupo = new List<Grupo>();

            command = new SqlCommand("Select * from Sitio", conexion);

            reader = command.ExecuteReader();


            while (reader.Read())
            {
                Grupo varGrupo = new Grupo();

                varGrupo.Id = ((int) reader["Id"]);
                varGrupo.Nombre = ((string) reader["Nombre"]);
                varGrupo.LogoUrl = ((string) reader["LogoUrl"]);
                varGrupo.Descripcion = ((string) reader ["Descripcion"]);
                varGrupo.Url = ((string) reader["Url"]);          

                _grupo.Add(varGrupo);
            }

            return _grupo;
        }
    }
}
