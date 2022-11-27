using Application.Interfaces;
using Domain.Models;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace Infrastructure.Repositories
{
    public class DailyMenuRepository : IDailyMenuRepository
    {
        private readonly AppDbContext _context;

        public DailyMenuRepository(
            AppDbContext context)
        {
            _context = context;
        }

        public async Task<DailyMenu> Add(DailyMenu dailyMenu, CancellationToken ct)
        {
            _context.DailyMenu.Add(dailyMenu);
            await _context.SaveChangesAsync(ct);
            return dailyMenu;
        }

        public async Task<DailyMenu?> Get(CancellationToken ct)
        {
            return await _context.DailyMenu
                .Include(x => x.FirstDish)
                .Include(x => x.SecondDish)
                .FirstOrDefaultAsync(ct);
        }

        public async Task<DailyMenu> Update(DailyMenu dailyMenu, CancellationToken ct)
        {
            _context.DailyMenu.Update(dailyMenu);
            await _context.SaveChangesAsync(ct);
            return dailyMenu;
        }
    }
}
