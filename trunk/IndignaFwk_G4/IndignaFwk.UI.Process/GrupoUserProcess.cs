using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.Common.Entities;
using IndignaFwk.UI.Process.GrupoReference;

namespace IndignaFwk.UI.Process
{
    public class GrupoUserProcess : IGrupoUserProcess
    {
        public Int32 CrearGrupo(Grupo grupo)
        {
            GrupoServiceClient grupoServiceProxy = new GrupoServiceClient();

            Int32 idGrupo = grupoServiceProxy.CrearGrupo(new Grupo());

            grupoServiceProxy.Close();

            return idGrupo;
        }
    }
}
