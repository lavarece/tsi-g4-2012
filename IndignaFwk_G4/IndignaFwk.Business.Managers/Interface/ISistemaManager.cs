using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.Persistence.DataAccess;
using IndignaFwk.Common.Entities;
using IndignaFwk.Common.Util;
using System.Data.SqlClient;

namespace IndignaFwk.Business.Managers
{
    public interface ISistemaManager
    {
        /* Operaciones con variables del sistema */
        int CrearNuevaVariable(VariableSistema variable);
        
        VariableSistema ObtenerVariablePorId(int idVariable);

        VariableSistema ObtenerVariablePorNombre(string nombreVariable);
        
        void EditarVariable(VariableSistema variableSistema);

        List<VariableSistema> ObtenerTodosLasVariables();

        /* Operaciones con layouts */
        Layout ObtenerLayoutPorId(int idLayout);

        List<Layout> ObtenerListadoLayouts();

        /* Operaciones con tematicas */
        Tematica ObtenerTematicaPorId(int idTematica);

        List<Tematica> ObtenerListadoTematicas();

    }
}
