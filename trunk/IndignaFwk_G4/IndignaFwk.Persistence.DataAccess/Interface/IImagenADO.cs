using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.Common.Entities;

namespace IndignaFwk.Persistence.DataAccess
{
    public interface IImagenADO
    {
        Int32 Crear(Imagen imagen);

        void Editar(Imagen imagen);

        void Eliminar(long id);

        Imagen Obtener(long id);

        List<Imagen> ObtenerListado();
    }
}
