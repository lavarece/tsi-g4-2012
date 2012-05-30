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
        /* Operaciones Convocatoria */
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

        /* Operaciones Contenidos */
        public int CrearNuevoContenido(Contenido contenido)
        {
            ConvocatoriaServiceClient proxy = new ConvocatoriaServiceClient();

            int id = proxy.CrearNuevoContenido(contenido);

            proxy.Close();

            return id;
        }

        public List<Contenido> ObtenerListadoContenidosPorGrupoYVisibilidad(int idGrupo, string visibilidadContenido)
        {
            ConvocatoriaServiceClient proxy = new ConvocatoriaServiceClient();

            List<Contenido> listado = proxy.ObtenerListadoContenidosPorGrupoYVisibilidad(idGrupo, visibilidadContenido);

            proxy.Close();

            return listado;
        }

        public Contenido ObtenerContenidoPorId(int idContenido)
        {
            ConvocatoriaServiceClient proxy = new ConvocatoriaServiceClient();

            Contenido contenido = proxy.ObtenerContenidoPorId(idContenido);

            proxy.Close();

            return contenido;
        }

        /* Operaciones AsistenciaConvocatoria */
        public int CrearNuevaAsistenciaConvocatoria(AsistenciaConvocatoria asistenciaConvocatoria)
        {
            ConvocatoriaServiceClient proxy = new ConvocatoriaServiceClient();

            int id = proxy.CrearNuevaAsistenciaConvocatoria(asistenciaConvocatoria);

            proxy.Close();

            return id;
        }

        // Operaciones MarcaContenido
        public MarcaContenido ObtenerMarcaContenidoPorUsuarioYContenido(int idUsuario, int idContenido)
        {
            ConvocatoriaServiceClient proxy = new ConvocatoriaServiceClient();

            MarcaContenido marcaContenido = proxy.ObtenerMarcaContenidoPorUsuarioYContenido(idUsuario, idContenido);

            proxy.Close();

            return marcaContenido;
        }

        public int CrearNuevaMarcaContenido(MarcaContenido marcaContenido)
        {
            ConvocatoriaServiceClient proxy = new ConvocatoriaServiceClient();

            int id = proxy.CrearNuevaMarcaContenido(marcaContenido);

            proxy.Close();

            return id;
        }

        public void EditarMarcaContenido(MarcaContenido marcaContenido)
        {
            ConvocatoriaServiceClient proxy = new ConvocatoriaServiceClient();

            proxy.EditarMarcaContenido(marcaContenido);

            proxy.Close();
        }
    }
}
