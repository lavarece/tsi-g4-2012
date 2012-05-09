using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.Business.Entities;

namespace IndignaFwk.Persistence.DataAccess
{
    public interface INotificacionADO
    {
        long crear(Notificacion notificacion);

        void editar(Notificacion notificacion);

        void eliminar(long id);

        Notificacion obtener(long id);

        List<Notificacion> obtenerListado();
    }
}
