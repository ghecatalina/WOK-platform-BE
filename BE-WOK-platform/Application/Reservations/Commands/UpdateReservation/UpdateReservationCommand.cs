using MediatR;

namespace Application.Reservations.Commands.UpdateReservation
{
    public class UpdateReservationCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string? Details { get; set; }
    }
}
