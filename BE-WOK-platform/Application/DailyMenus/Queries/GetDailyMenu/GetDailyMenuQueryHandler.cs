using Application.Exceptions;
using Application.Interfaces;
using Domain.Models;
using MediatR;

namespace Application.DailyMenus.Queries.GetDailyMenu
{
    public class GetDailyMenuQueryHandler : IRequestHandler<GetDailyMenuQuery, DailyMenu>
    {
        private readonly IDailyMenuRepository _dailyMenuRepository;

        public GetDailyMenuQueryHandler(
            IDailyMenuRepository dailyMenuRepository)
        {
            _dailyMenuRepository = dailyMenuRepository;
        }

        public async Task<DailyMenu> Handle(GetDailyMenuQuery request, CancellationToken cancellationToken)
        {
            var dailyMenu = await _dailyMenuRepository.Get(cancellationToken)
                ?? throw new ObjectNotFoundException(nameof(DailyMenu));

            return dailyMenu;
        }
    }
}
