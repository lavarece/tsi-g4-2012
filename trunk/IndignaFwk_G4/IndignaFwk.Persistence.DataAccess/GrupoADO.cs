using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.Business.Entities;
using System.Data.SqlClient;

namespace IndignaFwk.Persistence.DataAccess
{
    public class GrupoADO : IGrupoADO
    {
        private SqlCommand command;    
        
        public Int32 Crear(Grupo sitio, SqlConnection conexion)
        {
            command = new SqlCommand("Insert into Sitio(Nombre, LogoUrl, Descripcion, Url) values(@nombre, @logoUrl, @descripcion, @url)", conexion);
            command.Parameters.AddWithValue("nombre", sitio.Nombre);
            command.Parameters.AddWithValue("logoUrl", sitio.LogoUrl);
            command.Parameters.AddWithValue("descripcion", sitio.Descripcion);
            command.Parameters.AddWithValue("url", sitio.Url);

            command.ExecuteNonQuery();

            return 0;
        }

        public void Editar(Grupo grupo)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(Int32 id)
        {
            throw new NotImplementedException();
        }

        public Grupo Obtener(Int32 id, SqlConnection conexion)
        {
            throw new NotImplementedException();
        }

        public List<Grupo> ObtenerListado(SqlConnection conexion)
        {
            SqlDataReader reader = null;

            List<Grupo> _grupo = new List<Grupo>();

            command = new SqlCommand("Select * from Sitio", conexion);

            reader = command.ExecuteReader();


            while (reader.Read())
            {
                Grupo varGrupo = new Grupo();

                varGrupo.Id = ((Int32) reader["Id"]);
                varGrupo.Nombre = ((String) reader["Nombre"]);
                varGrupo.LogoUrl = ((String) reader["LogoUrl"]);
                varGrupo.Descripcion = ((String) reader ["Descripcion"]);
                varGrupo.LogoUrl = ((String) reader["Url"]);          

                _grupo.Add(varGrupo);
            }

            return _grupo;
        }
    }
}
