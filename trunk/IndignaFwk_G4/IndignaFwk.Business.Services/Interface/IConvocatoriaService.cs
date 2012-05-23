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
        [OperationContract]
        int CrearNuevaConvocatoria(Convocatoria convocatoria);

        [OperationContract]
        List<Convocatoria> ObtenerListadoConvocatorias();

        [OperationContract]
        Convocatoria ObtenerConvocatoriaPorId(int idConvocatoria);

        [OperationContract]
        void EditarConvocatoria(Convocatoria convocatoria);

        [OperationContract]
        void EliminarConvocatoria(int idConvocatoria);
    }
}
