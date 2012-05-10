using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.Business.Entities;

namespace IndignaFwk.Persistence.DataAccess
{
    public interface ITemplateADO
    {
        Int32 Crear(Template template);

        void Editar(Template template);

        void Eliminar(long id);

        Template Obtener(long id);

        List<Template> ObtenerListado();
    }
}
