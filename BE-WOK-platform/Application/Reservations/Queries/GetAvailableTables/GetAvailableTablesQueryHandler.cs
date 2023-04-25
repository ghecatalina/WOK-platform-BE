using Application.Interfaces;
using Domain.Models;
using MediatR;

namespace Application.Reservations.Queries.GetAvailableTables
{
    public class GetAvailableTablesQueryHandler : IRequestHandler<GetAvailableTablesQuery, IEnumerable<Table>>
    {
        private readonly IReservationRepository _reservationRepository;

        public GetAvailableTablesQueryHandler(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<IEnumerable<Table>> Handle(GetAvailableTablesQuery request, CancellationToken cancellationToken)
        {
            var tables = await _reservationRepository.GetAvailableTables(
                request.ReservationDate,
                request.Size,
                cancellationToken);

            return tables;
        }
    }
}
