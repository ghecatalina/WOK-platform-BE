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
        public DbSet<Table> Tables { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Message> Messages { get; set; }

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
            modelBuilder.Entity<Table>(attr =>
            {
                attr.HasKey("Id");
            });

            modelBuilder.Entity<Reservation>(attr =>
            {
                attr.HasKey("Id");
                attr.HasOne<Table>()
                    .WithMany()
                    .HasForeignKey(x => x.TableId)
                    .OnDelete(DeleteBehavior.Cascade);

                attr.ToTable("Reservations");
            });
            #endregion

            #region Contact
            modelBuilder.Entity<Contact>(attr =>
            {
                attr.HasKey("Id");

                attr.Property(x => x.Name)
                .HasMaxLength(50);

                attr.Property(x => x.PhoneNumber)
                .HasMaxLength(15);

                attr.Property(x => x.Complaint)
                .HasMaxLength(500);
            });
            #endregion

            modelBuilder.Entity<Message>(attr =>
            {
                attr.HasKey("Id");
            });
        }

    }
}