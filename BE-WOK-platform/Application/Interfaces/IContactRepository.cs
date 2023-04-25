using Domain.Models;

namespace Application.Interfaces
{
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> Get(
            DateTime? date,
            CancellationToken ct);

        Task<Contact> Create(
            Contact contact,
            CancellationToken ct);
    }
}
