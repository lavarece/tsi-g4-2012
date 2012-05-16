using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using IndignaFwk.Business.Entities;
using IndignaFwk.Business.Managers;

namespace IndignaFwk.Business.Services
{
    public class GrupoService : IGrupoService
    {
        public Int32 CrearGrupo(Grupo grupo)
        {
            return ManagerFactory.Instance.GrupoManager.CrearNuevoGrupo(grupo);
        }
    }
}
