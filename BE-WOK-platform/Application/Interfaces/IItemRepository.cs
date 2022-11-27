using Domain.Models;

namespace Application.Interfaces
{
    public interface IItemRepository
    {
        Task<Item> Create(Item item, CancellationToken ct);
        Task<Item> Update(Item item, CancellationToken ct);
        Task<Item?> Get(Guid categoryid, Guid itemId, CancellationToken ct);
        Task<Item?> GetById(Guid itemId, CancellationToken ct);
        Task<IEnumerable<Item>> GetAll(Guid categoryId, CancellationToken ct);
        Task Delete(Item item, CancellationToken ct);
    }
}
