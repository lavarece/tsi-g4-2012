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

        List<Convocatoria> ObtenerListadoConvocatorias();

        List<Convocatoria> ObtenerListadoConvocatoriasPorGrupo(int idGrupo);

        Convocatoria ObtenerConvocatoriaPorId(int idConvocatoria);

        void EditarConvocatoria(Convocatoria convocatoria);

        void EliminarConvocatoria(int idConvocatoria);

        // Operaciones Contenidos
        int CrearNuevoContenido(Contenido contenido);

        List<Contenido> ObtenerListadoContenidosPorGrupoYVisibilidad(int idGrupo, string visibilidadContenido);

        List<Contenido> ObtenerXContenidosMasRankeadosPorGrupoYVisibilidad(int idGrupo, string visibilidadContenido, int x);

        Contenido ObtenerContenidoPorId(int idContenido);

        // Operaciones AsistenciaConvocatoria
        int CrearNuevaAsistenciaConvocatoria(AsistenciaConvocatoria asistenciaConvocatoria);

        List<AsistenciaConvocatoria> ObtenerAsistenciaConvocatoriaPorIdUsuario(int idUsuario);

        AsistenciaConvocatoria ObtenerAsistenciaConvocatoriaPorUsuarioYConvocatoria(int idUsuario, int idConvocatoria);

        void EditarAsistenciaConvocatoria(AsistenciaConvocatoria asistenciaConvocatoria);

        void EliminarAsistenciaConvocatoria(int idAsistenciaConvocatoria);

        List<Convocatoria> ObtenerConvocatoriasPorFiltro(FiltroBusqueda filtroBusqueda);

        // Operaciones MarcaContenido
        MarcaContenido ObtenerMarcaContenidoPorUsuarioYContenido(int idUsuario, int idContenido);

        int CrearNuevaMarcaContenido(MarcaContenido marcaContenido);

        void EditarMarcaContenido(MarcaContenido marcaContenido);
    }
}
