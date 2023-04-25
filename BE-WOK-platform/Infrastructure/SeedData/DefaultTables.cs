using Domain.Models;

namespace Infrastructure.SeedData
{
    public static class DefaultTables
    {
        public static List<Table> GetDefaultTables()
        {
            return new List<Table>
            {
                new Table { Id = 1, Number = 1, Size = 4 },
                new Table { Id = 2, Number = 2, Size = 3 },
                new Table { Id = 3, Number = 3, Size = 2 },
                new Table { Id = 4, Number = 4, Size = 8 },
                new Table { Id = 5, Number = 5, Size = 10 },
                new Table { Id = 6, Number = 6, Size = 4 },
                new Table { Id = 7, Number = 7, Size = 4 },
                new Table { Id = 8, Number = 8, Size = 6 },
                new Table { Id = 9, Number = 9, Size = 2 },
                new Table { Id = 10, Number = 10, Size = 4 },
            };
        }
    }
}
