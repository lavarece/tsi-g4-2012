using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.Business.Entities;

namespace IndignaFwk.Business.Managers
{
    public interface IGrupoManager
    {
        public Int32 CrearNuevoGrupo(Grupo grupo);

        public List<Grupo> ObtenerTodosLosGrupos();
        
        public Grupo ObtenerGrupoPorId(Int32 idGrupo);
        
        public void EditarGrupo(Grupo grupo);
        
        public void EliminarImagenes(List<Imagen> imagenes);

        public void EliminarGrupo(Int32 idGrupo);

    }
}
