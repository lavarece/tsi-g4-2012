using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap;
using System.Web.Mvc;

namespace IndignaFwk.Core.MultiTenant
{
    public interface IApplicationTenant
    {
        int Id { get; set; }

        string Name { get; set; }

        string Theme { get; set; }

        string Url { get; set; }

        IContainer DependencyContainer { get; }

        void InitializeContainer();
    }
}
