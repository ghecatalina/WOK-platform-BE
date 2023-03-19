using API.DTOs.Users;
using Application.Users.Commands.AssignRoleToUser;
using Application.Users.Commands.RegisterUser;
using Application.Users.Queries.LoginUser;
using AutoMapper;

namespace API.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserRegisterModel, RegisterUserCommand>();
            CreateMap<UserloginModel, LoginUserQuery>();
            CreateMap<AssignUserToRoleModel, AssignRoleToUserCommand>();
        }
    }
}
