using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.Common.Entities;

namespace IndignaFwk.Business.Managers
{
    public interface IConvocatoriaManager
    {
        int CrearNuevaConvocatoria(Convocatoria convocatoria);

        List<Convocatoria> ObtenerListadoConvocatorias();

        Convocatoria ObtenerConvocatoriaPorId(int idConvocatoria);

        void EditarConvocatoria(Convocatoria convocatoria);

        void EliminarConvocatoria(int idConvocatoria);
    }
}
