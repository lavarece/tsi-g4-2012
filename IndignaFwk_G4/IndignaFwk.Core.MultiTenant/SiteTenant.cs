using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap;

namespace IndignaFwk.Core.MultiTenant
{
    public class SiteTenant : IApplicationTenant
    {
        IContainer _container;

        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public string Template { get; set; }

        public string Url { get; set; }

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
