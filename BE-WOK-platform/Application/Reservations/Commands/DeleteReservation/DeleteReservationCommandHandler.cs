using Application.Exceptions;
using Application.Interfaces;
using Domain.Models;
using MediatR;

namespace Application.Reservations.Commands.DeleteReservation
{
    public class DeleteReservationCommandHandler : IRequestHandler<DeleteReservationCommand, Unit>
    {
        private readonly IReservationRepository _reservationRepository;

        public DeleteReservationCommandHandler(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<Unit> Handle(DeleteReservationCommand request, CancellationToken cancellationToken)
        {
            var reservation = await _reservationRepository.GetById(request.Id, cancellationToken)
                ?? throw new ObjectNotFoundException(
                    nameof(Reservation),
                    request.Id);

            await _reservationRepository.Delete(reservation, cancellationToken);
            return Unit.Value;
        }
    }
}
