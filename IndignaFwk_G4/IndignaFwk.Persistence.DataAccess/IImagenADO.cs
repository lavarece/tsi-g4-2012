using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.Business.Entities;

namespace IndignaFwk.Persistence.DataAccess
{
    public interface IImagenADO
    {
        long crear(Imagen imagen);

        void editar(Imagen imagen);

        void eliminar(long id);

        Imagen obtener(long id);

        List<Imagen> obtenerListado();
    }
}
