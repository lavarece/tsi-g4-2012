﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ServiceModel;
using IndignaFwk.Common.Entities;

namespace IndignaFwk.Business.Services
{
    [ServiceContract]
    public interface IContenidoService
    {
        // Operaciones Contenidos
        [OperationContract]
        int CrearNuevoContenido(Contenido contenido);

        [OperationContract]
        List<Contenido> ObtenerListadoContenidosPorGrupoYVisibilidad(int idGrupo, string visibilidadContenido);

        [OperationContract]
        List<Contenido> ObtenerXContenidosMasRankeadosPorGrupoYVisibilidad(int idGrupo, string visibilidadContenido, int x);

        [OperationContract]
        Contenido ObtenerContenidoPorId(int idContenido);

        // Operaciones MarcarContenido
        [OperationContract]
        MarcaContenido ObtenerMarcaContenidoPorUsuarioYContenido(int idUsuario, int idContenido);

        [OperationContract]
        int CrearNuevaMarcaContenido(MarcaContenido marcaContenido);

        [OperationContract]
        void EditarMarcaContenido(MarcaContenido marcaContenido);
    }
}
