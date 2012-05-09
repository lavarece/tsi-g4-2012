using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.Business.Entities;

namespace IndignaFwk.Persistence.DataAccess
{
    public interface IUsuTematicaADO
    {
        long crear(UsuTematica usuTematica);

        void editar(UsuTematica usuTematica);

        void eliminar(long id);

        UsuTematica obtener(long id);

        List<UsuTematica> obtenerListado();
    }
}
