using Application.Interfaces;
using Application.ReadModels;
using MediatR;

namespace Application.Reservations.Queries.GetReservations
{
    public class GetReservationsQueryHandler : IRequestHandler<GetReservationsQuery, IEnumerable<ReservationByTable>>
    {
        private readonly IReservationRepository _reservationRepository;

        public GetReservationsQueryHandler(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<IEnumerable<ReservationByTable>> Handle(GetReservationsQuery request, CancellationToken cancellationToken)
        {
            var reservations = await _reservationRepository.GetReservations(request.Date, cancellationToken);

            return reservations;
        }
    }
}
