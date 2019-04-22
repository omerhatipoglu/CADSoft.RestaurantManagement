namespace CADSoft.Entity.ComContext
{
    using System.Data.Entity;

    public partial class ComContext : DbContext
    {
        public ComContext(string ConnectionString)
            : base(ConnectionString)
        {
        }

        public virtual DbSet<Test> Test { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
