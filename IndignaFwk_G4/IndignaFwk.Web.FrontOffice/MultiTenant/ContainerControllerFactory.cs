using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;
using StructureMap;
using IndignaFwk.Web.FrontOffice.Controllers;

namespace IndignaFwk.Web.FrontOffice.MultiTenant
{
    public class ContainerControllerFactory : DefaultControllerFactory
    {
        public IContainerResolver ContainerResolver { get; private set; }
        
        public ContainerControllerFactory(IContainerResolver resolver) 
        {
            this.ContainerResolver = resolver;
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType) 
        {
            IController result = null;
            
            if (controllerType != null) 
            {
                try
                {
                    var container = this.ContainerResolver.Resolve(requestContext);

                    result = container.GetInstance(controllerType) as Controller;
                }
                catch (Exception e)
                {
                    Console.Write(e);

                    result = new ErrorController(e);
                }                
            }

            return result;
        }
    }
}
