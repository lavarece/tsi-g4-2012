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
    public interface IAdministradorService
    {
        [OperationContract]
        int CrearNuevoAdministrador(Administrador administrador);

        [OperationContract]
        List<Administrador> ObtenerListadoAdministradores();

        [OperationContract]
        Administrador ObtenerAdministradorPorId(int idAdministrador);

        [OperationContract]
        Administrador ObtenerAdministradorPorEmailYPass(string email, string pass);

        [OperationContract]
        void EditarAdministrador(Administrador administrador);

        [OperationContract]
        void EliminarAdministrador(int idAdministrador);       
    }
}
