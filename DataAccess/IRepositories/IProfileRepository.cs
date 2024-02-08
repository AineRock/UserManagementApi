using DataAccess.Models;

namespace DataAccess.IRepositories
{
    public interface IProfileRepository
    {
        Task<Profile> AddProfileAsync(Profile newProfile);
    }
}
