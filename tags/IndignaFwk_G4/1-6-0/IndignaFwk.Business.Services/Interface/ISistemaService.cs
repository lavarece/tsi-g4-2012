using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using IndignaFwk.Common.Entities;

namespace IndignaFwk.Business.Services
{
    [ServiceContract]
    public interface ISistemaService
    {
        [OperationContract]
        List<VariableSistema> ObtenerListadoVariables();

        [OperationContract]
        VariableSistema ObtenerVariablePorId(int idVariable);

        [OperationContract]
        VariableSistema ObtenerVariablePorNombre(string nombre);

        [OperationContract]
        void EditarVariableSistema(VariableSistema variableSistema);

    }
}
