namespace API.DTOs.Reservations
{
    public class ReservationPutModel
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string? Details { get; set; }
    }
}
