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

        public void EditarUsuario(Usuario usuario)
        {
            usuarioManager.EditarUsuario(usuario);
        }

        public void EliminarUsuario(int idUsuario)
        {
            usuarioManager.EliminarUsuario(idUsuario);
        }
    }
}
