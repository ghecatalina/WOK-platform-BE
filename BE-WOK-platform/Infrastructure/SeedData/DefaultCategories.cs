using Domain.Models;

namespace Infrastructure.SeedData
{
    public static class DefaultCategories
    {
        public static List<Category> GetDefaultCategories()
        {
            return new List<Category>()
            {
                new Category { Id = new Guid("00000000-0000-0000-0000-000000000001"), Name = "Salads & Starters"},
                new Category { Id = new Guid("00000000-0000-0000-0000-000000000002"), Name = "Soups"},
                new Category { Id = new Guid("00000000-0000-0000-0000-000000000003"), Name = "Main Courses"},
                new Category { Id = new Guid("00000000-0000-0000-0000-000000000004"), Name = "Desserts"},
                new Category { Id = new Guid("00000000-0000-0000-0000-000000000005"), Name = "Drinks"},
                new Category { Id = new Guid("00000000-0000-0000-0000-000000000006"), Name = "Coffee & Tea"}
            };
        }
    }
}
