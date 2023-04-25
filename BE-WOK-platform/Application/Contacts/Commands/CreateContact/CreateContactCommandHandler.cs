using Application.Interfaces;
using Domain.Models;
using MediatR;

namespace Application.Contacts.Commands.CreateContact
{
    public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, Unit>
    {
        private readonly IContactRepository _contactRepository;

        public CreateContactCommandHandler(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<Unit> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            var contact = new Contact
            {
                Name = request.Name,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
                Complaint = request.Complaint,
                Date = DateTime.UtcNow.Date
            };

            await _contactRepository.Create(contact, cancellationToken);

            return Unit.Value;
        }
    }
}
