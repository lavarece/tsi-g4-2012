using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndignaFwk.Business.Managers
{
    public class ManagerFactory
    {
        // SINGLETON FACTORY
        private ManagerFactory() { }

        private static ManagerFactory _instance;

        public static ManagerFactory Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ManagerFactory();
                }

                return _instance;
            }
        }

        // MANAGERS
        private IConvocatoriaManager _convocatoriaManager;

        public IConvocatoriaManager ConvocatoriaManager
        {
            get
            {
                if (_convocatoriaManager == null)
                {
                    _convocatoriaManager = new ConvocatoriaManager();
                }

                return _convocatoriaManager;
            }            
        }

        private IGrupoManager _grupoManager;

        public IGrupoManager GrupoManager
        {
            get
            {
                if (_grupoManager == null)
                {
                    _grupoManager = new GrupoManager();
                }

                return _grupoManager;
            }            
        }

        private ISistemaManager _sistemaManager;

        public ISistemaManager SistemaManager
        {
            get
            {
                if (_sistemaManager == null)
                {
                    _sistemaManager = new SistemaManager();
                }

                return _sistemaManager;
            }            
        }

        private IUsuarioManager _usuarioManager;

        public IUsuarioManager UsuarioManager
        {
            get
            {
                if (_usuarioManager == null)
                {
                    _usuarioManager = new UsuarioManager();
                }

                return _usuarioManager;
            }            
        }

        private IAdministradorManager _administradorManager;

        public IAdministradorManager AdministradorManager
        {
            get
            {
                if (_administradorManager == null)
                {
                    _administradorManager = new AdministradorManager();
                }

                return _administradorManager;
            }
        }
    }
}
