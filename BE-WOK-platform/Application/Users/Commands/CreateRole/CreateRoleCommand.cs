using MediatR;

namespace Application.Users.Commands.CreateRole
{
    public class CreateRoleCommand : IRequest<string?>
    {
        public string Name { get; set; }
    }
}
