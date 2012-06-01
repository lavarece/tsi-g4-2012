using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using IndignaFwk.Common.Entities;

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
        Contenido ObtenerContenidoPorId(int idContenido);

        // Operaciones AsistenciaConvocatoria
        [OperationContract]
        int CrearNuevaAsistenciaConvocatoria(AsistenciaConvocatoria asistenciaConvocatoria);

        // Operaciones MarcarContenido
        [OperationContract]
        MarcaContenido ObtenerMarcaContenidoPorUsuarioYContenido(int idUsuario, int idContenido);

        [OperationContract]
        int CrearNuevaMarcaContenido(MarcaContenido marcaContenido);

        [OperationContract]
        void EditarMarcaContenido(MarcaContenido marcaContenido);
    }
}
