using MediatR;

namespace Application.Items.Commands.DeleteItem
{
    public class DeleteItemCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
    }
}
