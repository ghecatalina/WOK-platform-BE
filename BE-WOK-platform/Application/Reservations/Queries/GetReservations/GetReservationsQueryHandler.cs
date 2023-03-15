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
            var reservationGroups = (await _reservationRepository.GetReservations(cancellationToken))
                .GroupBy(x => x.TableNumber);

            var reservations = new List<ReservationByTable>();
            foreach (var group in reservationGroups)
            {
                reservations.Add(new ReservationByTable
                {
                    TableNumber = group.Key,
                    ReservationTimes = group.Select(x => x.ReservationTime).ToList(),
                });
            }

            return reservations;
        }
    }
}
