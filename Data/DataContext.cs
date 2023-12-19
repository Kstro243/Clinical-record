using Microsoft.EntityFrameworkCore;

namespace emz.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<User>? User { get; set; }
        public DbSet<UsersHeadquarters>? UsersHeadquarters { get; set; }
        public DbSet<UsersRoles>? UsersRoles { get; set; }
        public DbSet<Headquarter>? Headquarter { get; set; }
        public DbSet<Roles>? Roles { get; set; }
        public DbSet<TypeOfIdentification>? TypeOfIdentification { get; set; }
        public DbSet<Session>? Session { get; set; }
        public DbSet<Log>? Log { get; set; }
        public DbSet<Token>? Token { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Headquarter>().HasIndex(hq => hq.Id).IsUnique();
            modelBuilder.Entity<Log>().HasIndex(l => l.Id).IsUnique();
            modelBuilder.Entity<Roles>().HasIndex(rol => rol.Id).IsUnique();
            modelBuilder.Entity<Session>().HasIndex(se => se.Id).IsUnique();
            modelBuilder.Entity<Token>().HasIndex(tok => tok.Id).IsUnique();
            modelBuilder.Entity<TypeOfIdentification>().HasIndex(toi => toi.Id).IsUnique();
            modelBuilder.Entity<User>().HasIndex(us => us.Id).IsUnique();
            modelBuilder.Entity<UsersHeadquarters>().HasIndex(us => us.Id).IsUnique();
            modelBuilder.Entity<UsersRoles>().HasIndex(us => us.Id).IsUnique();
        }
    }
}