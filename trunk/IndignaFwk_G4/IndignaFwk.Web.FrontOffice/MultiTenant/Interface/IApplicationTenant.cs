using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap;
using System.Web.Mvc;
using IndignaFwk.Common.Entities;

namespace IndignaFwk.Web.FrontOffice.MultiTenant
{
    public interface IApplicationTenant
    {
        Grupo Grupo { get; set; } 

        IContainer DependencyContainer { get; }

        void InitializeContainer();
    }
}
