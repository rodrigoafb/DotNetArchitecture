using Microsoft.EntityFrameworkCore;
using Solution.Model.Entities;

namespace Solution.Infrastructure.Database
{
    public sealed class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<UserEntity> Users { get; set; }

        public DbSet<UserLogEntity> UsersLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfiguration(new UserEntityTypeConfiguration())
                .ApplyConfiguration(new UserLogEntityTypeConfiguration());
        }
    }
}
