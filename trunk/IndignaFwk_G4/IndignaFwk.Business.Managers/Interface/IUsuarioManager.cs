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

        List<Usuario> ObtenerTodosLosUsuarios();

        Usuario ObtenerUsuarioPorId(int idUsuario);

    }
}
