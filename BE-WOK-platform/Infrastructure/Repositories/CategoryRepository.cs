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

        public async Task<Category> Create(
            Category category,
            CancellationToken ct)
        {
            _context.Categories.Add(category);

            await _context.SaveChangesAsync(ct);

            return category;
        }

        public async Task<Category?> Get(
            Guid id,
            CancellationToken ct)
        {
            return await _context.Categories
                .FirstOrDefaultAsync(x => x.Id == id, ct);
        }

        public async Task<IEnumerable<Category>> GetAll(
            CancellationToken ct)
        {
            return await _context.Categories
                .ToListAsync(ct);
        }

        public async Task<Category> Update(
            Category category, 
            CancellationToken ct)
        {
            _context.Categories.Update(category);

            await _context.SaveChangesAsync(ct);

            return category;    
        }
    }
}
