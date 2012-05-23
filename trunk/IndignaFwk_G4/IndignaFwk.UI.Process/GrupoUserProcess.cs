using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.Common.Entities;
using IndignaFwk.UI.Process.GrupoService;   

namespace IndignaFwk.UI.Process
{
    public class GrupoUserProcess
    {
        public int CrearNuevoGrupo(Grupo grupo)
        {
            GrupoServiceClient proxy = new GrupoServiceClient();

            int idGrupo = proxy.CrearNuevoGrupo(grupo);

            proxy.Close();

            return idGrupo;
        }

        public List<Grupo> ObtenerListadoGrupos()
        {
            GrupoServiceClient proxy = new GrupoServiceClient();

            List<Grupo> listaGrupos = proxy.ObtenerListadoGrupos();

            proxy.Close();

            return listaGrupos;
        }

        public Grupo ObtenerGrupoPorId(int idGrupo)
        {
            GrupoServiceClient proxy = new GrupoServiceClient();

            Grupo grupo = proxy.ObtenerGrupoPorId(idGrupo);

            proxy.Close();

            return grupo;
        }

        public Grupo ObtenerGrupoPorUrl(string url)
        {
            GrupoServiceClient proxy = new GrupoServiceClient();

            Grupo grupo = proxy.ObtenerGrupoPorUrl(url);

            proxy.Close();

            return grupo;
        }

        public void EditarGrupo(Grupo grupo)
        {
            GrupoServiceClient proxy = new GrupoServiceClient();

            proxy.EditarGrupo(grupo);

            proxy.Close();
        }

        public void EliminarGrupo(int idGrupo)
        {
            GrupoServiceClient proxy = new GrupoServiceClient();

            proxy.EliminarGrupo(idGrupo);

            proxy.Close();
        }
    }
}
