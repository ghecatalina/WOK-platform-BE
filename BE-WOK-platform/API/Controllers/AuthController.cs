using API.DTOs.Users;
using API.Settings;
using Application.Users.Commands.AssignRoleToUser;
using Application.Users.Commands.CreateRole;
using Application.Users.Commands.RegisterUser;
using Application.Users.Queries.LoginUser;
using AutoMapper;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly JwtSettings _jwtSettings;

        public AuthController(IMapper mapper, IMediator mediator, IOptionsSnapshot<JwtSettings> jwtSettings)
        {
            _mapper = mapper;
            _mediator = mediator;
            _jwtSettings = jwtSettings.Value;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(UserRegisterModel request)
        {
            var command = _mapper.Map<RegisterUserCommand>(request);
            var result = await _mediator.Send(command);
            if (result != null)
            {
                return BadRequest(result);
            }
            return Ok();
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(UserloginModel request)
        {
            var query = _mapper.Map<LoginUserQuery>(request);
            var (user, roles) = await _mediator.Send(query);

            return Ok(new { Tk = GenerateJwt(user, roles), user.Id, Roles = roles });
        }

        [HttpPost]
        [Route("role")]
        public async Task<IActionResult> CreateRole([FromBody]string roleName)
        {
            var command = new CreateRoleCommand { Name= roleName };
            var result = await _mediator.Send(command);

            if (result != null)
            {
                return BadRequest(result);
            }
            return Ok();
        }

        [HttpPost]
        [Route("assign-role")]
        public async Task<IActionResult> AssignUserToRole(AssignUserToRoleModel request)
        {
            var command = _mapper.Map<AssignRoleToUserCommand>(request);
            var result = await _mediator.Send(command);

            if (result != null)
            {
                return BadRequest(result);
            }
            return Ok();
        }

        private string GenerateJwt(User user, IEnumerable<string> roles)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            var roleClaims = roles.Select(r => new Claim(ClaimTypes.Role, r));
            claims.AddRange(roleClaims);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_jwtSettings.ExpirationInDays));

            var token = new JwtSecurityToken(
                    issuer: _jwtSettings.Issuer,
                    audience: _jwtSettings.Issuer,
                    claims,
                    expires: expires,
                    signingCredentials: creds
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
