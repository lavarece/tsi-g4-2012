using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.Common.Entities;

namespace IndignaFwk.Business.Managers
{
    public interface IUsuarioManager
    {
        Int32 CrearNuevoUsuario(Usuario usuario);
    }
}
