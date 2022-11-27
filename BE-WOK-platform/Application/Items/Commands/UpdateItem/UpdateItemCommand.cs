using Domain.Models;
using MediatR;

namespace Application.Items.Commands.UpdateItem
{
    public class UpdateItemCommand : IRequest<Item>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Ingredients { get; set; }
        public string? Description { get; set; }
        public string Photo { get; set; }
        public Guid CategoryId { get; set; }
    }
}
