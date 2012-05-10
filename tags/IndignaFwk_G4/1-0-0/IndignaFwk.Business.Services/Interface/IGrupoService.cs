using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using IndignaFwk.Business.Entities;

namespace IndignaFwk.Business.Services
{
    [ServiceContract(
    Namespace = "http://localhost//IndignaFwk//2012",
    SessionMode = SessionMode.Allowed)] 
    public interface IGrupoService
    {
        [OperationContract]
        Int32 crearGrupo(Grupo grupo);
    }
}
