using Domain.Models;
using MediatR;

namespace Application.Users.Queries.LoginUser
{
    public class LoginUserQuery : IRequest<(User User, IEnumerable<string> Roles)>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
