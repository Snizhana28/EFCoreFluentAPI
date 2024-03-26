using EFCoreFluentAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreFluentAPI
{
    public class DataContext : DbContext
    {
        public DbSet<User> User { get; set; } = default!;
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var user = modelBuilder.Entity<User>();

            user.Property(x => x.Name).IsRequired();
            user.Property(x => x.Name).HasMaxLength(32);

            user.Property(x => x.Login).IsRequired();
            user.HasIndex(x => x.Login).IsUnique();
            user.Property(x => x.Login).HasMaxLength(64);

            user.Property(x => x.Password).IsRequired();
            user.Property(x => x.Password).HasMaxLength(64);

            user.Property(x => x.Role).IsRequired(false);
        }
    }
}
