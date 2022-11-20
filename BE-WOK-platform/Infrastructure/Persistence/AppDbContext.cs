using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>(attr =>
            {
                attr.HasKey("Id");

                attr.Property(x => x.Name)
                    .HasMaxLength(50);
            });
        }

    }
}