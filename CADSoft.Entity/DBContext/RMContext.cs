namespace CADSoft.Entity.DBContext
{
    using System.Data.Entity;

    public partial class RMContext : DbContext
    {
        public RMContext()
            : base("name=RMContext")
        {
        }

        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Session> Session { get; set; }
        public virtual DbSet<SessionPreview> SessionPreview { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(x => x.Session)
                .WithRequired(x => x.User)
                .HasForeignKey(x => x.UserID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(x => x.SessionPreview)
                .WithRequired(x => x.User)
                .HasForeignKey(x => x.UserID)
                .WillCascadeOnDelete(false);
        }
    }
}
