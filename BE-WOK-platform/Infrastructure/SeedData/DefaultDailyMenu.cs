using Domain.Models;

namespace Infrastructure.SeedData
{
    public class DefaultDailyMenu
    {
        public static DailyMenu GetDefaultDailyMenu()
        {
            return new DailyMenu
            {
                Id = new Guid("00000000-0000-0000-0000-000000000001")
            };
        }
    }
}
