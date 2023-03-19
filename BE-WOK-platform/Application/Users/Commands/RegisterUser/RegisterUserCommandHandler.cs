using Application.Exceptions;
using Application.Interfaces;
using Domain.Models;
using MediatR;

namespace Application.Users.Commands.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, string?>
    {
        private readonly IUserRepository _userRepository;

        public RegisterUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<string?> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _userRepository.GetByEmail(request.Email);
            if (existingUser != null)
            {
                throw new DuplicateItemException(
                    nameof(User),
                    nameof(User.Email),
                    request.Email);
            }

            var userToAdd = new User { Email = request.Email, UserName = request.Email, Name = request.Name };
            var result = await _userRepository.Register(userToAdd, request.Password);
            return result;
        }
    }
}
