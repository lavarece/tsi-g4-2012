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

        /* Operaciones con layouts */
        [OperationContract]
        Layout ObtenerLayoutPorId(int idLayout);

        [OperationContract]
        List<Layout> ObtenerListadoLayouts();

        /* Operaciones con tematicas */
        [OperationContract]
        Tematica ObtenerTematicaPorId(int idTematica);

        [OperationContract]
        List<Tematica> ObtenerListadoTematicas();

    }
}
