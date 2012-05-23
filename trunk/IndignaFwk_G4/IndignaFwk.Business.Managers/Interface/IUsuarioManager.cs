using System;
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
    }
}
