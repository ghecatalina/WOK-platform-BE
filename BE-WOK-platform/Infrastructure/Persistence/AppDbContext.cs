using Domain.Models;
using Infrastructure.SeedData;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<DailyMenu> DailyMenu { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // seed data
            modelBuilder.SeedData();

            modelBuilder.Entity<Category>(attr =>
            {
                attr.HasKey("Id");

                attr.Property(x => x.Name)
                    .HasMaxLength(50);

                attr.HasMany(x => x.Items)
                .WithOne(x => x.Category)
                .HasForeignKey(x => x.CategoryId);
            });

            modelBuilder.Entity<Item>(attr =>
            {
                attr.HasKey("Id");

                attr.HasOne(x => x.Category)
                .WithMany(x => x.Items);
            });

            modelBuilder.Entity<DailyMenu>(attr =>
            {
                attr.HasOne(x => x.FirstDish)
                .WithOne()
                .OnDelete(DeleteBehavior.NoAction);

                attr.HasOne(x => x.SecondDish)
                .WithOne()
                .OnDelete(DeleteBehavior.NoAction);

                attr.ToTable("DailyMenu");
            });
        }

    }
}