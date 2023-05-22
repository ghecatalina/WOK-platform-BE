using Domain.Models;

namespace Application.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Category> Create(Category category, CancellationToken ct);
        Task<Category> Update(Category category, CancellationToken ct);
        Task<Category?> Get(Guid id, CancellationToken ct);
        Task<IEnumerable<Category>> GetAll(CancellationToken ct);
        Task Delete(Category category, CancellationToken ct);

    }
}
