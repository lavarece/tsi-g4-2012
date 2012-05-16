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
        
        public Int32 Crear(Sitio sitio, SqlConnection conexion)
        {
            command = new SqlCommand("Insert into Sitio(Nombre, LogoUrl, Descripcion, Url) values(@nombre, @logoUrl, @descripcion, @url)", conexion);
            command.Parameters.AddWithValue("nombre", sitio.Nombre);
            command.Parameters.AddWithValue("logoUrl", sitio.LogoUrl);
            command.Parameters.AddWithValue("descripcion", sitio.Descripcion);
            command.Parameters.AddWithValue("url", sitio.Url);

            command.ExecuteNonQuery();

            return 0;
        }

        public void Editar(Sitio grupo)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(long id)
        {
            throw new NotImplementedException();
        }

        public Sitio Obtener(long id)
        {
            throw new NotImplementedException();
        }

        public List<Sitio> ObtenerListado(SqlConnection conexion)
        {
            SqlDataReader reader = null;

            command = new SqlCommand("Select * from Sitio", conexion);

            reader = command.ExecuteReader();

            throw new NotImplementedException();
        }
    }
}
