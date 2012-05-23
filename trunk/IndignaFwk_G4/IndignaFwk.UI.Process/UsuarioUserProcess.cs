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
    }
}
