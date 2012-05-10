using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndignaFwk.Business.Managers
{
    public class ManagerFactory
    {
        private IConvocatoriaManager convocatoriaManager;

        private IGrupoManager grupoManager;

        private ISistemaManager sistemaManager;

        private IUsuarioManager usuarioManager;

        public IConvocatoriaManager getConvocatoryManager()
        {
            if (convocatoriaManager == null)
            {
                convocatoriaManager = new ConvocatoriaManager();
            }

            return convocatoriaManager;
        }

        public IGrupoManager getGrupoManager()
        {
            if (grupoManager == null)
            {
                grupoManager = new GrupoManager();
            }

            return grupoManager;
        }

        public ISistemaManager getSistemaManager()
        {
            if (sistemaManager == null)
            {
                sistemaManager = new SistemaManager();
            }

            return sistemaManager;
        }

        public IUsuarioManager getUsuarioManager()
        {
            if(usuarioManager == null)
            {
                usuarioManager = new UsuarioManager();
            }

            return usuarioManager;

    }
}
