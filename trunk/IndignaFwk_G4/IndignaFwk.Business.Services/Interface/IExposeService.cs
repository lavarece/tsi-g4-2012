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
    public interface IExposeService
    {
        [OperationContract]
        List<Contenido> ObtenerContenidosPorTematica(int idTematica);

        [OperationContract]
        List<Convocatoria> ObtenerConvocatoriasPorTematica(int idTematica);
    }
}
