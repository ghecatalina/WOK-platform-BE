using Domain.Models;
using MediatR;

namespace Application.Reservations.Commands.CreateReservation
{
    public class CreateReservationCommand : IRequest<Reservation>
    {
        public int TableNumber { get; set; }
        public DateTime ReservationTime { get; set; }
    }
}
