namespace API.DTOs.Reservations
{
    public class ReservationByTableGetModel
    {
        public int Id { get; set; }
        public int TableNumber { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string? Details { get; set; }
        public DateTime Date { get; set; }
    }
}
