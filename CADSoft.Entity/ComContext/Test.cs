namespace CADSoft.Entity.ComContext
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Test")]
    public partial class Test : BaseModel, IEntity
    {
        [StringLength(50)]
        public string Name { get; set; }
    }
}
