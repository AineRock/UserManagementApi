using DataAccess.Models;

namespace DataAccess.IRepositories
{
    public interface IUserRepository
    {
        Task<User> AddUserAsync(User newUser);
        Task<User> GetUserIdByEmail(string email);
    }
}
