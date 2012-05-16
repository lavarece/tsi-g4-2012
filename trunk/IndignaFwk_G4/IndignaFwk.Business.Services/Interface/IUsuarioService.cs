using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using IndignaFwk.Business.Entities;

namespace IndignaFwk.Business.Services
{
    [ServiceContract(
    Namespace = "http://localhost//IndignaFwk//admin//2012",
    SessionMode = SessionMode.Allowed)]
    public interface IUsuarioService
    {
        [OperationContract]
        Int32 CrearUsuario(Usuario usuario);
    }
}
