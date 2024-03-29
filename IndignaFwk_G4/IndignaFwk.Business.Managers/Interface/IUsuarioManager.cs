﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.Common.Entities;

namespace IndignaFwk.Business.Managers
{
    public interface IUsuarioManager
    {
        int CrearNuevoUsuario(Usuario usuario);

        List<Usuario> ObtenerListadoUsuarios();

        Usuario ObtenerUsuarioPorId(int idUsuario);

        void EditarUsuario(Usuario usuario);

        void EliminarUsuario(int idUsuario);

        Usuario ObtenerPorEmailYGrupo(string email, int idGrupo);

        Usuario ObtenerUsuarioPorEmailPassYGrupo(string email, string pass, int idGrupo);

        List<Usuario> ObtenerUsuariosPorIdGrupo(int idGrupo);
       
        // Funciones con notificaciones
        List<Notificacion> ObtenerListadoNotificacionesPorUsuario(int idUsuario);

        Notificacion ObtenerNotificacionPorId(int idNotificacion);

        void EditarNotificacion(Notificacion notificacion);

        void EliminarNotificacion(int idNotificacion);

        List<Usuario> ObtenerUsuariosAgrupandoFechaRegistro(int idGrupo);
    }
}
