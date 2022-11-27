namespace Domain.Models
{
    public class DailyMenu
    {
        public Guid Id { get; set; }
        public Guid? FirstDishId { get; set; }
        public Item? FirstDish { get; set; }
        public Guid? SecondDishId { get; set; }
        public Item? SecondDish { get; set; }
        public double Price { get; set; }
    }
}
