using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.Business.Entities;

namespace IndignaFwk.Persistence.DataAccess
{
    public interface IUsuarioADO
    {
        Int32 Crear(Usuario usuario);

        void Editar(Usuario usuario);

        void Eliminar(long id);

        Usuario Obtener(long id);

        List<Usuario> ObtenerListado();
    }
}
