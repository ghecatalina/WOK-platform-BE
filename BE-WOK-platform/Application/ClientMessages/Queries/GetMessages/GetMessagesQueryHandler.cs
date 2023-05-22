using Application.Interfaces;
using Domain.Models;
using MediatR;

namespace Application.ClientMessages.Queries.GetMessages
{
    public class GetMessagesQueryHandler : IRequestHandler<GetMessagesQuery, IEnumerable<Message>>
    {
        private readonly IMessageRepository _messageRepository;

        public GetMessagesQueryHandler(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public async Task<IEnumerable<Message>> Handle(GetMessagesQuery request, CancellationToken cancellationToken)
        {
            return await _messageRepository.GetAll(cancellationToken);
        }
    }
}
