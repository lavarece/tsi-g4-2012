using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.Common.Entities;

namespace IndignaFwk.UI.Process
{
    public interface IGrupoUserProcess
    {
        int CrearGrupo(Grupo grupo);

        List<Grupo> ObtenerListadoGrupos();

        Grupo ObtenerGrupoPorUrl(string url);        
    }
}
