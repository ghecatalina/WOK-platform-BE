namespace API.DTOs.Items
{
    public class ItemPostPutModel
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Ingredients { get; set; }
        public string? Description { get; set; }
        public string Photo { get; set; }
        public double Price { get; set; }
    }
}
