using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using IndignaFwk.Common.Entities;
using IndignaFwk.Business.Managers;

namespace IndignaFwk.Business.Services
{
    public class ContenidoService : IContenidoService
    {
        private IContenidoManager contenidoManager = ManagerFactory.Instance.ContenidoManager;

        public int CrearNuevoContenido(Contenido contenido)
        {
            return contenidoManager.CrearNuevoContenido(contenido);
        }

        public Contenido ObtenerContenidoPorId(int idContenido)
        {
            return contenidoManager.ObtenerContenidoPorId(idContenido);
        }

        public List<Contenido> ObtenerListadoContenidosPorGrupoYVisibilidad(int idGrupo, string visibilidadContenido)
        {
            return contenidoManager.ObtenerListadoContenidosPorGrupoYVisibilidad(idGrupo, visibilidadContenido);
        }

        public List<Contenido> ObtenerXContenidosMasRankeadosPorGrupoYVisibilidad(int idGrupo, string visibilidadContenido, int x)
        {
            return contenidoManager.ObtenerXContenidosMasRankeadosPorGrupoYVisibilidad(idGrupo, visibilidadContenido, x);
        }

        public MarcaContenido ObtenerMarcaContenidoPorUsuarioYContenido(int idUsuario, int idContenido)
        {
            return contenidoManager.ObtenerMarcaContenidoPorUsuarioYContenido(idUsuario, idContenido);
        }

        public int CrearNuevaMarcaContenido(MarcaContenido marcaContenido)
        {
            return contenidoManager.CrearNuevaMarcaContenido(marcaContenido);
        }

        public void EditarMarcaContenido(MarcaContenido marcaContenido)
        {
            contenidoManager.EditarMarcaContenido(marcaContenido);
        }
    }
}
