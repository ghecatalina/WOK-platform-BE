using Application.Interfaces;
using Application.ReadModels;
using Domain.Models;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<IEnumerable<ReservationByTable>> GetReservations(DateTime? date, CancellationToken ct)
        {
            var currentDate = !date.HasValue ? 
                DateTime.UtcNow.Date :
                date.Value.Date;

            var reservations = from reservation in _context.Reservations.AsNoTracking()
                               where reservation.ReservationTime.Date == currentDate
                               join table in _context.Tables.AsNoTracking()
                               on reservation.TableId equals table.Id
                               select new ReservationByTable
                               {
                                   Id = reservation.Id,
                                   Name = reservation.Name,
                                   PhoneNumber = reservation.PhoneNumber,
                                   Details = reservation.Details,
                                   TableNumber = table.Number,
                                   Date = reservation.ReservationTime
                               };

            return await reservations
                .OrderBy(x => x.Name)
                .ToListAsync(ct);
        }

        public async Task<Reservation?> GetByTableAndDate(
            int tableNumber, 
            DateTime date,
            CancellationToken ct)
        {
            return await _context.Reservations.AsNoTracking()
                .FirstOrDefaultAsync(x => x.TableId == tableNumber && x.ReservationTime.Date == date.Date,
                ct);
        }

        public async Task<IEnumerable<Table>> GetAvailableTables(
            DateTime reservationDate,
            int size,
            CancellationToken ct)
        {
            var tables = _context.Tables.AsNoTracking()
                .Where(x => x.Size >= size);

            var reservedTablesId = _context.Reservations.AsNoTracking()
                .Where(x => x.ReservationTime >= reservationDate
                && reservationDate.Date == reservationDate.Date)
                .Select(x => x.TableId);

            var availableTables = tables
                .Where(x => !reservedTablesId.Contains(x.Id));

            return await availableTables.ToListAsync(ct);
        }

        public async Task Delete(
            Reservation reservation,
            CancellationToken ct)
        {
            _context.Reservations.Remove(reservation);

            await _context.SaveChangesAsync(ct);
        }

        public async Task<Reservation?> GetById(
            int id,
            CancellationToken ct)
        {
            return await _context.Reservations.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id, ct);
        }

        public async Task Update(
            Reservation reservation,
            CancellationToken ct)
        {
            _context.Reservations.Update(reservation);
            await _context.SaveChangesAsync(ct);
        }
    }
}
