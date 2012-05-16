using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.Common.Entities;

namespace IndignaFwk.Persistence.DataAccess
{
    public interface INotificacionADO
    {
        Int32 Crear(Notificacion notificacion);

        void Editar(Notificacion notificacion);

        void Eliminar(long id);

        Notificacion Obtener(long id);

        List<Notificacion> ObtenerListado();
    }
}
