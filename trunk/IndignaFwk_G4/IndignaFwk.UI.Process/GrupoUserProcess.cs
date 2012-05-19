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
        public int CrearGrupo(Grupo grupo)
        {
            GrupoServiceClient grupoProxy = new GrupoServiceClient();

            int idGrupo = grupoProxy.CrearGrupo(grupo);

            grupoProxy.Close();

            return idGrupo;
        }


        public List<Grupo> ObtenerListadoGrupos()
        {
            GrupoServiceClient grupoProxy = new GrupoServiceClient();

            Grupo[] arrayGrupos = grupoProxy.ObtenerListadoGrupos();

            grupoProxy.Close();

            // Transformo a una List<Grupo>
            List<Grupo> listaGrupos = new List<Grupo>();

            if (arrayGrupos != null)
            {
                foreach (Grupo itemGrupo in arrayGrupos)
                {
                    listaGrupos.Add(itemGrupo);
                }
            }

            return listaGrupos;
        }

        public Grupo ObtenerGrupoPorUrl(string url)
        {
            GrupoServiceClient grupoProxy = new GrupoServiceClient();

            Grupo grupo = grupoProxy.ObtenerGrupoPorUrl(url);

            grupoProxy.Close();

            return grupo;
        }
    }
}
