using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.Common.Entities;
using IndignaFwk.Common.Filter;

namespace IndignaFwk.Business.Managers
{
    public interface IConvocatoriaManager
    {
        // Operaciones convocatorias
        int CrearNuevaConvocatoria(Convocatoria convocatoria);

        List<Convocatoria> ObtenerConvocatoriasPorFiltro(FiltroBusqueda filtroBusqueda);

        List<Convocatoria> ObtenerListadoConvocatoriasPorGrupo(int idGrupo);

        List<Convocatoria> ObtenerListadoPorTematica(int idTematica);

        Convocatoria ObtenerConvocatoriaPorId(int idConvocatoria);

        void EditarConvocatoria(Convocatoria convocatoria);

        void EliminarConvocatoria(int idConvocatoria);

        // Operaciones AsistenciaConvocatoria
        int CrearNuevaAsistenciaConvocatoria(AsistenciaConvocatoria asistenciaConvocatoria);

        List<AsistenciaConvocatoria> ObtenerAsistenciaConvocatoriaPorIdUsuario(int idUsuario);

        AsistenciaConvocatoria ObtenerAsistenciaConvocatoriaPorUsuarioYConvocatoria(int idUsuario, int idConvocatoria);

        void EditarAsistenciaConvocatoria(AsistenciaConvocatoria asistenciaConvocatoria);

        void EliminarAsistenciaConvocatoria(int idAsistenciaConvocatoria);
    }
}
