using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.Business.Entities;
using IndignaFwk.UI.Process.ConvocatoriaService;

namespace IndignaFwk.UI.Process
{
    public class ConvocatoriaUserProcess : IConvocatoriaUserProcess
    {
        public Int32 crearConvocatoria(Business.Entities.Usuario usuario)
        {
            ConvocatoriaServiceClient convocatoriaServiceProxy = new ConvocatoriaServiceClient();

            convocatoriaServiceProxy.crearConvocatoria(new Convocatoria());

            convocatoriaServiceProxy.Close();

            return 0;
        }
    }
}
