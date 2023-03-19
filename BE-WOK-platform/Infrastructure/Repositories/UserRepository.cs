using Application.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public UserRepository(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<string?> Register(User user, string password)
        {
            var userCreatedResult = await _userManager.CreateAsync(user, password);
            if (userCreatedResult.Succeeded)
            {
                return null;
            }
            return userCreatedResult.Errors.First().Description;
        }

        public async Task<User?> GetByEmail(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        } 

        public async Task<bool> CheckPassword(User user, string password)
        {
            return await _userManager.CheckPasswordAsync(user, password);
        }

        public async Task<IEnumerable<string>> GetRoleByUser(User user)
        {
            return await _userManager.GetRolesAsync(user);
        }

        public async Task<Role?> GetRoleByName(string name)
        {
            return await _roleManager.FindByNameAsync(name);
        }

        public async Task<string?> CreateRole(Role role)
        {
            var createdRole = await _roleManager.CreateAsync(role);
            if (createdRole.Succeeded)
            {
                return null;
            }
            return createdRole.Errors.First().Description;
        }

        public async Task<string?> AddUserToRole(User user, Role role)
        {
            var result = await _userManager.AddToRoleAsync(user, role.Name);
            if (result.Succeeded)
            {
                return null;
            }
            return result.Errors.First().Description;
        }
    }
}
