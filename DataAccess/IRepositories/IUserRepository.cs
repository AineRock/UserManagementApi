using DataAccess.Models;

namespace DataAccess.IRepositories
{
    public interface IUserRepository
    {
        Task<User> AddUserAsync(User newUser);
        User GetUserIdByEmail(string email);
        List<User> GetAllUsers();
    }
}
