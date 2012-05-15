using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.Business.Entities;
using System.Data.SqlClient;

namespace IndignaFwk.Persistence.DataAccess
{
    public interface IGrupoADO
    {
        Int32 Crear(Sitio grupo, SqlConnection conexion);

        void Editar(Sitio grupo);

        void Eliminar(long id);

        Sitio Obtener(long id);

        List<Sitio> ObtenerListado();
    }
}
