using Domain.Models;
using MediatR;

namespace Application.Items.Commands.CreateItem
{
    public class CreateItemCommand : IRequest<Item>
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Ingredients { get; set; }
        public string? Description { get; set; }
        public string Photo { get; set; }
        public Guid CategoryId { get; set; }
    }
}
