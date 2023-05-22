using Domain.Enums;
using MediatR;

namespace Application.ClientMessages.Commands.CreateMessage
{
    public class CreateMessageCommand : IRequest<Unit>
    {
        public MessageType Type { get; set; }
        public PayType? Pay { get; set; }
        public int TableNo { get; set; }
        public int? Tip { get; set; }
    }
}
