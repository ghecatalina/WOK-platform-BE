using Domain.Models;
using MediatR;

namespace Application.Reservations.Queries.GetAvailableTables
{
    public class GetAvailableTablesQuery : IRequest<IEnumerable<Table>>
    {
        public DateTime ReservationDate { get; set; }
        public int Size { get; set; }
    }
}
