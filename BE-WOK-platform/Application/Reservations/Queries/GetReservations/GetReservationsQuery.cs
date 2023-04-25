using Application.ReadModels;
using MediatR;

namespace Application.Reservations.Queries.GetReservations
{
    public class GetReservationsQuery : IRequest<IEnumerable<ReservationByTable>>
    {
        public DateTime? Date { get; set; }
    }
}
