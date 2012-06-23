using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.Common.Entities;
using IndignaFwk.UI.Process.UsuarioService;

namespace IndignaFwk.UI.Process
{
    public class UsuarioUserProcess
    {
        public int CrearNuevoUsuario(Usuario usuario)
        {
            UsuarioServiceClient proxy = new UsuarioServiceClient();

            int idUsuario = proxy.CrearNuevoUsuario(usuario);

            proxy.Close();

            return idUsuario;
        }

        public List<Usuario> ObtenerListadoUsuarios()
        {
            UsuarioServiceClient proxy = new UsuarioServiceClient();

            List<Usuario> listaUsuarios = proxy.ObtenerListadoUsuarios();

            proxy.Close();

            return listaUsuarios;
        }

        public Usuario ObtenerUsuarioPorId(int idUsuario)
        {
            UsuarioServiceClient proxy = new UsuarioServiceClient();

            Usuario usuario = proxy.ObtenerUsuarioPorId(idUsuario);

            proxy.Close();

            return usuario;
        }

        public void EditarUsuario(Usuario usuario)
        {
            UsuarioServiceClient proxy = new UsuarioServiceClient();

            proxy.EditarUsuario(usuario);

            proxy.Close();
        }

        public void EliminarUsuario(int idUsuario)
        {
            UsuarioServiceClient proxy = new UsuarioServiceClient();

            proxy.EliminarUsuario(idUsuario);

            proxy.Close();
        }

        public List<Usuario> ObtenerUsuariosPorIdGrupo(int idGrupo)
        {
            UsuarioServiceClient proxy = new UsuarioServiceClient();

            List <Usuario> usuarios = proxy.ObtenerUsuariosPorIdGrupo(idGrupo);

            proxy.Close();

            return usuarios;
        }

        public Usuario ObtenerUsuarioPorEmailYPass(string email, string pass)
        {
            UsuarioServiceClient proxy = new UsuarioServiceClient();

            Usuario usuario = proxy.ObtenerUsuarioPorEmailYPass(email, pass);

            proxy.Close();

            return usuario;
        }

        public Usuario ObtenerUsuarioPorEmail(string email)
        {
            UsuarioServiceClient proxy = new UsuarioServiceClient();

            Usuario usuario = proxy.ObtenerUsuarioPorEmail(email);

            proxy.Close();

            return usuario;
        }

        public List<Notificacion> ObtenerListadoNotificacionesPorUsuario(int idUsuario)
        {
            UsuarioServiceClient proxy = new UsuarioServiceClient();

            List<Notificacion> listadoNotificaciones = proxy.ObtenerListadoNotificacionesPorUsuario(idUsuario);

            proxy.Close();

            return listadoNotificaciones;
        }

        public Notificacion ObtenerNotificacionPorId(int idNotificacion)
        {
            UsuarioServiceClient proxy = new UsuarioServiceClient();

            Notificacion notificacion = proxy.ObtenerNotificacionPorId(idNotificacion);

            proxy.Close();

            return notificacion;
        }

        public void EditarNotificacion(Notificacion notificacion)
        {
            UsuarioServiceClient proxy = new UsuarioServiceClient();

            proxy.EditarNotificacion(notificacion);

            proxy.Close();
        }

        public void EliminarNotificacion(int idNotificacion)
        {
            UsuarioServiceClient proxy = new UsuarioServiceClient();

            proxy.EliminarNotificacion(idNotificacion);

            proxy.Close();
        }

        public List<Usuario> ObtenerUsuariosAgrupandoFechaRegistro(int idGrupo)
        {
            UsuarioServiceClient proxy = new UsuarioServiceClient();

            List<Usuario> usuarios = proxy.ObtenerUsuariosAgrupandoFechaRegistro(idGrupo);

            proxy.Close();

            return usuarios;
        }
       
    }
}
