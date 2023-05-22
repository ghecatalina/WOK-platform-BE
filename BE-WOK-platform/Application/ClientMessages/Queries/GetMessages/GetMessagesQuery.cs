using Domain.Models;
using MediatR;

namespace Application.ClientMessages.Queries.GetMessages
{
    public class GetMessagesQuery : IRequest<IEnumerable<Message>>
    {
    }
}
