namespace CADSoft.Entity.DBContext
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Session")]
    public partial class Session : BaseModel, IEntity
    {
        public int UserID { get; set; }

        public string Token { get; set; }

        public DateTime? ExpiryDate { get; set; }

        public virtual User User { get; set; }

    }
}
