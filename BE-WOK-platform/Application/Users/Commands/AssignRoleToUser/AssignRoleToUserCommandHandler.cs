using Application.Exceptions;
using Application.Interfaces;
using Domain.Models;
using MediatR;

namespace Application.Users.Commands.AssignRoleToUser
{
    public class AssignRoleToUserCommandHandler : IRequestHandler<AssignRoleToUserCommand, string?>
    {
        private readonly IUserRepository _userRepository;

        public AssignRoleToUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<string?> Handle(AssignRoleToUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByEmail(request.Email)
                ?? throw new ObjectNotFoundException(
                    nameof(User),
                    request.Email);

            var role = await _userRepository.GetRoleByName(request.RoleName)
                ?? throw new ObjectNotFoundException(
                    nameof(Role),
                    request.RoleName);

            var result = await _userRepository.AddUserToRole(user, role);
            return result;
        }
    }
}
