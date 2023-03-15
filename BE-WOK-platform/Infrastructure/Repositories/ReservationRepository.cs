using Application.Interfaces;
using Domain.Models;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly AppDbContext _context;

        public ReservationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Reservation> Create(
            Reservation reservation,
            CancellationToken ct)
        {
            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync(ct);
            return reservation;
        }

        public async Task<IEnumerable<Reservation>> GetReservations(CancellationToken ct)
        {
            var currentDate = DateTime.UtcNow.Date;

            return await _context.Reservations.AsNoTracking()
                .Where(x => x.ReservationTime >= currentDate)
                .OrderBy(x => x.TableNumber)
                .ToListAsync(ct);
        }

        public async Task<Reservation?> GetByTableAndDate(
            int tableNumber, 
            DateTime date,
            CancellationToken ct)
        {
            return await _context.Reservations.AsNoTracking()
                .FirstOrDefaultAsync(x => x.TableNumber == tableNumber && x.ReservationTime.Date == date.Date,
                ct);
        }
    }
}
