using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.Common.Entities;
using IndignaFwk.UI.Process.ConvocatoriaService;

namespace IndignaFwk.UI.Process
{
    public class ConvocatoriaUserProcess
    {
        public int CrearNuevaConvocatoria(Convocatoria convocatoria)
        {
            ConvocatoriaServiceClient proxy = new ConvocatoriaServiceClient();

            int id = proxy.CrearNuevaConvocatoria(convocatoria);

            proxy.Close();

            return id;
        }

        public List<Convocatoria> ObtenerListadoConvocatorias()
        {
            ConvocatoriaServiceClient proxy = new ConvocatoriaServiceClient();

            List<Convocatoria> listaConvocatorias = proxy.ObtenerListadoConvocatorias();

            proxy.Close();

            return listaConvocatorias;
        }

        public Convocatoria ObtenerConvocatoriaPorId(int idConvocatoria)
        {
            ConvocatoriaServiceClient proxy = new ConvocatoriaServiceClient();

            Convocatoria convocatoria = proxy.ObtenerConvocatoriaPorId(idConvocatoria);

            proxy.Close();

            return convocatoria;
        }

        public void EditarConvocatoria(Convocatoria convocatoria)
        {
            ConvocatoriaServiceClient proxy = new ConvocatoriaServiceClient();

            proxy.EditarConvocatoria(convocatoria);

            proxy.Close();
        }

        public void EliminarConvocatoria(int idConvocatoria)
        {
            ConvocatoriaServiceClient proxy = new ConvocatoriaServiceClient();

            proxy.EliminarConvocatoria(idConvocatoria);

            proxy.Close();
        }
    }
}
