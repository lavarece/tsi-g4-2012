using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using IndignaFwk.Common.Entities;
using IndignaFwk.Business.Managers;

namespace IndignaFwk.Business.Services
{    
    public class GrupoService : IGrupoService
    {
        public int CrearGrupo(Grupo grupo)
        {
            return GrupoManager.CrearNuevoGrupo(grupo);
        }
        
        public List<Grupo> ObtenerListadoGrupos()
        {
            return GrupoManager.ObtenerTodosLosGrupos();
        }

        public Grupo ObtenerGrupoPorUrl(string url)
        {
            return GrupoManager.ObtenerGrupoPorUrl(url);
        }

        public Grupo ObtenerGrupoPorId(int id)
        {
            return GrupoManager.ObtenerGrupoPorId(id);
        }

        // DEPENDENCIAS MANAGERS
        private IGrupoManager GrupoManager
        {
            get
            {
                return ManagerFactory.Instance.GrupoManager;
            }
        }
    }
}
