namespace API.DTOs.Reservations
{
    public class ReservationPostModel
    {
        public int TableNumber { get; set; }
        public int NoOfPeople { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string? Details { get; set; }
        public DateTime ReservationTime { get; set; }
    }
}
