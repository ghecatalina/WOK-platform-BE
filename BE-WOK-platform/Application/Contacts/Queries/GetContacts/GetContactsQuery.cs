using Domain.Models;
using MediatR;

namespace Application.Contacts.Queries.GetContacts
{
    public class GetContactsQuery : IRequest<IEnumerable<Contact>>
    {
        public DateTime? Date { get; set; }
    }
}
