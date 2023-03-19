using Application.Exceptions;
using Application.Interfaces;
using Domain.Models;
using MediatR;

namespace Application.Users.Queries.LoginUser
{
    public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, (User user, IEnumerable<string> roles)>
    {
        private readonly IUserRepository _userRepository;

        public LoginUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<(User user, IEnumerable<string> roles)> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByEmail(request.Email)
                ?? throw new ObjectNotFoundException(
                    nameof(User),
                    request.Email);

            var checkPassword = await _userRepository.CheckPassword(user, request.Password);
            if (!checkPassword) 
            {
                throw new InvalidCredentialsException();
            }

            var roles = await _userRepository.GetRoleByUser(user);

            return (user, roles);
        }
    }
}
