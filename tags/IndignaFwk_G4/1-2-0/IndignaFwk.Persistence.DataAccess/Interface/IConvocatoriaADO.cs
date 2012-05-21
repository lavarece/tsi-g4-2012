using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.Common.Entities;

namespace IndignaFwk.Persistence.DataAccess
{
    public interface IConvocatoriaADO
    {
       int Crear(Convocatoria convocatoria);

        void Editar(Convocatoria convocatoria);

        void Eliminar(int id);

        Contenido Obtener(int id);

        List<Contenido> ObtenerListado();
    }
}
