using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Principal;

namespace IndignaFwk.Web.FrontOffice.Util
{
    public class CustomIdentity : IIdentity
    {
        public CustomIdentity(string name, string id)
        {
            IsAuthenticated = true;

            Name = name;

            Id = Int32.Parse(id);

            AuthenticationType = "Forms";
        }

        public string AuthenticationType { get; private set; }

        public bool IsAuthenticated { get; private set; }

        public string Name { get; private set; }

        public int Id { get; private set; }
    }
}