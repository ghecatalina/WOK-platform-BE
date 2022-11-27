using Domain.Models;
using MediatR;

namespace Application.DailyMenus.Queries.GetDailyMenu
{
    public class GetDailyMenuQuery : IRequest<DailyMenu>
    {
    }
}
