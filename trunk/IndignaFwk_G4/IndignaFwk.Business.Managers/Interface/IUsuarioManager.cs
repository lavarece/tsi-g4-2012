using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.Business.Entities;

namespace IndignaFwk.Business.Managers
{
    public interface IUsuarioManager
    {
        Int32 CrearUsuario(Usuario usuario);
    }
}
