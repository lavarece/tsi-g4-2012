using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.Business.Entities;

namespace IndignaFwk.Persistence.DataAccess
{
    public interface IVariableSistemaADO
    {
        Int32 Crear(VariableSistema variableSistema);

        void Editar(VariableSistema variableSistema);

        void Eliminar(long id);

        VariableSistema Obtener(long id);

        List<VariableSistema> ObtenerListado();
    }
}
