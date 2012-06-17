using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using IndignaFwk.Common.Entities;
using IndignaFwk.Common.Filter;

namespace IndignaFwk.Business.Services
{
    [ServiceContract]
    public interface IConvocatoriaService
    {
        // Operaciones convocatorias
        [OperationContract]
        int CrearNuevaConvocatoria(Convocatoria convocatoria);

        [OperationContract]
        List<Convocatoria> ObtenerListadoConvocatorias();
        
        [OperationContract]
        List<Convocatoria> ObtenerListadoConvocatoriasPorGrupo(int idGrupo);

        [OperationContract]
        Convocatoria ObtenerConvocatoriaPorId(int idConvocatoria);

        [OperationContract]
        void EditarConvocatoria(Convocatoria convocatoria);

        [OperationContract]
        void EliminarConvocatoria(int idConvocatoria);
        
        // Operaciones Contenidos
        [OperationContract]
        int CrearNuevoContenido(Contenido contenido);

        [OperationContract]
        List<Contenido> ObtenerListadoContenidosPorGrupoYVisibilidad(int idGrupo, string visibilidadContenido);

        [OperationContract]
        List<Contenido> ObtenerXContenidosMasRankeadosPorGrupoYVisibilidad(int idGrupo, string visibilidadContenido, int x);

        [OperationContract]
        Contenido ObtenerContenidoPorId(int idContenido);

        // Operaciones AsistenciaConvocatoria
        [OperationContract]
        int CrearNuevaAsistenciaConvocatoria(AsistenciaConvocatoria asistenciaConvocatoria);

        [OperationContract]
        AsistenciaConvocatoria ObtenerAsistenciaConvocatoriaPorUsuarioYConvocatoria(int idUsuario, int idConvocatoria);

        [OperationContract]
        void EditarAsistenciaConvocatoria(AsistenciaConvocatoria asistenciaConvocatoria);

        [OperationContract]
        List<AsistenciaConvocatoria> ObtenerAsistenciaConvocatoriaPorIdUsuario(int idUsuario);

        [OperationContract]
        List<Convocatoria> ObtenerConvocatoriasPorFiltro(FiltroBusqueda filtroBusqueda);

        [OperationContract]
        void EliminarAsistenciaConvocatoria(int idAsistenciaConvocatoria);

        // Operaciones MarcarContenido
        [OperationContract]
        MarcaContenido ObtenerMarcaContenidoPorUsuarioYContenido(int idUsuario, int idContenido);

        [OperationContract]
        int CrearNuevaMarcaContenido(MarcaContenido marcaContenido);

        [OperationContract]
        void EditarMarcaContenido(MarcaContenido marcaContenido);
    }
}
