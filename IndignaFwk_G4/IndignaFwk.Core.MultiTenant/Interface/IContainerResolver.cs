using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Routing;
using StructureMap;

namespace IndignaFwk.Core.MultiTenant
{
    public interface IContainerResolver
    {
        IContainer Resolve(RequestContext requestContext);
    }
}
