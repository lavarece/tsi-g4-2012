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

        public List<Convocatoria> ObtenerListadoConvocatoriasPorGrupo(int idGrupo)
        {
            return convocatoriaManager.ObtenerListadoConvocatoriasPorGrupo(idGrupo);
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

        public List<Contenido> ObtenerListadoContenidosPorGrupoYVisibilidad(int idGrupo, string visibilidadContenido)
        {
            return convocatoriaManager.ObtenerListadoContenidosPorGrupoYVisibilidad(idGrupo, visibilidadContenido);
        }

        public Contenido ObtenerContenidoPorId(int idContenido)
        {
            return convocatoriaManager.ObtenerContenidoPorId(idContenido);
        }

        public MarcaContenido ObtenerMarcaContenidoPorUsuarioYContenido(int idUsuario, int idContenido)
        {
            return convocatoriaManager.ObtenerMarcaContenidoPorUsuarioYContenido(idUsuario, idContenido);
        }

        public int CrearNuevaMarcaContenido(MarcaContenido marcaContenido)
        {
            return convocatoriaManager.CrearNuevaMarcaContenido(marcaContenido);
        }

        public void EditarMarcaContenido(MarcaContenido marcaContenido)
        {
            convocatoriaManager.EditarMarcaContenido(marcaContenido);
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
