using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.Business.Entities;

namespace IndignaFwk.Persistence.DataAccess
{
    public interface ITemplateADO
    {
        long crear(Template template);

        void editar(Template template);

        void eliminar(long id);

        Template obtener(long id);

        List<Template> obtenerListado();
    }
}
