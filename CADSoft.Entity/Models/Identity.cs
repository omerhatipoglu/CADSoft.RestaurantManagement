using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CADSoft.Entity.Models
{
    public class Identity : IIdentity
    {
        public Identity(UserInfo user)
        {
            this.UserInfo = user;
        }

        public UserInfo UserInfo { get; set; }

        public string Name
        {
            get
            {
                if (!IsAuthenticated)
                    return string.Empty;

                return UserInfo.UserName;
            }
        }

        public string AuthenticationType { get {
                return "asd";
            } }

        public bool IsAuthenticated { get
            {
                return UserInfo.ID > 0;
            } }
    }
}
