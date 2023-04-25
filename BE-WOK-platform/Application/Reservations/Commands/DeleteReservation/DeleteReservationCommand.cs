using MediatR;

namespace Application.Reservations.Commands.DeleteReservation
{
    public class DeleteReservationCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
