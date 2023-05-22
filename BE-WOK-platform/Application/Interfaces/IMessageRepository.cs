using Domain.Models;

namespace Application.Interfaces
{
    public interface IMessageRepository
    {
        Task<IEnumerable<Message>> GetAll(CancellationToken ct);
        Task Create(Message message, CancellationToken ct);
    }
}
