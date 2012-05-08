using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.Business.Entities;

namespace IndignaFwk.Persistence.DataAccess
{
    public interface IGrupoADO
    {
        long crear(Grupo grupo);

        void editar(Grupo grupo);

        void eliminar(long id);

        Grupo obtener(long id);

        List<Grupo> obtenerListado();
    }
}
