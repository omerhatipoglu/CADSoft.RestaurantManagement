using System;

namespace CADSoft.Entity
{
    public class BaseModel
    {
        public int ID { get; set; }
        public bool IsDeleted { get; set; }
        public int CreateUserID { get; set; }
        public DateTime CreateTime { get; set; }
        public int UpdateUserID { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
