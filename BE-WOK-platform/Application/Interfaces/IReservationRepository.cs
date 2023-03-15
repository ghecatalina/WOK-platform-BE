using Domain.Models;

namespace Application.Interfaces
{
    public interface IReservationRepository
    {
        Task<Reservation> Create(Reservation reservation, CancellationToken ct);
        Task<IEnumerable<Reservation>> GetReservations(CancellationToken ct);
        Task<Reservation?> GetByTableAndDate(int tableNumber, DateTime date, CancellationToken ct);
    }
}
