using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndignaFwk.Business.Managers
{
    public class ManagerFactory
    {
        // PROPERTIES MANAGERS
        private IConvocatoriaManager convocatoriaManager;

        private IGrupoManager grupoManager;

        private ISistemaManager sistemaManager;

        private IUsuarioManager usuarioManager;

        // SINGLETON FACTORY
        private ManagerFactory() { }

        private static ManagerFactory instance;

        public static ManagerFactory Instance()
        {
            if (instance == null)
            {
                instance = new ManagerFactory();
            }

            return instance;
        }

        // GETTERS MANAGERS
        public IConvocatoriaManager GetConvocatoriaManager()
        {
            if (convocatoriaManager == null)
            {
                convocatoriaManager = new ConvocatoriaManager();
            }

            return convocatoriaManager;
        }

        public IGrupoManager GetGrupoManager()
        {
            if (grupoManager == null)
            {
                grupoManager = new GrupoManager();
            }

            return grupoManager;
        }

        public ISistemaManager GetSistemaManager()
        {
            if (sistemaManager == null)
            {
                sistemaManager = new SistemaManager();
            }

            return sistemaManager;
        }

        public IUsuarioManager GetUsuarioManager()
        {
            if (usuarioManager == null)
            {
                usuarioManager = new UsuarioManager();
            }

            return usuarioManager;
        }
    }
}
