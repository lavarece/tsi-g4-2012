using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using IndignaFwk.Common.Entities;

namespace IndignaFwk.Business.Services
{
    [ServiceContract(
    Namespace = "http://localhost//IndignaFwk//2012",
    SessionMode = SessionMode.Allowed)] 
    public interface IGrupoService
    {
        [OperationContract]
        int CrearGrupo(Grupo grupo);

        [OperationContract]
        List<Grupo> ObtenerListadoGrupos();

        [OperationContract]
        Grupo ObtenerGrupoPorUrl(string url);
    }
}
