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
    public class ConvocatoriaService : IConvocatoriaService
    {
        private IConvocatoriaManager convocatoriaManager = ManagerFactory.Instance.ConvocatoriaManager;

        public int CrearNuevaConvocatoria(Convocatoria convocatoria)
        {
            return convocatoriaManager.CrearNuevaConvocatoria(convocatoria);
        }

        public List<Convocatoria> ObtenerListadoConvocatorias()
        {
            return convocatoriaManager.ObtenerListadoConvocatorias();
        }

        public Convocatoria ObtenerConvocatoriaPorId(int idConvocatoria)
        {
            return convocatoriaManager.ObtenerConvocatoriaPorId(idConvocatoria);
        }

        public void EditarConvocatoria(Convocatoria convocatoria)
        {
            convocatoriaManager.EditarConvocatoria(convocatoria);
        }

        public void EliminarConvocatoria(int idConvocatoria)
        {
            convocatoriaManager.EliminarConvocatoria(idConvocatoria);
        }
        
        public int CrearNuevoContenido(Contenido contenido)
        {
            return convocatoriaManager.CrearNuevoContenido(contenido);
        }

        public List<Contenido> ObtenerListadoContenidos()
        {
            return convocatoriaManager.ObtenerListadoContenidos();
        }

        public Contenido ObtenerContenidoPorId(int idContenido)
        {
            return convocatoriaManager.ObtenerContenidoPorId(idContenido);
        }

        public int CrearNuevaAsistenciaConvocatoria(AsistenciaConvocatoria asistenciaConvocatoria)
        {
            return convocatoriaManager.CrearNuevaAsistenciaConvocatoria(asistenciaConvocatoria);
        }
    }
}
