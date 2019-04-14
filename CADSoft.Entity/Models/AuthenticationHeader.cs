using System.Runtime.Serialization;

namespace CADSoft.Entity.Models
{
    [DataContract]
    public class AuthenticationHeader
    {
        [DataMember]
        public int UserID { get; set; }
        [DataMember]
        public string Token { get; set; }
        [DataMember]
        public string TimeSpan { get; set; }
    }
}
