namespace API.DTOs.Reservations
{
    public class ReservationByTableGetModel
    {
        public int TableNumber { get; set; }
        public IEnumerable<DateTime> ReservationTimes { get; set; }
    }
}
