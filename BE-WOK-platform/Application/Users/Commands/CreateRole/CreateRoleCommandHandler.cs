using Application.Exceptions;
using Application.Interfaces;
using Domain.Models;
using MediatR;

namespace Application.Users.Commands.CreateRole
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, string?>
    {
        private readonly IUserRepository _userRepository;

        public CreateRoleCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<string?> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            var existingRole = await _userRepository.GetRoleByName(request.Name);
            if (existingRole != null)
            {
                throw new DuplicateItemException(
                    nameof(Role),
                    nameof(Role.Name),
                    request.Name);
            }

            var result = await _userRepository.CreateRole(new Role { Name = request.Name });
            return result;
        }
    }
}
