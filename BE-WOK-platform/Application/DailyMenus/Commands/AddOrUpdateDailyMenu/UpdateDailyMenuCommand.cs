using MediatR;

namespace Application.DailyMenus.Commands.AddOrUpdateDailyMenu
{
    public class UpdateDailyMenuCommand : IRequest<Unit>
    {
        public Guid FirstDish { get; set; }
        public Guid SecondDish { get; set; }
        public double Price { get; set; }
    }
}
