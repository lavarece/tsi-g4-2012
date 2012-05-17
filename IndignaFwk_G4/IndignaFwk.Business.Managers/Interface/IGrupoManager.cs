using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.Common.Entities;

namespace IndignaFwk.Business.Managers
{
    public interface IGrupoManager
    {
        int CrearNuevoGrupo(Grupo grupo);

        List<Grupo> ObtenerTodosLosGrupos();
        
        Grupo ObtenerGrupoPorId(int idGrupo);

        Grupo ObtenerGrupoPorUrl(string url);
        
        void EditarGrupo(Grupo grupo);
        
        void EliminarImagenes(List<Imagen> imagenes);

        void EliminarGrupo(Int32 idGrupo);

    }
}
