using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CADSoft.Entity.Models
{
    public class Principal : IPrincipal
    {
        public Principal(IIdentity identity)
        {
            this.Identity = identity;
        }

        public IIdentity Identity { get; set; }

        public bool IsInRole(string role)
        {
            return true;
        }
    }
}
