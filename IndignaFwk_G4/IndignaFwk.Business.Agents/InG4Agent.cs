using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.Business.Agents.InG4Service;
using IndignaFwk.Common.Entities;

namespace IndignaFwk.Business.Agents
{
    public class InG4Agent
    {
        public List<Contenido> ObtenerContenidosIntegracionPorTematica(int idTematica)
        {
            List<Contenido> contenidosPorTematica;

            try
            {
                ExposeServiceClient proxy = new ExposeServiceClient();

                contenidosPorTematica = proxy.ObtenerContenidosPorTematica(idTematica);

                proxy.Close();
            }
            catch (Exception e)
            {
                contenidosPorTematica = new List<Contenido>();
            }
            
            return contenidosPorTematica;
        }

        public List<Convocatoria> ObtenerConvocatoriasIntegracionPorTematica(int idTematica)
        {
            List<Convocatoria> convocatoriasPorTematica;

            try
            {
                ExposeServiceClient proxy = new ExposeServiceClient();

                convocatoriasPorTematica = proxy.ObtenerConvocatoriasPorTematica(idTematica);

                proxy.Close();
            }
            catch (Exception e)
            {
                convocatoriasPorTematica = new List<Convocatoria>();
            }

            return convocatoriasPorTematica;
        }
    }
}
