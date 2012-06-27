using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.Common.Entities;
using IndignaFwk.UI.Process.ConvocatoriaService;
using IndignaFwk.Common.Filter;

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

        public List<Convocatoria> ObtenerConvocatoriasPorFiltro(FiltroBusqueda filtroBusqueda)
        {
            ConvocatoriaServiceClient proxy = new ConvocatoriaServiceClient();

            List<Convocatoria> listaConvocatorias = proxy.ObtenerConvocatoriasPorFiltro(filtroBusqueda);

            proxy.Close();

            return listaConvocatorias;
        }

        public List<Convocatoria> ObtenerListadoConvocatoriasPorGrupo(int idGrupo)
        {
            ConvocatoriaServiceClient proxy = new ConvocatoriaServiceClient();

            List<Convocatoria> listado = proxy.ObtenerListadoConvocatoriasPorGrupo(idGrupo);

            proxy.Close();

            return listado;
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


        /* Operaciones AsistenciaConvocatoria */
        public int CrearNuevaAsistenciaConvocatoria(AsistenciaConvocatoria asistenciaConvocatoria)
        {
            ConvocatoriaServiceClient proxy = new ConvocatoriaServiceClient();

            int id = proxy.CrearNuevaAsistenciaConvocatoria(asistenciaConvocatoria);

            proxy.Close();

            return id;
        }

        public List<AsistenciaConvocatoria> ObtenerAsistenciaConvocatoriaPorIdUsuario(int idUsuario)
        {
            ConvocatoriaServiceClient proxy = new ConvocatoriaServiceClient();

            List<AsistenciaConvocatoria> listaAsistenciaConvocatoria = proxy.ObtenerAsistenciaConvocatoriaPorIdUsuario(idUsuario);

            proxy.Close();

            return listaAsistenciaConvocatoria;
        }

        public AsistenciaConvocatoria ObtenerAsistenciaConvocatoriaPorUsuarioYConvocatoria(int idUsuario, int idConvocatoria)
        {
            ConvocatoriaServiceClient proxy = new ConvocatoriaServiceClient();

            AsistenciaConvocatoria asistenciaConvocatoria = proxy.ObtenerAsistenciaConvocatoriaPorUsuarioYConvocatoria(idUsuario, idConvocatoria);

            proxy.Close();

            return asistenciaConvocatoria;
        }


        public void EditarAsistenciaConvocatoria(AsistenciaConvocatoria asistenciaConvocatoria)
        {
            ConvocatoriaServiceClient proxy = new ConvocatoriaServiceClient();

            proxy.EditarAsistenciaConvocatoria(asistenciaConvocatoria);

            proxy.Close();
        }

        public void EliminarAsistenciaConvocatoria(int idAsistenciaConvocatoria)
        {
            ConvocatoriaServiceClient proxy = new ConvocatoriaServiceClient();

            proxy.EliminarAsistenciaConvocatoria(idAsistenciaConvocatoria);

            proxy.Close();
        }
    }
}
