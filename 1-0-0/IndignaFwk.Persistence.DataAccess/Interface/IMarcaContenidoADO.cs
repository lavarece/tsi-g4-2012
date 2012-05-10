using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.Business.Entities;

namespace IndignaFwk.Persistence.DataAccess
{
    public interface IMarcaContenidoADO
    {
        Int32 Crear(MarcaContenido marcaContenido);

        void Editar(MarcaContenido marcaContenido);

        void Eliminar(long id);

        MarcaContenido Obtener(long id);

        List<MarcaContenido> ObtenerListado();
    }
}
