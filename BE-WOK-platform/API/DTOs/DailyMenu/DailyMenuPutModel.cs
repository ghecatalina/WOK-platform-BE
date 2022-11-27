namespace API.DTOs.DailyMenu
{
    public class DailyMenuPutModel
    {
        public Guid FirstDish { get; set; }
        public Guid SecondDish { get; set; }
        public double Price { get; set; }
    }
}
