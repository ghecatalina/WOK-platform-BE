namespace API.DTOs.Reservations
{
    public class ReservationGetModel
    {
        public int TableNumber { get; set; }
        public DateTime ReservationTime { get; set; }
    }
}
