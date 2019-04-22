using System.Security.Principal;

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
