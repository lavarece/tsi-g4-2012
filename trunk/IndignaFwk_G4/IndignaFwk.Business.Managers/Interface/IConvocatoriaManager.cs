using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.Common.Entities;

namespace IndignaFwk.Business.Managers
{
    public interface IConvocatoriaManager
    {
        // Operaciones convocatorias
        int CrearNuevaConvocatoria(Convocatoria convocatoria);

        List<Convocatoria> ObtenerListadoConvocatorias();

        Convocatoria ObtenerConvocatoriaPorId(int idConvocatoria);

        void EditarConvocatoria(Convocatoria convocatoria);

        void EliminarConvocatoria(int idConvocatoria);

        // Operaciones Contenidos
        int CrearNuevoContenido(Contenido contenido);

        List<Contenido> ObtenerListadoContenidos();

        Contenido ObtenerContenidoPorId(int idContenido);

        // Operaciones AsistenciaConvocatoria
        int CrearNuevaAsistenciaConvocatoria(AsistenciaConvocatoria asistenciaConvocatoria);
    }
}
