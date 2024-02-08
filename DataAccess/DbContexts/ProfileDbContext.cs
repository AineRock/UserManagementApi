using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DbContexts
{
    public class ProfileDbContext : DbContext
    {
        public ProfileDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {

        }

        public DbSet<Profile> Profiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
