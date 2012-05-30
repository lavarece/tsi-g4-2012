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
    }    
}
