using MediatR;

namespace Application.Contacts.Commands.CreateContact
{
    public class CreateContactCommand : IRequest<Unit>
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Complaint { get; set; }
    }
}
