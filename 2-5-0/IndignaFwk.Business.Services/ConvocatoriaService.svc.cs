using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using IndignaFwk.Business.Managers;
using IndignaFwk.Common.Entities;
using IndignaFwk.Common.Filter;


namespace IndignaFwk.Business.Services
{
    public class ConvocatoriaService : IConvocatoriaService
    {
        private IConvocatoriaManager convocatoriaManager = ManagerFactory.Instance.ConvocatoriaManager;

        public int CrearNuevaConvocatoria(Convocatoria convocatoria)
        {
            return convocatoriaManager.CrearNuevaConvocatoria(convocatoria);
        }

        public List<Convocatoria> ObtenerListadoConvocatoriasPorGrupo(int idGrupo)
        {
            return convocatoriaManager.ObtenerListadoConvocatoriasPorGrupo(idGrupo);
        }

        public List<Convocatoria> ObtenerConvocatoriasPorFiltro(FiltroBusqueda filtroBusqueda)
        {
            return convocatoriaManager.ObtenerConvocatoriasPorFiltro(filtroBusqueda);
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
        
        public List <AsistenciaConvocatoria> ObtenerAsistenciaConvocatoriaPorIdUsuario(int idUsuario)
        {
            return convocatoriaManager.ObtenerAsistenciaConvocatoriaPorIdUsuario(idUsuario);
        }

        public AsistenciaConvocatoria ObtenerAsistenciaConvocatoriaPorUsuarioYConvocatoria(int idUsuario, int idConvocatoria)
        {
            return convocatoriaManager.ObtenerAsistenciaConvocatoriaPorUsuarioYConvocatoria(idUsuario, idConvocatoria);
        }

        public void EditarAsistenciaConvocatoria(AsistenciaConvocatoria asistenciaConvocatoria)
        {
            convocatoriaManager.EditarAsistenciaConvocatoria(asistenciaConvocatoria);
        }

        public int CrearNuevaAsistenciaConvocatoria(AsistenciaConvocatoria asistenciaConvocatoria)
        {
            return convocatoriaManager.CrearNuevaAsistenciaConvocatoria(asistenciaConvocatoria);
        }

        public void EliminarAsistenciaConvocatoria(int idAsistenciaConvocatoria)
        {
            convocatoriaManager.EliminarAsistenciaConvocatoria(idAsistenciaConvocatoria);
        }

     
    }
}
