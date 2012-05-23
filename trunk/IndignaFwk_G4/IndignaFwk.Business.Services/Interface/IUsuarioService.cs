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
    public interface IUsuarioService
    {
        [OperationContract]
        int CrearNuevoUsuario(Usuario usuario);

        [OperationContract]
        List<Usuario> ObtenerListadoUsuarios();

        [OperationContract]
        Usuario ObtenerUsuarioPorId(int idUsuario);

        [OperationContract]
        void EditarUsuario(Usuario usuario);

        [OperationContract]
        void EliminarUsuario(int idUsuario);
    }
}
