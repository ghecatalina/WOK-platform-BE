namespace Domain.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int TableNumber { get; set; }
        public DateTime ReservationTime { get; set; }
    }
}
