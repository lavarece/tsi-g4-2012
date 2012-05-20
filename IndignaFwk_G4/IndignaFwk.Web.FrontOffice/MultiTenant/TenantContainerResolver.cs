using System;
using System.Collections.Generic;
using System.Linq;
using StructureMap;
using System.Web;
using System.Web.Routing;
using IndignaFwk.Common.Entities;
using IndignaFwk.UI.Process;

namespace IndignaFwk.Web.FrontOffice.MultiTenant
{
    public class TenantContainerResolver : IContainerResolver
    {
        public TenantContainerResolver() { }

        public IContainer Resolve(RequestContext requestContext)
        {
            Ensure.Argument.NotNull(requestContext);

            string url = requestContext.HttpContext.Request.ServerVariables["HTTP_HOST"];

            url = url.Split(':')[0];

            IApplicationTenant tenant = null;

            // Obtengo el grupo de la BD
            Grupo grupo = UserProcessFactory.Instance.GrupoUserProcess.ObtenerGrupoPorUrl(url);

            if (grupo == null)
                throw new TenantNotFoundException("URL no especificada: '" + url + "'");

            // Creo el SiteTenant con la info del grupo
            IApplicationTenant site = new SiteTenant
            {
                Id = grupo.Id,
                Nombre = grupo.Nombre,
                Descripcion = grupo.Descripcion,
                Template = grupo.Template,
                Url = grupo.Url
            };

            tenant.InitializeContainer();

            return tenant.DependencyContainer;            
        }
    }
}
