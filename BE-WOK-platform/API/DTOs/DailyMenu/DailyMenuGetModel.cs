using API.DTOs.Items;

namespace API.DTOs.DailyMenu
{
    public class DailyMenuGetModel
    {
        public ItemGetModel FirstDish { get; set; }
        public ItemGetModel SecondDish { get; set; }
        public double Price { get; set; }
    }
}
