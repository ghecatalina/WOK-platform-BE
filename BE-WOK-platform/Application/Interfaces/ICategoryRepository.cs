using Domain.Models;

namespace Application.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Category> Create(Category category);
        Task<Category> Update(Category category);
        Task<Category?> Get(Guid id);
        Task<IEnumerable<Category>> GetAll();

    }
}
