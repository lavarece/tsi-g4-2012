using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.Common.Entities;
using IndignaFwk.UI.Process.ContenidoService;

namespace IndignaFwk.UI.Process
{
    public class ContenidoUserProcess
    {
        /* Operaciones Contenidos */
        public int CrearNuevoContenido(Contenido contenido)
        {
            ContenidoServiceClient proxy = new ContenidoServiceClient();

            int id = proxy.CrearNuevoContenido(contenido);

            proxy.Close();

            return id;
        }

        public List<Contenido> ObtenerListadoContenidosPorGrupoYVisibilidad(int idGrupo, string visibilidadContenido)
        {
            ContenidoServiceClient proxy = new ContenidoServiceClient();

            List<Contenido> listado = proxy.ObtenerListadoContenidosPorGrupoYVisibilidad(idGrupo, visibilidadContenido);

            proxy.Close();

            return listado;
        }

        public List<Contenido> ObtenerXContenidosMasRankeadosPorGrupoYVisibilidad(int idGrupo, string visibilidadContenido, int x)
        {
            ContenidoServiceClient proxy = new ContenidoServiceClient();

            List<Contenido> listado = proxy.ObtenerXContenidosMasRankeadosPorGrupoYVisibilidad(idGrupo, visibilidadContenido, x);

            proxy.Close();

            return listado;
        }

        public Contenido ObtenerContenidoPorId(int idContenido)
        {
            ContenidoServiceClient proxy = new ContenidoServiceClient();

            Contenido contenido = proxy.ObtenerContenidoPorId(idContenido);

            proxy.Close();

            return contenido;
        }

        // Operaciones MarcaContenido
        public MarcaContenido ObtenerMarcaContenidoPorUsuarioYContenido(int idUsuario, int idContenido)
        {
            ContenidoServiceClient proxy = new ContenidoServiceClient();

            MarcaContenido marcaContenido = proxy.ObtenerMarcaContenidoPorUsuarioYContenido(idUsuario, idContenido);

            proxy.Close();

            return marcaContenido;
        }

        public int CrearNuevaMarcaContenido(MarcaContenido marcaContenido)
        {
            ContenidoServiceClient proxy = new ContenidoServiceClient();

            int id = proxy.CrearNuevaMarcaContenido(marcaContenido);

            proxy.Close();

            return id;
        }

        public void EditarMarcaContenido(MarcaContenido marcaContenido)
        {
            ContenidoServiceClient proxy = new ContenidoServiceClient();

            proxy.EditarMarcaContenido(marcaContenido);

            proxy.Close();
        }

        public Contenido ObtenerContenidoConMarcas(int id)
        {
            ContenidoServiceClient proxy = new ContenidoServiceClient();

            Contenido contenido = proxy.ObtenerContenidoConMarcas(id);

            proxy.Close();

            return contenido;
        }

        public List<Contenido> ObtenerListadoPorGrupo(int idGrupo)
        {
            ContenidoServiceClient proxy = new ContenidoServiceClient();

            List<Contenido> contenido = proxy.ObtenerListadoPorGrupo(idGrupo);

            proxy.Close();

            return contenido;
        }
    }
}
