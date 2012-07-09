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
        List<Convocatoria> ObtenerConvocatoriasPorFiltro(FiltroBusqueda filtroBusqueda);
        
        [OperationContract]
        List<Convocatoria> ObtenerListadoConvocatoriasPorGrupo(int idGrupo);

        [OperationContract]
        Convocatoria ObtenerConvocatoriaPorId(int idConvocatoria);

        [OperationContract]
        void EditarConvocatoria(Convocatoria convocatoria);

        [OperationContract]
        void EliminarConvocatoria(int idConvocatoria);
        
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
        void EliminarAsistenciaConvocatoria(int idAsistenciaConvocatoria);
    }
}
