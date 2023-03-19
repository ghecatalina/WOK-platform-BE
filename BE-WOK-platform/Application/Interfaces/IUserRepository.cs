using Domain.Models;

namespace Application.Interfaces
{
    public interface IUserRepository
    {
        Task<string?> Register(User user, string password);
        Task<User?> GetByEmail(string email);
        Task<bool> CheckPassword(User user, string password);
        Task<IEnumerable<string>> GetRoleByUser(User user);
        Task<Role?> GetRoleByName(string name);
        Task<string?> CreateRole(Role role);
        Task<string?> AddUserToRole(User user, Role role);
    }
}
