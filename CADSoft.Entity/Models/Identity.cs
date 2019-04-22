using System.Security.Principal;

namespace CADSoft.Entity.Models
{
    public class Identity : IIdentity
    {
        public Identity(UserInfo user)
        {
            UserInfo = user;
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

        public string AuthenticationType
        {
            get
            {
                return "asd";
            }
        }

        public bool IsAuthenticated
        {
            get
            {
                return UserInfo.ID > 0;
            }
        }
    }
}
