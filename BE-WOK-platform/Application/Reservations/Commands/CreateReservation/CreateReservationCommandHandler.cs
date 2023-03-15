using Application.Exceptions;
using Application.Interfaces;
using Domain.Models;
using MediatR;

namespace Application.Reservations.Commands.CreateReservation
{
    public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand, Reservation>
    {
        private readonly IReservationRepository _reservationRepository;

        public CreateReservationCommandHandler(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<Reservation> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            if (request.ReservationTime < DateTime.UtcNow.AddMinutes(-5))
            {
                throw new InvalidDateTimeException(request.ReservationTime);
            }
            var existingReservation = await _reservationRepository.GetByTableAndDate(request.TableNumber, request.ReservationTime.Date, cancellationToken);
            if (existingReservation != null)
            {
                throw new DuplicateItemException(
                    nameof(Reservation),
                    new() { 
                        { nameof(Reservation.TableNumber), request.TableNumber },
                        { nameof(Reservation.ReservationTime), request.ReservationTime },
                    });
            }

            var reservationToCreate = new Reservation
            {
                TableNumber = request.TableNumber,
                ReservationTime = request.ReservationTime,
            };

            return await _reservationRepository.Create(reservationToCreate, cancellationToken);
        }
    }
}
