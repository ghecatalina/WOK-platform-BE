using Application.Exceptions;
using Application.Interfaces;
using Domain.Models;
using MediatR;

namespace Application.DailyMenus.Commands.AddOrUpdateDailyMenu
{
    public class UpdateDailyMenuCommandHandler : IRequestHandler<UpdateDailyMenuCommand, Unit>
    {
        private readonly IDailyMenuRepository _dailyMenuRepository;
        private readonly IItemRepository _itemRepository;

        public UpdateDailyMenuCommandHandler(
            IDailyMenuRepository dailyMenuRepository,
            IItemRepository itemRepository)
        {
            _dailyMenuRepository = dailyMenuRepository;
            _itemRepository = itemRepository;
        }

        public async Task<Unit> Handle(UpdateDailyMenuCommand request, CancellationToken cancellationToken)
        {
            var firstDish = await _itemRepository.GetById(request.FirstDish, cancellationToken)
                ?? throw new ObjectNotFoundException(
                    nameof(Item),
                    request.FirstDish);

            var secondDish = await _itemRepository.GetById(request.SecondDish, cancellationToken)
                ?? throw new ObjectNotFoundException(
                    nameof(Item),
                    request.SecondDish);

            var dailyMenu = await _dailyMenuRepository.Get(cancellationToken)
                ?? throw new ObjectNotFoundException(
                    nameof(DailyMenu),
                    "daily menu");

            dailyMenu.FirstDishId = firstDish.Id;
            dailyMenu.FirstDish = firstDish;
            dailyMenu.SecondDishId = secondDish.Id;
            dailyMenu.SecondDish = secondDish;
            dailyMenu.Price = request.Price;

            await _dailyMenuRepository.Update(dailyMenu, cancellationToken);

            return Unit.Value;
        }
    }
}
