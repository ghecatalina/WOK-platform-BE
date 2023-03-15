namespace API.DTOs.Reservations
{
    public class ReservationPostModel
    {
        public int TableNumber { get; set; }
        public DateTime ReservationTime { get; set; }
    }
}
