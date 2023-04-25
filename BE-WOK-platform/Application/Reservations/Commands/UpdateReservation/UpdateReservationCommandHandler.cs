using Application.Exceptions;
using Application.Interfaces;
using Domain.Models;
using MediatR;

namespace Application.Reservations.Commands.UpdateReservation
{
    public class UpdateReservationCommandHandler : IRequestHandler<UpdateReservationCommand, Unit>
    {
        private readonly IReservationRepository _reservationRepository;

        public UpdateReservationCommandHandler(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<Unit> Handle(UpdateReservationCommand request, CancellationToken cancellationToken)
        {
            var reservation = await _reservationRepository.GetById(request.Id, cancellationToken)
                ?? throw new ObjectNotFoundException(
                    nameof(Reservation),
                    request.Id);

            reservation.Name = request.Name;
            reservation.PhoneNumber = request.PhoneNumber;
            reservation.Details = request.Details;

            await _reservationRepository.Update(reservation, cancellationToken);

            return Unit.Value;
        }
    }
}
