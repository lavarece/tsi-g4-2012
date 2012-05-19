using System;
using System.Collections.Generic;
using System.Linq;
using StructureMap;
using System.Web;
using System.Web.Routing;

namespace IndignaFwk.Core.MultiTenant
{
    public class TenantContainerResolver : IContainerResolver
    {
        public TenantContainerResolver() { }

        public IContainer Resolve(RequestContext requestContext)
        {
            Ensure.Argument.NotNull(requestContext);

            //string baseurl = _context.HttpContext.BaseUrl().TrimEnd('/');
            string url = requestContext.HttpContext.Request.ServerVariables["HTTP_HOST"];

            string host = url.Split(':')[0];

            IApplicationTenant tenant = null;

            if (host.Equals("grupo1.misitio"))
            {
                tenant = new SiteTenant
                {
                    Name = "Grupo1",
                    Theme = "Default",
                    Url = "http://grupo1.misitio:1390/"
                };
            }
            else if (host.Equals("grupo2.misitio"))
            {
                tenant = new SiteTenant
                {
                    Name = "Grupo2",
                    Theme = "Default",
                    Url = "http://grupo2.misitio:1390/"
                };
            }

            if(tenant == null)
                throw new TenantNotFoundException();

            tenant.InitializeContainer();

            return tenant.DependencyContainer;
        }
    }
}
