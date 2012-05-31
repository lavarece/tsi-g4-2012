using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.Common.Entities;
using IndignaFwk.Common.Util;
using System.Data.SqlClient;
using System.Data;

namespace IndignaFwk.Persistence.DataAccess
{
    public interface ILayoutADO
    {
        Layout Obtener(int id, SqlConnection conexion);

        List<Layout> ObtenerListado(SqlConnection conexion);        
    }
}
