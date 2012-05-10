using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.Business.Entities;

namespace IndignaFwk.Persistence.DataAccess
{
    public interface IUsuTematicaADO
    {
        Int32 Crear(UsuTematica usuTematica);

        void Editar(UsuTematica usuTematica);

        void Eliminar(long id);

        UsuTematica Obtener(long id);

        List<UsuTematica> ObtenerListado();
    }
}
