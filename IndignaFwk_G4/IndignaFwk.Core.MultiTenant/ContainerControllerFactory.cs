using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;
using StructureMap;

namespace IndignaFwk.Core.MultiTenant
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
                var container = this.ContainerResolver.Resolve(requestContext);

                try 
                {
                    result = container.GetInstance(controllerType) as Controller;

                } 
                catch (StructureMapException) 
                {
                    Console.WriteLine(container.WhatDoIHave());

                    throw;
                }
            }

            return result;
        }
    }
}
