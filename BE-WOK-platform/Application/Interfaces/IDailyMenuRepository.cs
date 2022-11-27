using Domain.Models;

namespace Application.Interfaces
{
    public interface IDailyMenuRepository
    {
        Task<DailyMenu> Add(DailyMenu dailyMenu, CancellationToken ct);
        Task<DailyMenu> Update(DailyMenu dailyMenu, CancellationToken ct);
        Task<DailyMenu?> Get (CancellationToken ct);
    }
}
