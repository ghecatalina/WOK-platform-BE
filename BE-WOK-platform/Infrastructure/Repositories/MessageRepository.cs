using Application.Interfaces;
using Domain.Models;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly AppDbContext _context;

        public MessageRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Message>> GetAll(CancellationToken ct)
        {
            var today = DateTime.UtcNow.Date;

            return await _context.Messages.AsNoTracking()
                .Where(x => x.Created >= today)
                .OrderByDescending(x => x.Created)
                .Take(50)
                .ToListAsync(ct);
        }

        public async Task Create(Message message, CancellationToken ct)
        {
            _context.Messages.Add(message);
            await _context.SaveChangesAsync(ct);
        }
    }
}
