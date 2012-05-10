using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.Business.Entities;

namespace IndignaFwk.Persistence.DataAccess
{
    public interface ITematicaADO
    {
        Int32 Crear(Tematica tematica);

        void Editar(Tematica tematica);

        void Eliminar(long id);

        Tematica Obtener(long id);

        List<Tematica> ObtenerListado();
    }
}
