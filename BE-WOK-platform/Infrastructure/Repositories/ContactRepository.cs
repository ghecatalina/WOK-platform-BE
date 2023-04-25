using Application.Interfaces;
using Domain.Models;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly AppDbContext _context;

        public ContactRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Contact>> Get(
            DateTime? date,
            CancellationToken ct)
        {
            var dateToFilter = date ?? DateTime.Now.Date;

            return await _context.Contacts.AsNoTracking()
                .Where(x => x.Date == dateToFilter)
                .ToListAsync(ct);
        }

        public async Task<Contact> Create(
            Contact contact,
            CancellationToken ct)
        {
            _context.Contacts.Add(contact);

            await _context.SaveChangesAsync(ct);

            return contact;
        }
    }
}
