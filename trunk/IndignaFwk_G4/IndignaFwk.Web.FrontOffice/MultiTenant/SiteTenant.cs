using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap;
using IndignaFwk.Common.Entities;

namespace IndignaFwk.Web.FrontOffice.MultiTenant
{
    public class SiteTenant : IApplicationTenant
    {
        public SiteTenant(Grupo grupo)
        {
            this.Grupo = grupo;
        }

        IContainer _container;

        public Grupo Grupo { get; set; }

        public IContainer DependencyContainer { get { return _container; } }

        public void InitializeContainer()
        {
            _container = new Container();

            _container.Configure(config => {
                config.For<IApplicationTenant>().Singleton().Use(this);
            });
        }
    }
}
