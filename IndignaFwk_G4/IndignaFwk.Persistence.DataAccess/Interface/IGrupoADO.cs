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
        Int32 Crear(Grupo grupo, SqlConnection conexion);

        void Editar(Grupo grupo);

        void Eliminar(long id);

        Grupo Obtener(long id);

        List<Grupo> ObtenerListado();
    }
}
