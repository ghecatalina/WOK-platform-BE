using MediatR;

namespace Application.Users.Commands.AssignRoleToUser
{
    public class AssignRoleToUserCommand : IRequest<string?>
    {
        public string Email { get; set; }
        public string RoleName { get; set; }
    }
}
