using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.Business.Entities;

namespace IndignaFwk.Persistence.DataAccess
{
    public interface IMarcaContenidoADO
    {
        long crear(MarcaContenido marcaContenido);

        void editar(MarcaContenido marcaContenido);

        void eliminar(long id);

        MarcaContenido obtener(long id);

        List<MarcaContenido> obtenerListado();
    }
}
