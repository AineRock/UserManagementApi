using DataAccess.DbContexts;
using DataAccess.IRepositories;
using DataAccess.Models;

namespace DataAccess.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        private UserDbContext _context;

        public ProfileRepository(UserDbContext context)
        {
            _context = context;
        }

        public async Task<Profile> AddProfileAsync(Profile newProfile)
        {
             await _context.Profile.AddAsync(newProfile);
             await _context.SaveChangesAsync();

            return newProfile;
        }

        public List<Profile> GetAllProfiles()
        {
            return _context.Profile.ToList();
        }
    }
}
