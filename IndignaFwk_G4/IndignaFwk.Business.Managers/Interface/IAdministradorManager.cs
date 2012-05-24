using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.Common.Entities;

namespace IndignaFwk.Business.Managers
{
    public interface IAdministradorManager
    {
        int CrearNuevoAdministrador(Administrador administrador);

        List<Administrador> ObtenerListadoAdministradores();

        Administrador ObtenerAdministradorPorId(int idAdministrador);

        void EditarAdministrador(Administrador administrador);

        void EliminarAdministrador(int idAdministrador);
    }
}
