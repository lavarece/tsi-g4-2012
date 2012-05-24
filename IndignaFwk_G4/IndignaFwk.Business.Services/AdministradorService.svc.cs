using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using IndignaFwk.Business.Managers;
using IndignaFwk.Common.Entities;

namespace IndignaFwk.Business.Services
{
    public class AdministradorService : IAdministradorService
    {
        private IAdministradorManager administradorManager = ManagerFactory.Instance.AdministradorManager;

        public int CrearNuevoAdministrador(Administrador administrador)
        {
            return administradorManager.CrearNuevoAdministrador(administrador);
        }

        public List<Administrador> ObtenerListadoAdministradores()
        {
            return administradorManager.ObtenerListadoAdministradores();
        }

        public Administrador ObtenerAdministradorPorId(int idAdministrador)
        {
            return administradorManager.ObtenerAdministradorPorId(idAdministrador);
        }

        public void EditarAdministrador(Administrador administrador)
        {
            administradorManager.EditarAdministrador(administrador);
        }

        public void EliminarAdministrador(int idAdministrador)
        {
            administradorManager.EliminarAdministrador(idAdministrador);
        }
    }
}
