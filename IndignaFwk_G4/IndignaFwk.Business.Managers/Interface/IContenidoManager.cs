using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.Common.Entities;

namespace IndignaFwk.Business.Managers
{
    public interface IContenidoManager
    {
        // Operaciones Contenidos
        int CrearNuevoContenido(Contenido contenido);

        Contenido ObtenerContenidoPorId(int idContenido);

        List<Contenido> ObtenerListadoContenidosPorGrupoYVisibilidad(int idGrupo, string visibilidadContenido);

        List<Contenido> ObtenerXContenidosMasRankeadosPorGrupoYVisibilidad(int idGrupo, string visibilidadContenido, int x);

        void EliminarListaContenido(int idContenido);

        List<Contenido> ObtenerListadoPorGrupoNoEliminado(int idGrupo);

        List<Contenido> ObtenerContenidoEliminadoPorUsuario(int id);

        List<Contenido> ObtenerListadoPorTematica(int idTematica);

        // Operaciones MarcaContenido
        MarcaContenido ObtenerMarcaContenidoPorUsuarioYContenido(int idUsuario, int idContenido);

        int CrearNuevaMarcaContenido(MarcaContenido marcaContenido);

        void EditarMarcaContenido(MarcaContenido marcaContenido);

        Contenido ObtenerContenidoConMarcas(int id);

        List<Contenido> ObtenerListadoPorGrupo(int idGrupo);
    }
}
