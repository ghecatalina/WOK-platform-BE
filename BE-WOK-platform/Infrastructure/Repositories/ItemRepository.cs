using Application.Interfaces;
using Domain.Models;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly AppDbContext _context;

        public ItemRepository(
            AppDbContext context)
        {
            _context = context;
        }

        public async Task<Item> Create(Item item, CancellationToken ct)
        {
            _context.Items.Add(item);
            await _context.SaveChangesAsync(ct);
            return item;
        }

        public async Task Delete(Item item, CancellationToken ct)
        {
            _context.Items.Remove(item);
            await _context.SaveChangesAsync(ct);
        }

        public async Task<Item?> Get(Guid categoryId, Guid itemId, CancellationToken ct)
        {
            return await _context.Items
                .FirstOrDefaultAsync(x => x.Id == itemId && x.CategoryId == categoryId, ct);
        }

        public async Task<IEnumerable<Item>> GetAll(Guid categoryId, CancellationToken ct)
        {
            return await _context.Items
                .Where(x => x.CategoryId == categoryId)
                .ToListAsync(ct);
        }

        public async Task<Item?> GetById(Guid itemId, CancellationToken ct)
        {
            return await _context.Items
                .FirstOrDefaultAsync(x => x.Id == itemId, ct);
        }

        public async Task<Item> Update(Item item, CancellationToken ct)
        {
            _context.Items.Update(item);

            await _context.SaveChangesAsync(ct);
            return item;
        }
    }
}
