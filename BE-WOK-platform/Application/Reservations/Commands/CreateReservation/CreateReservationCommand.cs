using Domain.Models;
using MediatR;

namespace Application.Reservations.Commands.CreateReservation
{
    public class CreateReservationCommand : IRequest<Reservation>
    {
        public int TableId { get; set; }
        public int NoOfPeople { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string? Details { get; set; }
        public DateTime ReservationTime { get; set; }
    }
}
