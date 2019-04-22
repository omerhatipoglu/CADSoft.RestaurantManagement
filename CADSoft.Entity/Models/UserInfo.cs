using System;

namespace CADSoft.Entity.Models
{
    public class UserInfo
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string AccID { get; set; }
        public string ConnectionString { get; set; }
    }
}
