using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CADSoft.Entity.Models.Request
{
    public class AuthenticationRequest
    {
        public string UserName { get; set; }
        public string Password  { get; set; }
    }
}
