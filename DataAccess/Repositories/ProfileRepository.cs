using DataAccess.DbContexts;
using DataAccess.IRepositories;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        private ProfileDbContext _context;

        public ProfileRepository(ProfileDbContext context)
        {
            _context = context;
        }

        public async Task<Profile> AddProfileAsync(Profile newProfile)
        {
            await _context.Profiles.AddAsync(newProfile);
            await _context.SaveChangesAsync();
            return newProfile;
        }
    }
}
