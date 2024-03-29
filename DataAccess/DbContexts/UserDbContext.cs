﻿using DataAccess.Configuration;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DataAccess.DbContexts
{
    public class UserDbContext : DbContext
    {
        private IConfiguration Configuration { get; set; }

        public UserDbContext(IConfiguration config, DbContextOptions<UserDbContext> options) : base(options)
        {
            Configuration = config;
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profile { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("UserManagementConnectionString"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ProfileConfiguration());

        }
    }
}
