using Application.ReadModels;
using Domain.Models;

namespace Application.Interfaces
{
    public interface IReservationRepository
    {
        Task<Reservation> Create(Reservation reservation, CancellationToken ct);
        Task<IEnumerable<ReservationByTable>> GetReservations(DateTime? date, CancellationToken ct);
        Task<Reservation?> GetByTableAndDate(int tableNumber, DateTime date, CancellationToken ct);
        Task<IEnumerable<Table>> GetAvailableTables(DateTime reservationDate, int size, CancellationToken ct);
        Task Delete(Reservation reservation, CancellationToken ct);
        Task<Reservation?> GetById(int id, CancellationToken ct);
        Task Update(Reservation reservation, CancellationToken ct);
    }
}
