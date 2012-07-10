using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using IndignaFwk.Business.Managers;
using IndignaFwk.Common.Entities;

namespace IndignaFwk.Business.Services
{
    public class ExposeService : IExposeService
    {
        private IConvocatoriaManager convocatoriaManager = ManagerFactory.Instance.ConvocatoriaManager;

        private IContenidoManager contenidoManager = ManagerFactory.Instance.ContenidoManager;

        public List<Contenido> ObtenerContenidosPorTematica(int idTematica)
        {
            return contenidoManager.ObtenerListadoPorTematica(idTematica);
        }

        public List<Convocatoria> ObtenerConvocatoriasPorTematica(int idTematica)
        {
            return convocatoriaManager.ObtenerListadoPorTematica(idTematica);
        }
    }
}
