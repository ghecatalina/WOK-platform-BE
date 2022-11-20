using Application.Interfaces;
using Domain.Models;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(
            AppDbContext context)
        {
            _context = context;
        }

        public async Task<Category> Create(Category category)
        {
            _context.Categories.Add(category);

            await _context.SaveChangesAsync();

            return category;
        }

        public async Task<Category?> Get(Guid id)
        {
            return await _context.Categories
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _context.Categories
                .ToListAsync();
        }

        public async Task<Category> Update(Category category)
        {
            _context.Categories.Update(category);

            await _context.SaveChangesAsync();

            return category;    
        }
    }
}
