using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.Business.Entities;

namespace IndignaFwk.Business.Managers
{
    public interface IGrupoManager
    {
        public void CrearNuevoSitio(Sitio grupo);

        public List<Sitio> ObtenerTodosLosSitios();
        
        public Sitio ObtenerSitioPorId(long id);
        
        public void GuardarSitio(Sitio grupo);
        
        public void EliminarImagenes(List<Imagen> imagenes);

        public void EliminarSitio(long idSitio);

    }
}
