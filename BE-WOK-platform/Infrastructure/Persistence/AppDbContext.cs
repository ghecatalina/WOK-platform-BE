using Domain.Models;
using Infrastructure.SeedData;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class AppDbContext : IdentityDbContext<User, Role, Guid>
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<DailyMenu> DailyMenu { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // seed data
            modelBuilder.SeedData();

            #region Category
            modelBuilder.Entity<Category>(attr =>
            {
                attr.HasKey("Id");

                attr.Property(x => x.Name)
                    .HasMaxLength(50);

                attr.HasMany(x => x.Items)
                .WithOne(x => x.Category)
                .HasForeignKey(x => x.CategoryId);
            });
            #endregion

            #region Item
            modelBuilder.Entity<Item>(attr =>
            {
                attr.HasKey("Id");

                attr.HasOne(x => x.Category)
                .WithMany(x => x.Items);
            });
            #endregion

            #region DailyMenu
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
            #endregion

            #region Reservation
            modelBuilder.Entity<Reservation>(attr =>
            {
                attr.HasKey("Id");

                attr.ToTable("Reservations");
            });
            #endregion
        }

    }
}