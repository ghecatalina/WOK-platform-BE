using Domain.Models;
using MediatR;

namespace Application.Items.Queries.GetItemsByCategory
{
    public class GetItemsByCategoryQuery : IRequest<IEnumerable<Item>>
    {
        public Guid CategoryId { get; set; }
    }
}
