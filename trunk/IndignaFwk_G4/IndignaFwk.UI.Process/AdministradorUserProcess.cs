using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.Common.Entities;
using IndignaFwk.UI.Process.AdministradorService;

namespace IndignaFwk.UI.Process
{
    public class AdministradorUserProcess
    {
        public int CrearNuevoAdministrador(Administrador administrador)
        {
            AdministradorServiceClient proxy = new AdministradorServiceClient();

            int id = proxy.CrearNuevoAdministrador(administrador);

            proxy.Close();

            return id;
        }

        public List<Administrador> ObtenerListadoAdministradores()
        {
            AdministradorServiceClient proxy = new AdministradorServiceClient();

            List<Administrador> listaAdministradores = proxy.ObtenerListadoAdministradores();

            proxy.Close();

            return listaAdministradores;
        }

        public Administrador ObtenerAdministradorPorId(int idAdministrador)
        {
            AdministradorServiceClient proxy = new AdministradorServiceClient();

            Administrador administrador = proxy.ObtenerAdministradorPorId(idAdministrador);

            proxy.Close();

            return administrador;
        }

        public void EditarAdministrador(Administrador administrador)
        {
            AdministradorServiceClient proxy = new AdministradorServiceClient();

            proxy.EditarAdministrador(administrador);

            proxy.Close();
        }

        public void EliminarAdministrador(int idAdministrador)
        {
            AdministradorServiceClient proxy = new AdministradorServiceClient();

            proxy.EliminarAdministrador(idAdministrador);

            proxy.Close();
        }

        public Administrador ObtenerAdministradorPorEmailYPass(string email, string pass)
        {
            AdministradorServiceClient proxy = new AdministradorServiceClient();

            Administrador administrador = proxy.ObtenerAdministradorPorEmailYPass(email, pass);
            
            proxy.Close();

            return administrador;

        }
    }
}
