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
        public Int32 Crear(Sitio grupo, SqlConnection conexion)
        {
            SqlCommand comando = new SqlCommand("Insert into Sitio(Nombre, LogoUrl, Descripcion, Url) values(@nombre, @logoUrl, @descripcion, @url)", conexion);
         
            comando.Parameters.AddWithValue("nombre", grupo.Nombre);
            comando.Parameters.AddWithValue("logoUrl", grupo.LogoUrl);
            comando.Parameters.AddWithValue("descripcion", grupo.Descripcion);
            comando.Parameters.AddWithValue("url", grupo.Url);

            comando.ExecuteNonQuery();

            throw new NotImplementedException();
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

        public List<Sitio> ObtenerListado()
        {
            throw new NotImplementedException();
        }
    }
}
