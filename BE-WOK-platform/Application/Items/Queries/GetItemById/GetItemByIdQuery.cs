using Domain.Models;
using MediatR;

namespace Application.Items.Queries.GetItemById
{
    public class GetItemByIdQuery : IRequest<Item>
    {
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
    }
}
