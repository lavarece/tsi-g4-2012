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
        private IGrupoManager grupoManger = ManagerFactory.Instance.GrupoManager;

        public int CrearNuevoGrupo(Grupo grupo)
        {
            return grupoManger.CrearNuevoGrupo(grupo);
        }

        public List<Grupo> ObtenerListadoGrupos()
        {
            return grupoManger.ObtenerListadoGrupos();
        }

        public Grupo ObtenerGrupoPorId(int idGrupo)
        {
            return grupoManger.ObtenerGrupoPorId(idGrupo);
        }

        public Grupo ObtenerGrupoPorUrl(string url)
        {
            return grupoManger.ObtenerGrupoPorUrl(url);
        }

        public void EditarGrupo(Grupo grupo)
        {
            grupoManger.EditarGrupo(grupo);
        }

        public void EliminarGrupo(int idGrupo)
        {
            grupoManger.EliminarGrupo(idGrupo);
        }
    }
}
