using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using IndignaFwk.Common.Entities;
using IndignaFwk.Business.Managers;

namespace IndignaFwk.Business.Services
{
    public class UsuarioService : IUsuarioService
    {
        private IUsuarioManager usuarioManager = ManagerFactory.Instance.UsuarioManager;

        public int CrearNuevoUsuario(Usuario usuario)
        {
            return usuarioManager.CrearNuevoUsuario(usuario);
        }

        public List<Usuario> ObtenerListadoUsuarios()
        {
            return usuarioManager.ObtenerListadoUsuarios();
        }

        public Usuario ObtenerUsuarioPorId(int idUsuario)
        {
            return usuarioManager.ObtenerUsuarioPorId(idUsuario);
        }

        public List<Usuario> ObtenerUsuariosPorIdGrupo(int idGrupo)
        {
            return usuarioManager.ObtenerUsuariosPorIdGrupo(idGrupo);
        }

        public void EditarUsuario(Usuario usuario)
        {
            usuarioManager.EditarUsuario(usuario);
        }

        public void EliminarUsuario(int idUsuario)
        {
            usuarioManager.EliminarUsuario(idUsuario);
        }

        public Usuario ObtenerUsuarioPorEmailYPass(string email, string pass)
        {
            return usuarioManager.ObtenerUsuarioPorEmailYPass(email, pass);
        }

        public Usuario ObtenerUsuarioPorEmail(string email)
        { 
            return usuarioManager.ObtenerPorEmail(email);
        }

        public List<Notificacion> ObtenerListadoNotificacionesPorUsuario(int idUsuario)
        {
            return usuarioManager.ObtenerListadoNotificacionesPorUsuario(idUsuario);
        }

        public Notificacion ObtenerNotificacionPorId(int idNotificacion)
        {
            return usuarioManager.ObtenerNotificacionPorId(idNotificacion);
        }

        public void EditarNotificacion(Notificacion notificacion)
        {
            usuarioManager.EditarNotificacion(notificacion);
        }

        public void EliminarNotificacion(int idNotificacion)
        {
            usuarioManager.EliminarNotificacion(idNotificacion);
        }

        public List<Usuario> ObtenerUsuariosAgrupandoFechaRegistro(int idGrupo)
        {
            return usuarioManager.ObtenerUsuariosAgrupandoFechaRegistro(idGrupo);
        }
    }
}
