using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.Common.Entities;
using IndignaFwk.UI.Process.SistemaService;


namespace IndignaFwk.UI.Process
{
    public class SistemaUserProcess
    {
        public List<VariableSistema> ObtenerListadoVariable()
        {
            SistemaServiceClient proxy = new SistemaServiceClient();

            List<VariableSistema> listaVariables = proxy.ObtenerListadoVariables();

            proxy.Close();

            return listaVariables;
        }


        public VariableSistema ObtenerVariablePorId(int idVariable)
        {
            
            SistemaServiceClient proxy = new SistemaServiceClient();

            VariableSistema variable = proxy.ObtenerVariablePorId(idVariable);

            proxy.Close();

            return variable;
        }

        public void EditarVariable(VariableSistema variableSistema)
        {
            SistemaServiceClient proxy = new SistemaServiceClient();

            proxy.EditarVariableSistema(variableSistema);

            proxy.Close();
        }
        

        public VariableSistema ObtenerVariablePorNombre(string nombre)
        {
            SistemaServiceClient proxy = new SistemaServiceClient();

            VariableSistema variableSistema = proxy.ObtenerVariablePorNombre(nombre);

            proxy.Close();

            return variableSistema;
        }

        /* Operaciones con layouts */
        public Layout ObtenerLayoutPorId(int idLayout)
        {
            SistemaServiceClient proxy = new SistemaServiceClient();

            Layout layout = proxy.ObtenerLayoutPorId(idLayout);

            proxy.Close();

            return layout;
        }

        public List<Layout> ObtenerListadoLayouts()
        {
            SistemaServiceClient proxy = new SistemaServiceClient();

            List<Layout> listado = proxy.ObtenerListadoLayouts();

            proxy.Close();

            return listado;
        }

        /* Operaciones con tematicas */
        public Tematica ObtenerTematicaPorId(int idTematica)
        {
            SistemaServiceClient proxy = new SistemaServiceClient();

            Tematica tematica = proxy.ObtenerTematicaPorId(idTematica);

            proxy.Close();

            return tematica;
        }

        public List<Tematica> ObtenerListadoTematicas()
        {
            SistemaServiceClient proxy = new SistemaServiceClient();

            List<Tematica> listaTematicas = proxy.ObtenerListadoTematicas();

            proxy.Close();

            return listaTematicas;
        }

    }    
}
