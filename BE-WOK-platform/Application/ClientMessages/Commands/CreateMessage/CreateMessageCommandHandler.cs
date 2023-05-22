using Application.Interfaces;
using Domain.Models;
using MediatR;

namespace Application.ClientMessages.Commands.CreateMessage
{
    public class CreateMessageCommandHandler : IRequestHandler<CreateMessageCommand, Unit>
    {
        private readonly IMessageRepository _messageRepository;

        public CreateMessageCommandHandler(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public async Task<Unit> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
        {
            var message = new Message
            {
                TableNo = request.TableNo,
                Type = request.Type,
                Tip = request.Tip,
                Pay = request.Pay,
                Created = DateTime.UtcNow,
            };

            await _messageRepository.Create(message, cancellationToken);
            return Unit.Value;
        }
    }
}
