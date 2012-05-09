using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.Business.Entities;

namespace IndignaFwk.Persistence.DataAccess
{
    public interface IVariableSistemaADO
    {
        long crear(VariableSistema variableSistema);

        void editar(VariableSistema variableSistema);

        void eliminar(long id);

        VariableSistema obtener(long id);

        List<VariableSistema> obtenerListado();
    }
}
