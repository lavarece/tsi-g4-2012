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

        List<Contenido> ObtenerListadoContenidosPorGrupoYVisibilidad(int idGrupo, string visibilidadContenido);

        Contenido ObtenerContenidoPorId(int idContenido);

        // Operaciones AsistenciaConvocatoria
        int CrearNuevaAsistenciaConvocatoria(AsistenciaConvocatoria asistenciaConvocatoria);

        // Operaciones MarcaContenido
        MarcaContenido ObtenerMarcaContenidoPorUsuarioYContenido(int idUsuario, int idContenido);

        int CrearNuevaMarcaContenido(MarcaContenido marcaContenido);

        void EditarMarcaContenido(MarcaContenido marcaContenido);
    }
}
