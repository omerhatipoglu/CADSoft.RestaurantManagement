using CADSoft.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CADSoft.BL
{
    public class SessionBL
    {
        public void SetCurrentPrincipal(UserInfo user)
        {
            UserInfo = user;
            Identity identity = new Identity(user);
            Principal principal = new Principal(identity);

            HttpContext.Current.User = principal;
        }

        public UserInfo UserInfo { get; set; }
    }
}
