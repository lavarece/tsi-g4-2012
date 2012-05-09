using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.Business.Entities;

namespace IndignaFwk.Persistence.DataAccess
{
    public interface IUsuarioADO
    {
        long crear(Usuario usuario);

        void editar(Usuario usuario);

        void eliminar(long id);

        Usuario obtener(long id);

        List<Usuario> obtenerListado();
    }
}
