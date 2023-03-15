namespace Application.ReadModels
{
    public class ReservationByTable
    {
        public int TableNumber { get; set; }
        public IEnumerable<DateTime> ReservationTimes { get; set; }
    }
}
