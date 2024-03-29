﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.Common.Entities;
using System.Data.SqlClient;
using IndignaFwk.Common.Enumeration;

namespace IndignaFwk.Persistence.DataAccess
{
    public interface IContenidoADO
    {
        void Crear(Contenido contenido, SqlConnection conexion, SqlTransaction transaccion);

        void Editar(Contenido contenido, SqlConnection conexion, SqlTransaction transaccion);

        void Eliminar(int id, SqlConnection conexion, SqlTransaction transaccion);

        Contenido Obtener(int id, SqlConnection conexion);

        List<Contenido> ObtenerListadoPorGrupoYVisibilidad(SqlConnection conexion, int idGrupo, string visibilidadContenido);

        List<Contenido> ObtenerXPorGrupoYVisibilidad(SqlConnection conexion, int idGrupo, string visibilidadContenido, int x);

        Contenido ObtenerContenidoConMarcas(int id, SqlConnection conexion);

        List<Contenido> ObtenerListadoPorGrupoNoEliminado(SqlConnection conexion, int idGrupo);

        List<Contenido> ObtenerListadoPorGrupo(SqlConnection conexion, int idGrupo);

        List<Contenido> ObtenerContenidoEliminadoPorUsuario(int id, SqlConnection conexion);

        List<Contenido> ObtenerListadoPorTematica(int idTematica, SqlConnection conexion);
    }
}
