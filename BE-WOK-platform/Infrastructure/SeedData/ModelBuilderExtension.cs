using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.SeedData
{
    public static class ModelBuilderExtension
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasData(DefaultCategories.GetDefaultCategories());

            modelBuilder.Entity<DailyMenu>()
                .HasData(DefaultDailyMenu.GetDefaultDailyMenu());

            modelBuilder.Entity<Table>()
                .HasData(DefaultTables.GetDefaultTables());
        }
    }
}
