using Application.Interfaces;
using Domain.Models;
using MediatR;

namespace Application.Contacts.Queries.GetContacts
{
    public class GetContactsQueryHandler : IRequestHandler<GetContactsQuery, IEnumerable<Contact>>
    {
        private readonly IContactRepository _contactRepository;

        public GetContactsQueryHandler(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<IEnumerable<Contact>> Handle(GetContactsQuery request, CancellationToken cancellationToken)
        {
            return await _contactRepository.Get(request.Date, cancellationToken);
        }
    }
}
