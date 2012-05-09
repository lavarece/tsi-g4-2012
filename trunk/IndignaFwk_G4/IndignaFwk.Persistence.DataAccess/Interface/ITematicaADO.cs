using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.Business.Entities;

namespace IndignaFwk.Persistence.DataAccess
{
    public interface ITematicaADO
    {
        long crear(Tematica tematica);

        void editar(Tematica tematica);

        void eliminar(long id);

        Tematica obtener(long id);

        List<Tematica> obtenerListado();
    }
}
